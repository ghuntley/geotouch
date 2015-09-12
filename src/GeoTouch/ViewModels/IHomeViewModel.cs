using System;
using System.Windows.Input;

using Splat;
using System.Drawing;

namespace GeoTouch
{
	public interface IHomeViewModel
	{
		ICommand PlaceShape();

		string Title { get; set;}
	}
}

