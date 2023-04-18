using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace ChaineTV_NICOLAS_TURECK
{
    class StringToImageConverter : IValueConverter
    {
        /// <summary>
        /// Chemin vers l'image à convertir et copier
        /// </summary>
        private static string imagesPath;

        static StringToImageConverter()
        {
            imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\img\\");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageName = value as string;

            if (string.IsNullOrWhiteSpace(imagesPath)) return null;

            string imagePath = Path.Combine(imagesPath, imageName);

            return new Uri(imagePath, UriKind.RelativeOrAbsolute);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
