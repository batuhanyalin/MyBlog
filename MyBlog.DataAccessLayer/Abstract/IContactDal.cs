﻿using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.Abstract
{
    public interface IContactDal:IGenericDal<Contact>
    {
        public Contact ChangeIsReadContact(int id);
    }
}
