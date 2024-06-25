using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

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

        [Route("AuthorIndex")]
        public IActionResult AuthorIndex()
        {
            var values = _userService.TGetAuthorWithCommentArticle();
            return View(values);
        }
        [Route("AdminIndex")]
        public IActionResult AdminIndex()
        {
            var values = _userService.TGetAdminWithCommentArticle();
            return View(values);
        }

        [HttpGet]
        [Route("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor()
        {
            return View();
        }
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
        [Route("DeleteAuthor/{id:int}")]
        public IActionResult DeleteAuthor(int id)
        {
            _userService.TDelete(id);
            return RedirectToAction("AuthorIndex");
        }
        [Route("ChangeIsApprovedAuthor/{id:int}")]
        public IActionResult ChangeIsApprovedAuthor(int id)
        {
            _userService.TChangeIsApprovedArticleById(id);
            return RedirectToAction("AuthorIndex");
        }
        [Route("UpdateAuthor/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAuthor(int id)
        {

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            ViewBag.commentscount = _userService.TGetCommentsCountByAuthor(id);
            ViewBag.articlecount = _userService.TGetArticleCountByAuthor(id);
            return View(user);
        }

        [Route("UpdateAuthor/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(AppUser user, IFormFile Image)
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

            try
            {
                var dbUser = await _userManager.FindByIdAsync(user.Id.ToString());
                if (dbUser == null)
                {
                    return NotFound();
                }

                dbUser.Name = user.Name;
                dbUser.Surname = user.Surname;
                dbUser.City = user.City;
                dbUser.IsApproved = user.IsApproved;
                dbUser.Profession = user.Profession;
                dbUser.Email = user.Email;
                dbUser.AppRoleId = user.AppRoleId;
                dbUser.About = user.About;

                // Eğer gönderilen UserName boşsa, mevcut dbUser.UserName değerini kullan
                if (string.IsNullOrWhiteSpace(user.UserName))
                {
                    user.UserName = dbUser.UserName;
                }

                // Kullanıcı adı kontrolü ve güncellemesi
                if (!string.IsNullOrWhiteSpace(user.UserName) && user.UserName != dbUser.UserName)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(user.UserName, @"^[a-zA-Z0-9]+$"))
                    {
                        dbUser.UserName = user.UserName.Trim().Replace(" ", "_");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Kullanıcı adı sadece harfler veya rakamlar içerebilir.");
                        ViewBag.commentscount = _userService.TGetCommentsCountByAuthor(user.Id);
                        ViewBag.articlecount = _userService.TGetArticleCountByAuthor(user.Id);
                        return View(user);
                    }
                }

                dbUser.ImageUrl = user.ImageUrl;
                dbUser.SecurityStamp = Guid.NewGuid().ToString();

                var result = await _userManager.UpdateAsync(dbUser);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    ViewBag.commentscount = _userService.TGetCommentsCountByAuthor(user.Id);
                    ViewBag.articlecount = _userService.TGetArticleCountByAuthor(user.Id);
                    return View(user);
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var dbUser = await _userManager.FindByIdAsync(user.Id.ToString());
                if (dbUser == null)
                {
                    return NotFound();
                }

                ModelState.AddModelError(string.Empty, "Error");
                ViewBag.commentscount = _userService.TGetCommentsCountByAuthor(user.Id);
                ViewBag.articlecount = _userService.TGetArticleCountByAuthor(user.Id);
                return View(user);
            }

            return RedirectToAction("AuthorIndex");
        }


    }
}