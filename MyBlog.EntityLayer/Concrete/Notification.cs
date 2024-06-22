using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.EntityLayer.Concrete
{
    public class Notification
    {
        public int Id { get; set; }
        public string NotificationName { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string IconColor { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }

    }
}
