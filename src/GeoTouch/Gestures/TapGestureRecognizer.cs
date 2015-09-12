using System;

namespace GeoTouch.Gestures
{
	public class TapGestureRecognizer : BaseGestureRecognizer
	{
		public override string ToString()
		{
			return string.Format ("TapGestureRecognizer: State={0}", State);
		}
	}
}

