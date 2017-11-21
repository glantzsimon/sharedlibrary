using K9.SharedLibrary.Helpers;
using System;
using System.IO;
using K9.SharedLibrary.Extensions;

namespace K9.SharedLibrary.Models
{
    public class AssetInfo : IAssetInfo
	{
		private readonly string _baseWebPath;

	    public AssetInfo(string pathOnDisk, string baseWebPath)
		{
			PathOnDisk = pathOnDisk;
			_baseWebPath = baseWebPath.EndsWith("/") ? baseWebPath.Remove(_baseWebPath.Length - 1) : baseWebPath;
			FileInfo = new FileInfo(PathOnDisk);
			ImageInfo = IsImage() ? ImageProcessor.GetImageInfo(PathOnDisk) : null;
		}

		public string PathOnDisk { get; }

	    public string FileName => FileInfo.Name;

	    public string ShortFileName => FileInfo.GetShortFileName();

        public string Src => $"/{_baseWebPath}/{FileName}";

	    public FileInfo FileInfo { get; }

	    public ImageInfo ImageInfo { get; }

	    public string Extension => FileInfo.Extension;

	    public bool IsImage()
		{
			return HelperMethods.GetImageFileExtensions().Contains(FileInfo.Extension.ToLower());
		}

	    public bool IsVideo()
	    {
	        return HelperMethods.GetVideoFileExtensions().Contains(FileInfo.Extension.ToLower());
	    }

	    public bool IsAudio()
	    {
	        return HelperMethods.GetAudioFileExtensions().Contains(FileInfo.Extension.ToLower());
	    }

        public bool IsTextFile()
		{
			return FileInfo.Extension.ToLower() == ".txt";
		}

		public string GetNameWithoutExtensions()
		{
			return FileName.Substring(0, FileName.LastIndexOf(".", StringComparison.Ordinal));
		}

	}
}
