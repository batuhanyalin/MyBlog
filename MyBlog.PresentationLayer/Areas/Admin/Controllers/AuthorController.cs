using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using MyBlog.PresentationLayer.Areas.Admin.Models;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAppUserService _userService;
        private readonly UserManager<AppUser> _userManager;

        public AuthorController(IAppUserService userService, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }
        [Authorize(Roles = "Editor,Admin")]
        [Route("AuthorIndex")]
        public IActionResult AuthorIndex()
        {
            var values = _userService.TGetAuthorWithCommentArticle();
            return View(values);
        }

        [Authorize(Roles = "Editor,Admin")]
        [Route("AdminIndex")]
        public IActionResult AdminIndex()
        {
            var values = _userService.TGetAdminWithCommentArticle();
            return View(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor(AppUser user, IFormFile Image)
        {
            if (Image != null && Image.Length > 0)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(resource, "wwwroot/images", imageName);
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                user.ImageUrl = $"/images/{imageName}";
            }
            else if (user.ImageUrl == null)
            {
                user.ImageUrl = $"/images/no-image.jpg";
            }
            if (user.AppRoleId == null)
            {
                user.AppRoleId = 1;
            }
            _userService.TInsert(user);
            return RedirectToAction("AuthorIndex");
        }
        [Authorize(Roles = "Admin")]
        [Route("DeleteAuthor/{id:int}")]
        public IActionResult DeleteAuthor(int id)
        {
            _userService.TDelete(id);
            return RedirectToAction("AuthorIndex");
        }
        [Authorize(Roles = "Editor,Admin")]
        [Route("ChangeIsApprovedAuthor/{id:int}")]
        public IActionResult ChangeIsApprovedAuthor(int id)
        {
            _userService.TChangeIsApprovedArticleById(id);
            return RedirectToAction("AuthorIndex");
        }
        [Authorize(Roles = "Admin")]
        [Route("ChangeIsApprovedAuthor/{id:int}")]
        public IActionResult ChangeIsApprovedAdmin(int id)
        {
            _userService.TChangeIsApprovedArticleById(id);
            return RedirectToAction("AdminIndex");
        }
        [Authorize(Roles = "Editor,Admin")]
        [HttpGet]
        [Route("EditProfile")]
        public async Task<IActionResult> EditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            EditAdminProfileViewModel model = new EditAdminProfileViewModel();
            model.Name = values.Name;
            model.Email = values.Email;
            model.Profession = values.Profession;
            model.PhoneNumber = values.PhoneNumber;
            model.ImageUrl = values.ImageUrl;
            model.City = values.City;
            model.About = values.About;
            model.Surname = values.Surname;
            model.Username = values.UserName;
            ViewBag.commentscount = _userService.TGetCommentsCountByAuthor(values.Id);
            ViewBag.articlecount = _userService.TGetArticleCountByAuthor(values.Id);
            return View(model);
        }
        [Authorize(Roles = "Editor,Admin")]
        [HttpPost]
        [Route("EditProfile")]
        public async Task<IActionResult> EditProfile(EditAdminProfileViewModel p, IFormFile Image)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/images/" + imageName;

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                user.ImageUrl = $"/images/{imageName}";
            }
            else if (user.ImageUrl == null)
            {
                user.ImageUrl = $"/images/no-image.jpg";
            }

            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PhoneNumber = p.PhoneNumber;
            user.City = p.City;
            user.Email = p.Email;
            user.Profession = p.Profession;
            user.About = p.About;

            if (p.Password != null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            ViewBag.commentscount = _userService.TGetCommentsCountByAuthor(user.Id);
            ViewBag.articlecount = _userService.TGetArticleCountByAuthor(user.Id);
            return View(p);
        }
        [Authorize(Roles = "Admin")]
        [Route("UpdateAuthor/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            var values = await _userManager.FindByIdAsync(id.ToString());
            if (values == null)
            {
                return NotFound();
            }
            EditAuthorProfileViewModel model = new EditAuthorProfileViewModel();
            model.Name = values.Name;
            model.Id = values.Id;
            model.Email = values.Email;
            model.Profession = values.Profession;
            model.PhoneNumber = values.PhoneNumber;
            model.ImageUrl = values.ImageUrl;
            model.City = values.City;
            model.About = values.About;
            model.Surname = values.Surname;
            model.Username = values.UserName;
            model.IsApproved = values.IsApproved;
            model.AppRoleId = values.AppRoleId;
            ViewBag.commentscount = _userService.TGetCommentsCountByAuthor(id);
            ViewBag.articlecount = _userService.TGetArticleCountByAuthor(id);
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [Route("UpdateAuthor/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(EditAuthorProfileViewModel p, IFormFile Image)
        {
            var user = await _userManager.FindByIdAsync(p.Id.ToString());
            if (Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/images/" + imageName;

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                user.ImageUrl = $"/images/{imageName}";
            }
            else if (user.ImageUrl == null)
            {
                user.ImageUrl = $"/images/no-image.jpg";
            }

            user.Name = p.Name;
            user.UserName = p.Username;
            user.Surname = p.Surname;
            user.PhoneNumber = p.PhoneNumber;
            user.City = p.City;
            user.Email = p.Email;
            user.Profession = p.Profession;
            user.About = p.About;
            user.AppRoleId = p.AppRoleId;
            user.IsApproved = p.IsApproved;

            if (p.Password != null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                if (user.AppRoleId==1)
                {
                    return RedirectToAction("AuthorIndex", "Author", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("AdminIndex", "Author", new { Area = "Admin" });
                }              
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return RedirectToAction("AuthorIndex");
        }
    }
}