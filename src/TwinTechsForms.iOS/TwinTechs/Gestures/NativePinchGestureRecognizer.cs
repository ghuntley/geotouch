using System;

using UIKit;

using Xamarin.Forms;

namespace TwinTechs.Gestures
{
    public class NativePinchGestureRecognizer : BaseNativeGestureRecognizer<UIPinchGestureRecognizer,PinchGestureRecognizer>, INativePinchGestureRecognizer
    {
        public NativePinchGestureRecognizer()
        {
        }

        public Xamarin.Forms.Point GetTranslationInView(Xamarin.Forms.VisualElement view)
        {
            throw new NotImplementedException ();
        }

        public Xamarin.Forms.Point GetVelocityInView(Xamarin.Forms.VisualElement view)
        {
            throw new NotImplementedException ();
        }

        public float Scale()
        {
            return (float)NativeRecognizer.Scale;
        }

        public float Velocity()
        {
            return (float)NativeRecognizer.Velocity;
        }
    }
}