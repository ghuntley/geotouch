using System;

using CoreImage;

using Foundation;

using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace TwinTechs.Gestures
{
    public class NativeSwipeGestureRecognizer : BaseNativeGestureRecognizer<UISwipeGestureRecognizer,SwipeGestureRecognizer>
    {
        public NativeSwipeGestureRecognizer()
        {
        }

        protected override void ConfigureNativeGestureRecognizer()
        {
            base.ConfigureNativeGestureRecognizer ();
            NativeRecognizer.Direction = (UISwipeGestureRecognizerDirection)Recognizer.Direction;
            NativeRecognizer.NumberOfTouchesRequired = (nuint)Recognizer.NumberOfTouchesRequired;
        }
    }
}