using System;
using System.Globalization;

using Xamarin.Forms;

namespace TwinTechs.Gestures.Converters
{
    public class SwipeGestureRecognizerDirectonConverter : IValueConverter
    {
        public SwipeGestureRecognizerDirectonConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var directionName = value as string;
            switch (directionName) {
            case "Left":
                return SwipeGestureRecognizerDirection.Left;
            case "Right":
                return SwipeGestureRecognizerDirection.Right;
            case "Up":
                return SwipeGestureRecognizerDirection.Up;
            case "Down":
                return SwipeGestureRecognizerDirection.Down;
            default:
                throw new ArgumentException ("unsupported direction " + directionName);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException ();
        }
    }
}