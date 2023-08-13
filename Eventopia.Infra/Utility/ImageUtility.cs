using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Infra.Utility
{
	public static class ImageUtility
	{
		public static string StoreImage(IFormFile? file, string imageFolderName)
		{
			if (file == null || file.Length == 0)
				throw new ArgumentException("Invalid file.", nameof(file));

			var fileExtension = Path.GetExtension(file.FileName);
			var fileName = file.FileName.Length >= 30 ? file.FileName.Substring(0, 30) : file.FileName;
			fileName = $"{Guid.NewGuid()}_{fileName}{fileExtension}";
			var imageFolderPath = Path.Combine("Assets", "Images", imageFolderName);
			var fullPath = Path.Combine(imageFolderPath, fileName);

			if (!Directory.Exists(imageFolderPath))
				Directory.CreateDirectory(imageFolderPath);

			using (var stream = new FileStream(fullPath, FileMode.Create))
			{
				file.CopyTo(stream);
			}

			return fileName;
		}

		public static void DeleteImage(string fileName, string imageFolderName)
		{
			if (string.IsNullOrEmpty(fileName))
				return;
				//throw new ArgumentException("Invalid file name.", nameof(fileName));

			var imageFolderPath = Path.Combine("Assets", "Images", imageFolderName);
			var fullPath = Path.Combine(imageFolderPath, fileName);

			if (File.Exists(fullPath))
				File.Delete(fullPath);
		}

		public static string ReplaceImage(string oldFileName, IFormFile? newFile, string imageFolderName)
		{
			if (string.IsNullOrEmpty(oldFileName))
				throw new ArgumentException("Invalid file name.", nameof(oldFileName));
			if (newFile == null || newFile.Length == 0)
				throw new ArgumentException("Invalid file.", nameof(newFile));

			DeleteImage(oldFileName, imageFolderName);

			return StoreImage(newFile, imageFolderName);
		}

		public static string? RetrieveImage(string imageFileName, string imageFolderName)
		{
			if (string.IsNullOrEmpty(imageFileName))
			{
				return null;
			}

			var imageFolderPath = Path.Combine("Assets", "Images", imageFolderName);
			var fullPath = Path.Combine(imageFolderPath, imageFileName);

            if (!File.Exists(fullPath))
			{
				return null;
			}

			string base64String = Convert.ToBase64String(File.ReadAllBytes(fullPath));
			return base64String;
		}

		public static bool IsImageContentType(string contentType)
		{
			var allowedContentTypes = new string[]
			{
				"image/jpeg",
				"image/jpg",
				"image/png",
				"image/gif",
				"image/bmp",
				"image/tiff",
				"image/webp",
				"image/svg+xml",
				"image/x-icon",
				"image/vnd.adobe.photoshop",
				"image/x-ms-bmp",
				"image/heic",
				"image/heif"
			};

			return allowedContentTypes.Contains(contentType);
		}
	}
}
