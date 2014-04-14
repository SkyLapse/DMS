using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Docular.Client.Windows
{
    /// <summary>
    /// Supports conversion between a <see cref="Color"/> and a <see cref="SolidColorBrush"/>.
    /// </summary>
    public class SolidColorBrushToColorConverter : IValueConverter
    {
        /// <summary>
        /// Performs the conversion.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The <see cref="Type"/> to convert to.</param>
        /// <param name="parameter">A conversion parameter.</param>
        /// <param name="culture">The current <see cref="System.Globalization.CultureInfo"/>.</param>
        /// <returns>The converted object.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                if (targetType == typeof(SolidColorBrush))
                {
                    return new SolidColorBrush((Color)value);
                }
                else if (targetType == typeof(Color))
                {
                    return ((SolidColorBrush)value).Color;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs the conversion in reverse.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The <see cref="Type"/> to convert to.</param>
        /// <param name="parameter">A conversion parameter.</param>
        /// <param name="culture">The current <see cref="System.Globalization.CultureInfo"/>.</param>
        /// <returns>The converted object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                if (targetType == typeof(SolidColorBrush))
                {
                    return new SolidColorBrush((Color)value);
                }
                else if (targetType == typeof(Color))
                {
                    return ((SolidColorBrush)value).Color;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
