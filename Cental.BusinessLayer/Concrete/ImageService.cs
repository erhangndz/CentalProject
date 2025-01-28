using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class ImageService : IImageService
    {
        public async Task<string> SaveImageAsync(IFormFile file)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if(extension!= ".jpg" &&  extension!= ".jpeg" && extension!= ".png")
            {
                throw new Exception("Dosya Formatı Resim olmalıdır.");
            }

            var imageName = Guid.NewGuid() + extension;
            var saveLocation = Path.Combine(currentDirectory, imageName);
            var stream = new FileStream(saveLocation, FileMode.Create);
            await file.CopyToAsync(stream);
            return "/images/" + imageName;
        }
    }
}
