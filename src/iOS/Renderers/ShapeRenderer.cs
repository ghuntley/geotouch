using System;
using System.Drawing;
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
			this.BackgroundColor = _randomColourService.GenerateRandomColour().ToUIColor();
		}

//		public override void Draw (CGRect rect)
//		{
//			var currentContext = UIGraphics.GetCurrentContext();
//			HandleShapeDraw (currentContext);
//		}
//
//		protected virtual void HandleShapeDraw (CGContext currentContext)
//		{
//			currentContext.SetLineWidth (5);
//			currentContext.SetFillColor (Color.Red.ToCGColor());
//			currentContext.SetStrokeColor (Color.Black.ToCGColor());
//		}
	}
}

