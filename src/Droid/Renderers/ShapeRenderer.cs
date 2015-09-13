using System;

using Android.Graphics;
using Android.Views;

using GeoTouch;
using GeoTouch.Controls;
using GeoTouch.Droid;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ShapeView), typeof(ShapeRenderer))]

namespace GeoTouch.Droid
{
    public class ShapeRenderer : ViewRenderer<ShapeView, Shape>
    {
        public ShapeRenderer()
        {
        }

        //        protected override void OnElementChanged (ElementChangedEventArgs<ShapeView> e)
        //        {
        //            base.OnElementChanged (e);
        //
        //            if (e.OldElement != null || this.Element == null)
        //                return;
        //
        //            SetNativeControl (new Shape (Resources.DisplayMetrics.Density, Context) {
        //                ShapeView = Element
        //            });
        //        }
    }
}