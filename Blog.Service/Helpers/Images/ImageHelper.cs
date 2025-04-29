using Blog.Entity.DTOs.Images;
using Blog.Entity.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Helpers.Images
{
    public class ImageHelper : IImageHelper
    {
        
        private readonly string wwwroot;
        private readonly IWebHostEnvironment env;
        private const string imgFolder = "images";
        private const string articleImagesFolder = "article-images";
        private const string UsersImagesFolder = "user-images";

        public ImageHelper(IWebHostEnvironment env)
        {        
            this.env = env;

            wwwroot = env.WebRootPath;

        }

        private string ReplaceInvalidChars(string fileName)
        {
            return fileName.Replace("�", "I")
                 .Replace("�", "i")
                 .Replace("�", "G")
                 .Replace("�", "g")
                 .Replace("�", "U")
                 .Replace("�", "u")
                 .Replace("�", "s")
                 .Replace("�", "S")
                 .Replace("�", "O")
                 .Replace("�", "o")
                 .Replace("�", "C")
                 .Replace("�", "c")
                 .Replace("�", "")
                 .Replace("!", "")
                 .Replace("'", "")
                 .Replace("^", "")
                 .Replace("+", "")
                 .Replace("%", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "")
                 .Replace("=", "")
                 .Replace("?", "")
                 .Replace("_", "")
                 .Replace("*", "")
                 .Replace("�", "")
                 .Replace("�", "")
                 .Replace("@", "")
                 .Replace("�", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("�", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("�", "")
                 .Replace(",", "")
                 .Replace(";", "")
                 .Replace("`", "")
                 .Replace(".", "")
                 .Replace(":", "")
                 .Replace(" ", "");
        }

        

        public async Task<ImageUploadedDto> Upload(string name, IFormFile imageFile,ImageType imageType, string folderName = null)
        {
            folderName ??= imageType == ImageType.User ? UsersImagesFolder : articleImagesFolder;

            if (!Directory.Exists($"{wwwroot}/{imgFolder}/{folderName}")) ;
            {
                Directory.CreateDirectory($"{wwwroot}/{imgFolder}/{folderName}");
            }
            string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string fileExtension = Path.GetExtension(imageFile.FileName);

            name = ReplaceInvalidChars(name);

            DateTime dateTime = DateTime.Now;

            string newFileName = $"{name}_{dateTime:yyyyMMddHHmmss}{fileExtension}";

            var path = Path.Combine($"{wwwroot}/{imgFolder}/{folderName}", newFileName);

            await using var stream = new FileStream(path,FileMode.Create, FileAccess.Write,FileShare.None, 1024 * 1024 , useAsync: false);
            await imageFile.CopyToAsync(stream);

            await stream.FlushAsync();

            string message= imageType == ImageType.User 
                ? $"{newFileName} isimli kullan�c� resmi ba�ar� iley�klendi" 
                : $"{newFileName} isimli makale resmi ba�ar� ile y�klendi";
            return new ImageUploadedDto
            {
                FullName = $"{folderName}/{newFileName}"
            };
        }

        public void Delete(string imageName)
        {
            var fileToDelete = Path.Combine($"{wwwroot}/{imgFolder}/{
                imageName}");
            if (File.Exists(fileToDelete))
            
                File.Delete(fileToDelete);

         
        }

        }
    }

