using System;

using Xamarin.Forms;

namespace TwinTechs.Gestures
{
    public interface INativePanGestureRecognizer : INativeGestureRecognizer
    {
        Point GetTranslationInView(VisualElement view);

        Point GetVelocityInView(VisualElement view);

        void SetTranslationInView(Point translation, VisualElement view);
    }

    public class PanGestureRecognizer : BaseGestureRecognizer
    {
        public PanGestureRecognizer()
        {
            MinimumNumberOfTouches = 1;
            MaximumNumberOfTouches = 1;
        }

        public int MaximumNumberOfTouches
        {
            get; set;
        }

        public int MinimumNumberOfTouches
        {
            get; set;
        }

        public Point GetTranslationInView(VisualElement view)
        {
            return (NativeGestureRecognizer as INativePanGestureRecognizer).GetTranslationInView (view);
        }

        public Point GetVelocityInView(VisualElement view)
        {
            return (NativeGestureRecognizer as INativePanGestureRecognizer).GetVelocityInView (view);
        }

        public void SetTranslationInView(Point translation, VisualElement view)
        {
            (NativeGestureRecognizer as INativePanGestureRecognizer).SetTranslationInView (translation, view);
        }

        public override string ToString()
        {
            return string.Format ("[PanGestureRecognizer: MinimumNumberOfTouches={0}, MaximumNumberOfTouches={1}, State={2}]", MinimumNumberOfTouches, MaximumNumberOfTouches, State);
        }
    }
}