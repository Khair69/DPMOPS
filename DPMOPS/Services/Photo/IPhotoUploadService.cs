namespace DPMOPS.Services.Photo
{
    public interface IPhotoUploadService
    {
        Task<string> UploadAsync(IFormFile photo);
        void DeletePhoto(string relativePath);
    }
}
