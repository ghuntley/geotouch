using System;
using System.Windows.Input;

using Splat;
using Xamarin.Forms;

namespace GeoTouch.ViewModels
{
	public interface IHomeViewModel
	{
		Color GenerateRandomColor();

		ICommand PlaceShape();

		string Title { get; set;}
	}
}

