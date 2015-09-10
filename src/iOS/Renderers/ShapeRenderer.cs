using System;
using System.Drawing;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;

using CoreGraphics;
using UIKit;

using GeoTouch;
using GeoTouch.Views;
using GeoTouch.iOS;


[assembly:ExportRenderer (typeof(ShapeView), typeof(ShapeRenderer))]
namespace GeoTouch.iOS
{
	public class ShapeRenderer :  VisualElementRenderer<ShapeView>
	{
		public ShapeRenderer ()
		{
		}

		public override void Draw (CGRect rect)
		{
			var currentContext = UIGraphics.GetCurrentContext();
			HandleShapeDraw (currentContext);
		}

		protected virtual void HandleShapeDraw (CGContext currentContext)
		{
		}
	}
}

