using System;
using System.Linq;
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

		public async Task<ShapeViewModel> GenerateRandomShapeAsync()
		{
			var viewModel = new ShapeViewModel ();

			if (_random.Next () % 2 != 0) {
				viewModel.Shape = Shape.Square;
			}
			else
			{
				viewModel.Shape = Shape.Circle;
			}

			var response = await _colourLoversService.UserInitiated.GetRandomColour();
			var result = response.Single ();

			viewModel.Color = Color.FromHex(result.hex);
//			viewModel.Color = _randomColourService.GenerateRandomColor ();

			return viewModel;
		}

		private Random _random;
		private IColourLoversService _colourLoversService;
		private IRandomColorService _randomColourService;

		public string Title { get; set; }

		public HomeViewModel (IRandomColorService randomColourService = null, IColourLoversService colourLoversService = null)
		{
			_randomColourService = randomColourService ?? Locator.Current.GetService<IRandomColorService> ();

			_colourLoversService = colourLoversService ?? Locator.Current.GetService<IColourLoversService> ();

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

