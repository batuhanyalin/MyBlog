﻿using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
    public interface INotificationService:IGenericService<Notification>
    {
        public Notification TChangeIsStatusNotification(int id);
        public List<Notification> TGetListNotificationOrderByDescendingDate();
    }
}
