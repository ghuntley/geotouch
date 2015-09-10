using System;
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

		}
	}
}

