﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Contract.Article
{
    public class ArticleDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
    }

}
