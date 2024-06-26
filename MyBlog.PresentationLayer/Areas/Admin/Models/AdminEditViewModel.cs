﻿namespace MyBlog.PresentationLayer.Areas.Admin.Models
{
    public class AdminEditViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Profession { get; set; }
        public string About { get; set; }
        public IFormFile Image { get; set; } //Dosya isteği oluşturan bir interface türünde proporty oluşturuyoruz. Bunu kullanıcı profil fotoğrafını kaydetmek için tutacağız.
    }
}
