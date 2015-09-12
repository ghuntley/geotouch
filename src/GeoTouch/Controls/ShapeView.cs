using System;
using Xamarin.Forms;
using GeoTouch.Models;

namespace GeoTouch.Controls
{
	public class ShapeView : BoxView
	{
		public static readonly BindableProperty ShapeProperty = BindableProperty.Create<ShapeView, Shape> (s => s.Shape, Shape.Square);

		public Shape Shape {
			get{ return (Shape)GetValue (ShapeProperty); }
			set{ SetValue (ShapeProperty, value); }
		}

		public ShapeView ()
		{
		}
	}
}

