﻿using System;
using Trinity.Framework;
using Trinity.Framework.Helpers;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Trinity.UI.UIComponents.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = value as string;

            if (string.IsNullOrEmpty(path))
                path = (string)parameter;

            if (string.IsNullOrEmpty(path))
                return Binding.DoNothing;
            
            try
            {
                var fullPath = Path.Combine(FileManager.UiPath, path);
                if(!File.Exists(fullPath))
                    Core.Logger.Log("ImagePathConverter: Requested Image file does not exist. Path={0}", fullPath);

                Core.Logger.Log("Loading Image: Path={0}", fullPath);
                var image = new BitmapImage(new Uri(fullPath));
                image.Freeze();
                return image;
            }
            catch (Exception)
            {
                return new BitmapImage();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
