using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GeoTouch.Services;
using Splat;
using TwinTechs.Gestures;

namespace GeoTouch.Droid
{
    [Activity(Label = "GeoTouch.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate (bundle);

            global::Xamarin.Forms.Forms.Init (this, bundle);

            GestureRecognizerExtensions.Factory = new NativeGestureRecognizerFactory();
            Locator.CurrentMutable.RegisterConstant(new RandomColorService(), typeof(IRandomColorService));
            Locator.CurrentMutable.RegisterConstant(new ColourLoversService(), typeof(IColourLoversService));

            LoadApplication(new App ());
        }
    }
}