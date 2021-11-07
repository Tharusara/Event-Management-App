using EventApp.Api.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace EventApp.Api.Services
{
    public interface IFileUploadService
    {
        IList<Photo> UploadFiles(IList<IFormFile> files);
        IList<string> GetPhysicalPathFromRelativeUrl(IList<string> urls);
        void RemoveExistingImagesFromStorage(List<Photo> photos);
    }
}
