using System;
using Splat;
using System.Collections.Generic;

using Xamarin.Forms;

using GeoTouch.Controls;
using GeoTouch.ViewModels;

namespace GeoTouch
{
	public partial class HomePage : ContentPage
	{
		private readonly IHomeViewModel ViewModel;

		public HomePage ()
		{
			ViewModel = new HomeViewModel();

			InitializeComponent ();
			BindingContext = ViewModel;

			FrameTapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped;
		}

		public void OnTapGestureRecognizerTapped(object sender, EventArgs args)
		{

			var shape = new ShapeView ();
				
			AbsoluteLayout.SetLayoutFlags (shape,
				AbsoluteLayoutFlags.None);

			AbsoluteLayout.SetLayoutBounds (shape,
				new Rectangle (100f, 200f, 200f, 50f));

			Canvas.Children.Add (shape);
			//			ViewModel.PlaceShape(new PointF(sender.X);
		}
	}
}

