using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;

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

            var fileName = $"{Guid.NewGuid()}.jpg"; //save everything as .jpg
            var relativePath = Path.Combine("uploads", fileName);
            var absolutePath = Path.Combine(_env.WebRootPath, relativePath);

            Directory.CreateDirectory(Path.GetDirectoryName(absolutePath)!);


            using var stream = photo.OpenReadStream();
            using var image = await Image.LoadAsync(stream);

            //Crop to 4:3
            var aspectRatio = 4f / 3f;
            int targetWidth = image.Width;
            int targetHeight = (int)(targetWidth / aspectRatio);

            if (targetHeight > image.Height)
            {
                targetHeight = image.Height;
                targetWidth = (int)(targetHeight * aspectRatio);
            }

            var cropRectangle = new Rectangle(
                (image.Width - targetWidth) / 2,
                (image.Height - targetHeight) / 2,
                targetWidth,
                targetHeight
            );

            image.Mutate(x =>
            {
                x.Crop(cropRectangle);
                x.Resize(new ResizeOptions
                {
                    Size = new Size(800, 600), // Final size, 4:3
                    Mode = ResizeMode.Max
                });
            });

            //Compress as JPEG
            var encoder = new JpegEncoder
            {
                Quality = 75 // Adjust quality if needed
            };

            await image.SaveAsync(absolutePath, encoder);

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
