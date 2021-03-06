﻿using System;
using System.ComponentModel;
using System.Drawing;

using CoreGraphics;

using GeoTouch;
using GeoTouch.Controls;
using GeoTouch.iOS;
using GeoTouch.Models;
using GeoTouch.Services;

using Splat;

using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ShapeView), typeof(ShapeRenderer))]

namespace GeoTouch.iOS
{
    public class ShapeRenderer : ViewRenderer
    {
        public ShapeRenderer()
        {
        }

        public override void Draw(CGRect rect)
        {
            HandleDraw (rect);
        }

        public void HandleDraw(CGRect rect)
        {
            var shapeView = (ShapeView)Element;

            if (shapeView.Shape == Shape.Circle) {
                using (var context = UIGraphics.GetCurrentContext ()) {
                    var path = CGPath.EllipseFromRect (rect);
                    context.AddPath (path);
                    context.SetFillColor (shapeView.Color.ToCGColor ());
                    context.DrawPath (CGPathDrawingMode.Fill);
                }

                return;
            }

            if (shapeView.Shape == Shape.Square) {
                using (var context = UIGraphics.GetCurrentContext ()) {
                    var path = CGPath.FromRect(rect);
                    context.AddPath (path);
                    context.SetFillColor (shapeView.Color.ToCGColor ());
                    context.DrawPath (CGPathDrawingMode.Fill);
                }

                return;
            }

            throw new InvalidOperationException ("Element is a invalid shape, aborting");
        }

        // can access shape via this.
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged (e);
        }

        // fired every time the property binding changes.
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
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
    }
}