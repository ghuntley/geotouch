﻿using System;

using TwinTechs.Ios.Extensions;

using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace TwinTechs.Gestures
{
    public interface IBaseNativeGestureRecognizerImpl : INativeGestureRecognizer
    {
        void AddRecognizer(BaseGestureRecognizer recognizer);

        void RemoveRecognizer(BaseGestureRecognizer recognizer);
    }

    public abstract class BaseNativeGestureRecognizer<NativeGestureType, T> : INativeGestureRecognizer, IBaseNativeGestureRecognizerImpl
        where NativeGestureType : UIGestureRecognizer
        where T : BaseGestureRecognizer
    {
        public int NumberOfTouches
        {
            get {
                return (int)NativeRecognizer.NumberOfTouches;
            }
        }

        public GestureRecognizerState State
        {
            get {
                return (GestureRecognizerState)(NativeRecognizer != null ?
                    GetGestureRecognizerStateFromUIState (NativeRecognizer.State) : GestureRecognizerState.Failed);
            }
        }

        protected NativeGestureType NativeRecognizer
        {
            get; set;
        }

        protected UIView NativeView
        {
            get; set;
        }

        protected T Recognizer
        {
            get; set;
        }

        public void AddRecognizer(BaseGestureRecognizer recognizer)
        {
            Recognizer = (T)recognizer;
            var renderer = Recognizer.View.GetRenderer ();
            if (renderer == null) {
                Recognizer.View.PropertyChanged += Recognizer_View_PropertyChanged;
            } else {
                InitializeNativeRecognizer ();
            }
        }

        public Point LocationInView(VisualElement view)
        {
            if (NativeRecognizer != null) {

                var renderer = view.GetRenderer ();
                return NativeRecognizer.LocationInView (renderer.NativeView).ToPoint ();
            } else {
                return Point.Zero;
            }
        }

        public Point LocationOfTouch(int touchIndex, VisualElement view)
        {
            if (NativeRecognizer != null) {
                var renderer = view.GetRenderer ();
                return NativeRecognizer.LocationOfTouch (touchIndex, renderer.NativeView).ToPoint ();
            } else {
                return Point.Zero;
            }
        }

        public void RemoveRecognizer(BaseGestureRecognizer recognizer)
        {
            NativeView.RemoveGestureRecognizer (NativeRecognizer);
            NativeRecognizer.ShouldRecognizeSimultaneously -= _NativeRecognizer_ShouldRecognizeSimultaneously;
            NativeRecognizer.ShouldBegin -= _NativeRecognizer_ShouldBegin;
            NativeRecognizer = null;
            recognizer.NativeGestureRecognizer = null;
        }

        public void UpdateCancelsTouchesInView(bool _cancelsTouchesInView)
        {
            NativeRecognizer.CancelsTouchesInView = _cancelsTouchesInView;
        }

        public void UpdateDelaysTouches(bool _delaysTouches)
        {
            NativeRecognizer.DelaysTouchesBegan = _delaysTouches;
        }

        protected virtual void ConfigureNativeGestureRecognizer()
        {
            NativeRecognizer.CancelsTouchesInView = Recognizer.CancelsTouchesInView;
            NativeRecognizer.DelaysTouchesBegan = Recognizer.DelaysTouches;
            //			NativeRecognizer.DelaysTouchesEnded = Recognizer.DelaysTouchesEnded;
            NativeRecognizer.ShouldRecognizeSimultaneously += _NativeRecognizer_ShouldRecognizeSimultaneously;
            NativeRecognizer.ShouldBegin += _NativeRecognizer_ShouldBegin;
        }

        GestureRecognizerState GetGestureRecognizerStateFromUIState(UIGestureRecognizerState state)
        {
            switch (state) {
            case UIGestureRecognizerState.Possible:
                return GestureRecognizerState.Possible;
            case UIGestureRecognizerState.Began:
                return GestureRecognizerState.Began;
            case UIGestureRecognizerState.Changed:
                return GestureRecognizerState.Changed;
            case UIGestureRecognizerState.Ended:
                return GestureRecognizerState.Ended;
            case UIGestureRecognizerState.Cancelled:
                return GestureRecognizerState.Cancelled;
            case UIGestureRecognizerState.Failed:
                return GestureRecognizerState.Failed;
            default:
                throw new ArgumentOutOfRangeException ();
            }
        }

        void InitializeNativeRecognizer()
        {
            var renderer = Recognizer.View.GetRenderer ();
            if (renderer == null) {
                throw new InvalidOperationException ("attempted to initialize a native gesture recognizers for a view before it had created it's renderer");
            }

            NativeView = renderer.NativeView;

            //workaroudn for irritating bugn which causes renderer to fail
            if (typeof(NativeGestureType).Equals (typeof(UIPinchGestureRecognizer))) {
                NativeRecognizer = new UIPinchGestureRecognizer (OnGesture) as NativeGestureType;
            } else {
                Action<NativeGestureType> action = OnGesture;
                NativeRecognizer = (NativeGestureType)Activator.CreateInstance (typeof(NativeGestureType), action);
            }

            ConfigureNativeGestureRecognizer ();

            NativeView.UserInteractionEnabled = true;
            NativeView.AddGestureRecognizer (NativeRecognizer);
        }

        void OnGesture(UIGestureRecognizer recognizer)
        {
            Recognizer.SendAction ();
        }

        void Recognizer_View_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Renderer") {
                var renderer = Recognizer.View.GetRenderer ();
                if (renderer != null && NativeView == null) {
                    InitializeNativeRecognizer ();
                } else if (renderer == null && NativeView != null && NativeRecognizer != null) {
                    RemoveRecognizer (Recognizer);
                }
            }
        }

        bool _NativeRecognizer_ShouldBegin(UIGestureRecognizer recognizer)
        {
            if (Recognizer.OnGestureShouldBeginDelegate != null) {
                return Recognizer.OnGestureShouldBeginDelegate (Recognizer);
            } else {
                return true;
            }
        }

        bool _NativeRecognizer_ShouldRecognizeSimultaneously(UIGestureRecognizer gestureRecognizer, UIGestureRecognizer otherGestureRecognizer)
        {
            var renderer = Recognizer.View.GetRenderer ();
            return renderer != null && Recognizer.IsConsumingTouchesInParallel;
        }
    }
}