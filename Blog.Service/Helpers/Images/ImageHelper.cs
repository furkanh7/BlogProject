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
            return fileName.Replace("Ý", "I")
                 .Replace("ý", "i")
                 .Replace("Ð", "G")
                 .Replace("ð", "g")
                 .Replace("Ü", "U")
                 .Replace("ü", "u")
                 .Replace("þ", "s")
                 .Replace("Þ", "S")
                 .Replace("Ö", "O")
                 .Replace("ö", "o")
                 .Replace("Ç", "C")
                 .Replace("ç", "c")
                 .Replace("é", "")
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
                 .Replace("æ", "")
                 .Replace("ß", "")
                 .Replace("@", "")
                 .Replace("€", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("½", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("¨", "")
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
                ? $"{newFileName} isimli kullanýcý resmi baþarý ileyüklendi" 
                : $"{newFileName} isimli makale resmi baþarý ile yüklendi";
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

