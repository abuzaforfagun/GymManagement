using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace GymManagement.Domain.Helpers
{
    public class PhotoUploader : IPhotoUploader
    {
        public string UploadPhoto(IFormFile file, string fileUploadDirectory)
        {
            try
            {
                if (!Directory.Exists(fileUploadDirectory))
                {
                    Directory.CreateDirectory(fileUploadDirectory);
                }
                if (file.Length > 0)
                {
                    string fileName = DateTime.Now.Ticks + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fileUploadPath = $"{fileUploadDirectory}/{fileName}";
                    using (var stream = new FileStream(fileUploadPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return fileUploadPath;
                }
            }
            catch (System.Exception ex)
            {
            }

            return string.Empty;
        }
    }
}
