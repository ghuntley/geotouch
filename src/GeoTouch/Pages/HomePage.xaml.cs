using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;

using GeoTouch.Controls;
using GeoTouch.Models;
using GeoTouch.ViewModels;

using Splat;

using TwinTechs.Gestures;

using Xamarin.Forms;

namespace GeoTouch
{
    public partial class HomePage : ContentPage
    {
        private readonly IHomeViewModel ViewModel;

        public HomePage()
        {
            ViewModel = new HomeViewModel();

            InitializeComponent ();
            BindingContext = ViewModel;

            // https://bugzilla.xamarin.com/show_bug.cgi?id=30467
            Canvas.ProcessGestureRecognizers ();

            CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer, MotionSensorDelay.Game);
            CrossDeviceMotion.Current.SensorValueChanged += OnDeviceMotion;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Canvas.RemoveAllGestureRecognizers();
            CrossDeviceMotion.Current.Stop(MotionSensorType.Accelerometer);
        }

        // TODO: Resolve async void
        private async void OnCanvasTap(TwinTechs.Gestures.BaseGestureRecognizer recognizer, TwinTechs.Gestures.GestureRecognizerState state)
        {
            var tapRecognizer = recognizer as TwinTechs.Gestures.TapGestureRecognizer;
            var view = recognizer.View;

            var positionInView = recognizer.LocationInView (view);
            var positionInParentView = recognizer.LocationInView (view.ParentView);

            var shapeViewModel = await ViewModel.GenerateRandomShapeAsync ();
            var shapeView = new ShapeView () {
                BindingContext = shapeViewModel
            };

            shapeView.SetBinding (ShapeView.ColorProperty, "Color");
            shapeView.SetBinding (ShapeView.ImageUrlProperty, "ImageUrl");
            shapeView.SetBinding (ShapeView.ShapeProperty, "Shape");
            shapeView.SetBinding (ShapeView.TitleProperty, "Title");
            shapeView.SetBinding (ShapeView.OnDoubleTapProperty, "RefreshShape");

            AbsoluteLayout.SetLayoutFlags (shapeView,
                AbsoluteLayoutFlags.None);

            AbsoluteLayout.SetLayoutBounds (shapeView,
                new Rectangle (x: positionInView.X, y: positionInView.Y, height: 200f, width: 50f));

            Canvas.Children.Add (shapeView);
            //						ViewModel.PlaceShape(new PointF(sender.X);
        }

        private void OnDeviceMotion(object sender, DeviceMotion.Plugin.Abstractions.SensorValueChangedEventArgs e)
        {
            switch(e.SensorType){
                case MotionSensorType.Accelerometer:
                    var motion = (MotionVector)sender;

            //                    Debug.WriteLine("A: {0},{1},{2}",((MotionVector)a.Value).X,((MotionVector)a.Value).Y,((MotionVector)a.Value).Z);
                    break;
                case MotionSensorType.Compass:
            //                    Debug.WriteLine("H: {0}",a.Value);
                    break;
            }
        }
    }
}