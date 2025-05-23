﻿using Blog.Core.Entities;
using Blog.Entity.Enums;

namespace Blog.Entity.Entities
{
    public class Image : EntityBase
    {
        public Image()
        {
            

        }


        public Image(string fileName, string fileType, string createdBy)
        {
            FileName = fileName;
            FileType = fileType;

        }

        public string FileName { get; set; }

        public string FileType { get; set; }
           

        public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
