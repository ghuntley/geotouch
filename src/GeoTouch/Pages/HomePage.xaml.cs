using System;
using Splat;
using System.Collections.Generic;
using Xamarin.Forms;

using TwinTechs.Gestures;
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

			// https://bugzilla.xamarin.com/show_bug.cgi?id=30467
			Canvas.ProcessGestureRecognizers ();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			Canvas.RemoveAllGestureRecognizers();
		}

		void OnCanvasTap (TwinTechs.Gestures.BaseGestureRecognizer recognizer, TwinTechs.Gestures.GestureRecognizerState state)
		{
			var tapRecognizer = recognizer as TwinTechs.Gestures.TapGestureRecognizer;
			var view = recognizer.View;

			var positionInView = recognizer.LocationInView (view);
			var positionInParentView = recognizer.LocationInView (view.ParentView);

			var shape = new ShapeView();
				
			AbsoluteLayout.SetLayoutFlags (shape,
				AbsoluteLayoutFlags.None);

			AbsoluteLayout.SetLayoutBounds (shape,
				new Rectangle (x: positionInView.X, y: positionInView.Y, height: 200f, width: 50f));

			Canvas.Children.Add (shape);
//						ViewModel.PlaceShape(new PointF(sender.X);


		}
	}
}

