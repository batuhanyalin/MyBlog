﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.Dto
{
    public class CategoryBlogCountChartDto
    {
        public string CategoryName { get; set; }
        public int BlogCount { get; set; }
    }
}
