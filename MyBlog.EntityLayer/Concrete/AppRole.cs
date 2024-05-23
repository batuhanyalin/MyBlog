using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.EntityLayer.Concrete
{
    public class AppRole:IdentityRole<int> //Role tablosu BlogContext sınıfındaki miras alınan bölümde bütünlüğü korumak için oluşturuluyor.
    {
        public string? RoleDetail { get; set; }
    }
}
