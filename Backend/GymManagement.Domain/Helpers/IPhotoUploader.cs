using Microsoft.AspNetCore.Http;

namespace GymManagement.Domain.Helpers
{
    public interface IPhotoUploader
    {
        string UploadPhoto(IFormFile file, string fileUploadDirectory);
    }
}