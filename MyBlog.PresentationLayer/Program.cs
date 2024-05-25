using MyBlog.BusinessLayer.Abstract;
using MyBlog.BusinessLayer.Concrete;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.EntityFramework;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DEPENDENCY INJECTIONIN GEÇERLÝ OLABÝLMESÝ ÝÇÝN DIÞARIDAN DAHÝL EDÝLECEK ALANLAR BU ÞEKÝLDE GÖSTERÝLÝYOR, ENJEKTE EDÝLÝYOR.
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EFCategoryDal>();

builder.Services.AddScoped<IArticleService, ArticleManager>();
builder.Services.AddScoped<IArticleDal, EFArticleDal>();

builder.Services.AddScoped<ISocialMediaService,SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EFSocialMediaDal>();
//Burada da DbContext olarak BlogContexti bildiriyoruz.
builder.Services.AddDbContext<BlogContext>();
//Burada identity projeye tanýtýlýp ilgili sýnýflar gösteriliyor ve AddEntityFrameworkStores la çalýþýlan context sýnýfý yazýlýyor.
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BlogContext>().AddErrorDescriber<CustomIdentityValidator>();
//EntityFrameworkStores metodu identitynin hangi contexten geldiðini belirtir.


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
