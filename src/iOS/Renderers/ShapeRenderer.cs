using System;
using System.Drawing;
using System.ComponentModel;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;

using CoreGraphics;
using UIKit;

using Splat;
using GeoTouch;
using GeoTouch.Controls;
using GeoTouch.iOS;


[assembly:ExportRenderer (typeof(ShapeView), typeof(ShapeRenderer))]
namespace GeoTouch.iOS
{
	public class ShapeRenderer :  ViewRenderer
	{
		private IRandomColourService _randomColourService;

		public ShapeRenderer ()
		{
			_randomColourService = Locator.Current.GetService<IRandomColourService> ();
		}

		// can access shape via this.
		protected override void OnElementChanged (ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged (e.NewElement);
		}

		// fired every time the property binding changes.
		protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (Control == null || Element == null)
				return;
		}

		public override void Draw (CGRect rect)
		{
			using (var context = UIGraphics.GetCurrentContext ()) {
				var path = CGPath.EllipseFromRect (rect);
				context.AddPath (path);
				context.SetFillColor (_randomColourService.GenerateRandomColour ().ToCGColor ());
				context.DrawPath (CGPathDrawingMode.Fill);
			}
		}
	}
}

