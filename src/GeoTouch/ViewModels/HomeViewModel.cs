using System;
using System.Windows.Input;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using PropertyChanged;
using Splat;
using Xamarin.Forms;
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

		public Color GenerateRandomColor()
		{
			return _randomColourService.GenerateRandomColor ();
		}

		private IRandomColorService _randomColourService;

		public string Title { get; set; }

		public HomeViewModel (IRandomColorService randomColourService = null)
		{
			_randomColourService = randomColourService ?? Locator.Current.GetService<IRandomColorService> ();

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

