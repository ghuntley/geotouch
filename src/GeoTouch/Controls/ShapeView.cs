using System;
using System.Windows.Input;

using GeoTouch.Models;

using Xamarin.Forms;

namespace GeoTouch.Controls
{
    public class ShapeView : BoxView
    {
        public static readonly BindableProperty DimensionsProperty = BindableProperty.Create<ShapeView, Rectangle> (s => s.Dimensions, Rectangle.Zero);
        public static readonly BindableProperty ImageUrlProperty = BindableProperty.Create<ShapeView, string> (s => s.ImageUrl, string.Empty);
        public static readonly BindableProperty OnDoubleTapProperty = BindableProperty.Create<ShapeView, ICommand> (s => s.OnDoubleTap, null);
        public static readonly BindableProperty PositionProperty = BindableProperty.Create<ShapeView, Point> (s => s.Position, Point.Zero);
        public static readonly BindableProperty ShapeProperty = BindableProperty.Create<ShapeView, Shape> (s => s.Shape, Shape.Square);
        public static readonly BindableProperty TitleProperty = BindableProperty.Create<ShapeView, string> (s => s.Title, string.Empty);

        public ShapeView()
        {
        }

        public Rectangle Dimensions
        {
            get{ return (Rectangle)GetValue (DimensionsProperty); }
            set{ SetValue (DimensionsProperty, value); }
        }

        public string ImageUrl
        {
            get{ return (String)GetValue (ImageUrlProperty); }
            set{ SetValue (ImageUrlProperty, value); }
        }

        public ICommand OnDoubleTap
        {
            get{ return (ICommand)GetValue (OnDoubleTapProperty); }
            set{ SetValue (OnDoubleTapProperty, value); }
        }

        public Point Position
        {
            get{ return (Point)GetValue (PositionProperty); }
            set{ SetValue (PositionProperty, value); }
        }

        public Shape Shape
        {
            get{ return (Shape)GetValue (ShapeProperty); }
            set{ SetValue (ShapeProperty, value); }
        }

        public string Title
        {
            get{ return (String)GetValue (TitleProperty); }
            set{ SetValue (TitleProperty, value); }
        }
    }
}