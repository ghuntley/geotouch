using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using TwinTechs.Gestures.Converters;

using Xamarin.Forms;

[assembly: InternalsVisibleTo("TwinTechsLib.iOS"),
InternalsVisibleTo("TwinTechsLib.Droid")]

namespace TwinTechs.Gestures
{
    public enum SwipeGestureRecognizerDirection
    {
        Right = 1,
        Left = 2,
        Up = 4,
        Down = 8
    }

    public class SwipeGestureRecognizer : BaseGestureRecognizer
    {
        public SwipeGestureRecognizer()
        {
            NumberOfTouchesRequired = 1;
        }

        public SwipeGestureRecognizerDirection Direction
        {
            get; set;
        }

        public int NumberOfTouchesRequired
        {
            get; set;
        }

        public override string ToString()
        {
            return string.Format ("[SwipeGestureRecognizer: NumberOfTouchesRequired={0}, Direction={1} State={2}]", NumberOfTouchesRequired, Direction, State);
        }
    }
}