using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ChaineTV_NICOLAS_TURECK
{
    class ValueToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Permet de Convertir en visible un élément en fonction d'un autre élément => non-null = visible / => null = collapsed
        /// </summary>
        /// <param name="value">élément qui va déterminer de la visibilité en étant null ou non</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>La visibilité visible si value est non null et collapsed si value est null</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Fait le tu connais mieux que moi
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
