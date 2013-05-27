﻿using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Coding4Fun.Toolkit.Controls.Common
{
    public static class ImageSourceExtensions
    {
		private const string IsoStoreScheme = "isostore:/";

        /// <summary>
        /// Gets the image from the URI. If the image starts with isostore:/ that it will get the image
        /// out of isolatedstorage, otherwise it will just use the URI as is.
        /// </summary>
        /// <param name="imageSource">The image source URI.</param>
        /// <returns>
        /// The image as a BitmapImage so it can be set against the Image item
        /// </returns>
		public static BitmapImage ToBitmapImage(this ImageSource imageSource)
        {
	        // If the imageSource is null, then there's nothing further to see here
            if (imageSource == null)
                return null;
            
			var checkedImageSource = imageSource as BitmapImage;

			if (checkedImageSource == null)
				return null;

			var imgSource = checkedImageSource.UriSource.ToString().ToLower();

            // If the imgSource is an isostore uri, then we need to pull it out of storage
			if (imgSource.StartsWith(IsoStoreScheme))
            {
				imgSource = imgSource.Replace(IsoStoreScheme, string.Empty).TrimEnd('.');

                checkedImageSource = new BitmapImage();

                if (!System.ComponentModel.DesignerProperties.IsInDesignTool)
                {
                    using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        if (isoStore.FileExists(imgSource))
                        {
                            using (var file = isoStore.OpenFile(imgSource, FileMode.Open))
                            {
                                 checkedImageSource.SetSource(file);
                            }
                        }
                    }
                }
            }

            return checkedImageSource;
        }
    }
}