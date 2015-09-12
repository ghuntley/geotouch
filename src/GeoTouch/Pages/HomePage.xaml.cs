using System;
using Splat;
using System.Collections.Generic;

using Xamarin.Forms;

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

			var label = new Label {
				Text = "Hello World",
				TextColor = Color.Black
			};

			AbsoluteLayout.SetLayoutFlags (label,
				AbsoluteLayoutFlags.None);

			AbsoluteLayout.SetLayoutBounds (label,
				new Rectangle (100f, 200f, 200f, 50f));


			Canvas.Children.Add (label);
			//			ViewModel.PlaceShape(new PointF(sender.X);
		}
	}
}

