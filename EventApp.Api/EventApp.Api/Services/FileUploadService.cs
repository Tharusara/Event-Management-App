using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EventApp.Api.Models;

namespace EventApp.Api.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IConfiguration _configuration;
        public FileUploadService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public IList<Photo> UploadFiles(IList<IFormFile> files)
        {
            var images = new List<Photo>();
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        var fileExtension = Path.GetExtension(fileName);
                        var folder = _configuration.GetSection("FileStore:Images").Value;
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);
                        var projectDir = _configuration.GetValue<string>(WebHostDefaults.ContentRootKey);

                        var filepath = Path.Combine(projectDir, folder, newFileName);

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }

                        images.Add(new Photo
                        {
                            Filename = Path.Combine("https://localhost:44342/" + folder, newFileName)
                        });

                    }
                }
            }
            return images;
        }

        public IList<string> GetPhysicalPathFromRelativeUrl(IList<string> urls)
        {
            var physicalPaths = new List<string>();
            var folder = _configuration.GetSection("FileStore:Images").Value;
            var projectDir = _configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
            urls.ToList().ForEach(u =>
            {
                physicalPaths.Add(Path.Combine(projectDir, folder, u.TrimStart('/').Replace("/", "\\")));
            });

            return physicalPaths;
        }

        public void RemoveExistingImagesFromStorage(List<Photo> photos)
        {
            photos.ForEach(p =>
            {
                DeleteFile(p.Filename);
            });
        }

        private void DeleteFile(string filePath)
        {
            var projectDir = _configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
            var fullPath = Path.Combine(projectDir, filePath);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}
