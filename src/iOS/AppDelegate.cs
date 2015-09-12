using System;
using System.Collections.Generic;
using System.Linq;

using Splat;
using TwinTechs;
using TwinTechs.Gestures;

using Foundation;
using UIKit;

namespace GeoTouch.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			// TODO: Move to Splat IoC
			GestureRecognizerExtensions.Factory = new NativeGestureRecognizerFactory ();
			Locator.CurrentMutable.RegisterConstant (new RandomColourService (), typeof(IRandomColourService));

			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

