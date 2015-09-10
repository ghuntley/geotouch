using System;
using Android.Views;
using Android.Graphics;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.Util;

using GeoTouch.Controls;

namespace GeoTouch.Droid
{
	public class Shape : View
	{
		public Shape ()
		{
		}

		public ShapeView ShapeView{ get; set; }

		protected override void OnDraw (Canvas canvas)
		{
			base.OnDraw (canvas);
			HandleShapeDraw (canvas);
		}

		protected virtual void HandleShapeDraw (Canvas canvas)
		{
		}
	}
}

