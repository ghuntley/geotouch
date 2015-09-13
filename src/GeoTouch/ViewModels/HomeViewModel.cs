using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.Http;
using System.Net;

using GeoTouch.Models;
using GeoTouch.Services;

using PropertyChanged;

using Splat;

using Xamarin.Forms;

namespace GeoTouch.ViewModels
{
    [ImplementPropertyChanged]
    public class HomeViewModel : IHomeViewModel
    {
        private IColourLoversService _colourLoversService;
        private Random _random;
        private IRandomColorService _randomColourService;

        public HomeViewModel(IRandomColorService randomColourService = null, IColourLoversService colourLoversService = null)
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

        public string Title
        {
            get; set;
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

			try {
	            var response = await _colourLoversService.UserInitiated.GetRandomColour();
	            var result = response.Single ();

	            viewModel.Color = Color.FromHex(result.hex);
			}
			catch (WebException ex) {
				viewModel.Color = _randomColourService.GenerateRandomColor ();
			}

            return viewModel;
        }

        public ICommand PlaceShape()
        {
            return null;
        }
    }
}