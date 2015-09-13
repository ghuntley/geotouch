using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Splat;
using Xamarin.Forms;

namespace GeoTouch.ViewModels
{
	public interface IHomeViewModel
	{
		Task<ShapeViewModel> GenerateRandomShapeAsync();

		ICommand PlaceShape();

		string Title { get; set;}
	}
}

