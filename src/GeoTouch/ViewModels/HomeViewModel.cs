using System;
using System.Windows.Input;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using PropertyChanged;
using Splat;
using Xamarin.Forms;
using GeoTouch.Models;
using GeoTouch.Services;

namespace GeoTouch.ViewModels
{
	[ImplementPropertyChanged]
	public class HomeViewModel : IHomeViewModel
	{
		public ICommand PlaceShape()
		{
			return null;
		}

		public ShapeViewModel GenerateRandomShape ()
		{
			var viewModel = new ShapeViewModel ();

			if (_random.Next () % 2 != 0) {
				viewModel.Shape = Shape.Square;
			}
			else
			{
				viewModel.Shape = Shape.Circle;
			}

			viewModel.Color = _randomColourService.GenerateRandomColor ();

			return viewModel;
		}

		private Random _random;
		private IRandomColorService _randomColourService;

		public string Title { get; set; }

		public HomeViewModel (IRandomColorService randomColourService = null)
		{
			_randomColourService = randomColourService ?? Locator.Current.GetService<IRandomColorService> ();
			_random = new Random ();

			Task.Run (async () => 
			{
				while (true)
				{
					Title = DateTime.UtcNow.ToString();
					await Task.Delay(1000);
				}
			});
		}
	}
}

