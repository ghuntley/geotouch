using System;
using Xamarin.Forms;

namespace GeoTouch.Gestures
{
	public interface INativeGestureRecognizer
	{
		int NumberOfTouches { get; }

		Point LocationInView (VisualElement view);

		Point LocationOfTouch (int touchIndex, VisualElement view);

		GestureRecognizerState State { get; }

		void UpdateCancelsTouchesInView (bool cancelsTouchesInView);

		void UpdateDelaysTouches (bool delaysTouches);

	}
}

