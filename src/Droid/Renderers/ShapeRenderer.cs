using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using GeoTouch;
using GeoTouch.Droid;
using GeoTouch.Controls;
using Android.Views;
using Android.Graphics;

[assembly:ExportRenderer (typeof(ShapeView), typeof(ShapeRenderer))]
namespace GeoTouch.Droid
{
	public class ShapeRenderer : ViewRenderer<ShapeView, Shape>
	{
		public ShapeRenderer ()
		{
		}

//		protected override void OnElementChanged (ElementChangedEventArgs<ShapeView> e)
//		{
//			base.OnElementChanged (e);
//
//			if (e.OldElement != null || this.Element == null)
//				return;
//
//			SetNativeControl (new Shape (Resources.DisplayMetrics.Density, Context) {
//				ShapeView = Element
//			});
//		}
	}
}