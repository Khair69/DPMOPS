
namespace DPMOPS.Services.Photo
{
    public class PhotoUploadService : IPhotoUploadService
    {
        private readonly IWebHostEnvironment _env;

        public PhotoUploadService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> UploadAsync(IFormFile photo)
        {
            if (photo == null || photo.Length < 0)
            {
                throw new ArgumentNullException(nameof(photo));
            }
            var extension = Path.GetExtension(photo.FileName).ToLowerInvariant();
            var allowedExt = new[] { ".jpg", ".jpeg", ".png" };
            var allowedMime = new[] { "image/jpeg", "image/png" };

            if (!allowedExt.Contains(extension) || !allowedMime.Contains(photo.ContentType))
                throw new InvalidOperationException("Invalid file type.");

            if (photo.Length > 2 * 1024 * 1024)
                throw new InvalidOperationException("File too large.");

            var fileName = $"{Guid.NewGuid()}{extension}";
            var relativePath = Path.Combine("uploads", fileName);
            var absolutePath = Path.Combine(_env.WebRootPath, relativePath);

            Directory.CreateDirectory(Path.GetDirectoryName(absolutePath)!);


            using var stream = new FileStream(absolutePath, FileMode.Create);
            await photo.CopyToAsync(stream);


            return "/" + relativePath.Replace("\\", "/");
        }

        public void DeletePhoto(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath)) return;

            var fullPath = Path.Combine(_env.WebRootPath, relativePath.TrimStart('/'));
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}
