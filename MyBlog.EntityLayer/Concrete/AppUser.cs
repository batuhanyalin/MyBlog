﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int> //Bu şekilde kullanıldığında SQLe yansıyan User sınıfındaki id değeri int değere dönüşür.
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? City { get; set; }
        public string? ImageUrl { get; set; }
        public List<Article> Articles { get; set; }
    }
}