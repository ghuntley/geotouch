using System;

using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;

using GeoTouch.Controls;

using Xamarin.Forms.Platform.Android;

namespace GeoTouch.Droid
{
    public class Shape : View
    {
        public Shape()
        {
        }

        public ShapeView ShapeView
        {
            get; set;
        }

        protected virtual void HandleShapeDraw(Canvas canvas)
        {
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw (canvas);
            HandleShapeDraw (canvas);
        }
    }
}