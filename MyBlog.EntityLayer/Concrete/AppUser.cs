using Microsoft.AspNetCore.Identity;
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
        public string? About { get; set; }
        public string? Profession { get; set; }
        public List<Article> Articles { get; set; }
        //MVCde Virtual kullanılırken burada gerekmiyor. Burada LazyLoad ve EagerLoad kavramları öne çıkıyor. Bütün veriye değil sadece ihtiyaç duyulan verinin yüklenmesi amaçlanıyor. Include kavramı burada devreye girecek. 
        public List<Comment> Comments { get; set; }
        public string? InstagramUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public bool IsApproved { get; set; }
        public int? AppRoleId { get; set; }
        public AppRole AppRole { get; set; }

    }
}

