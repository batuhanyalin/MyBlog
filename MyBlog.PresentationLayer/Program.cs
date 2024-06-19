using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.BusinessLayer.Concrete;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.EntityFramework;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Infastructure;
using MyBlog.PresentationLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DEPENDENCY INJECTIONIN GEÇERLÝ OLABÝLMESÝ ÝÇÝN DIÞARIDAN DAHÝL EDÝLECEK ALANLAR BU ÞEKÝLDE GÖSTERÝLÝYOR, ENJEKTE EDÝLÝYOR.
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EFCategoryDal>();

builder.Services.AddScoped<IArticleService, ArticleManager>();
builder.Services.AddScoped<IArticleDal, EFArticleDal>();

builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EFSocialMediaDal>();

builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentDal, EFCommetDal>();

builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EFAboutDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EFContactDal>();

builder.Services.AddScoped<IAppUserService, AppUserManager>();
builder.Services.AddScoped<IAppUserDal, EFAppUserDal>();


builder.Services.AddScoped<IArticleTagService, ArticleTagManager>();
builder.Services.AddScoped<IArticleTagDal,EFArticleTagDal>();

//Burada da DbContext olarak BlogContexti bildiriyoruz.
builder.Services.AddDbContext<BlogContext>();
//Burada identity projeye tanýtýlýp ilgili sýnýflar gösteriliyor ve AddEntityFrameworkStores la çalýþýlan context sýnýfý yazýlýyor.
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BlogContext>().AddErrorDescriber<CustomIdentityValidator>();
//EntityFrameworkStores metodu identitynin hangi contexten geldiðini belirtir.

//Arealarda viewcomponent kullanýmý
builder.Services.AddControllersWithViews().AddRazorOptions(options =>
{
    options.ViewLocationExpanders.Add(new CustomViewLocationExpander());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

////Authentication
//var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
//builder.Services.AddControllersWithViews(opt =>
//{
//    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
//});
//builder.Services.ConfigureApplicationCookie(opts =>
//{
//    opts.LoginPath = "/Login/Index";
//    opts.AccessDeniedPath = new PathString("/Login/AccessDeniedPath");
//});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); //Login iþlemi için verilen registration. Middleware olarak geliyor, yönlendirme saðlar.

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

//Projede area kullanýldýðýný belirtiyoruz.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
