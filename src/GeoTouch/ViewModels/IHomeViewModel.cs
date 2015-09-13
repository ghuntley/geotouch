using System;
using System.Windows.Input;

using Splat;
using Xamarin.Forms;

namespace GeoTouch.ViewModels
{
	public interface IHomeViewModel
	{
		ShapeViewModel GenerateRandomShape();

		ICommand PlaceShape();

		string Title { get; set;}
	}
}

