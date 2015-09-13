﻿using System;
using System.Drawing;
using System.ComponentModel;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;

using CoreGraphics;
using UIKit;

using Splat;
using GeoTouch;
using GeoTouch.Services;
using GeoTouch.Controls;
using GeoTouch.iOS;


[assembly:ExportRenderer (typeof(ShapeView), typeof(ShapeRenderer))]
namespace GeoTouch.iOS
{
	public class ShapeRenderer :  ViewRenderer
	{

		public ShapeRenderer ()
		{
		}

		// can access shape via this.
		protected override void OnElementChanged (ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged (e);
		}

		// fired every time the property binding changes.
		protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (Control == null || Element == null) {
				return;
			}

			if (e.PropertyName == ShapeView.ColorProperty.PropertyName)
			{
			}

//			if (e.PropertyName == ShapeView.ImageUrlProperty.PropertyName)
//			{
//			}
//
//			if (e.PropertyName == ShapeView.TitleProperty.PropertyName)
//			{
//			}
		}

		public override void Draw (CGRect rect)
		{
			var shapeView = (ShapeView)Element;

			using (var context = UIGraphics.GetCurrentContext ()) {
				var path = CGPath.EllipseFromRect (rect);
				context.AddPath (path);
				context.SetFillColor (shapeView.Color.ToCGColor ());
				context.DrawPath (CGPathDrawingMode.Fill);
			}
		}
	}
}

