using System;
using System.IO;
using System.Linq;

namespace K9.SharedLibrary.Extensions
{
	public static class IoExtensions
	{

		public static string GetFileNameWithoutExtension(this FileInfo fileInfo)
		{
			var fileName = fileInfo.Name;
			return fileName.Substring(0, fileName.LastIndexOf(".", StringComparison.Ordinal));
		}

		public static string ToPathOnDisk(this string value)
		{
			return value.Replace("/", "\\");
		}

		public static string GetFileSize(this FileInfo fileInfo)
		{
			string[] sizes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
			var order = 0;
			var length = fileInfo.Length;
			while (length >= 1024 && order < sizes.Length - 1)
			{
				order++;
				length = length / 1024;
			}
			return $"{length:0.0##} {sizes[order]}";
		}

		public static string GetFileExtension(this string fileName)
		{
			return $".{fileName.Split('.').Last()}";
		}
	}
}
