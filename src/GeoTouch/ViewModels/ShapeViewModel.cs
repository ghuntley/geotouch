using System;
using System.Windows.Input;

using GeoTouch.Models;

using PropertyChanged;

using Splat;

using Xamarin.Forms;

namespace GeoTouch.ViewModels
{
    [ImplementPropertyChanged]
    public class ShapeViewModel
    {
        public Color Color
        {
            get; set;
        }

        public Rectangle Dimensions
        {
            get; set;
        }

        public string ImageUrl
        {
            get; set;
        }

        public Point Position
        {
            get; set;
        }

        public ICommand RefreshShape
        {
            get; private set;
        }

        public Shape Shape
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }
    }
}