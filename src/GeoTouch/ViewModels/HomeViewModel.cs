using System;
using System.Windows.Input;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using PropertyChanged;
using Splat;
using System.Drawing;

namespace GeoTouch.ViewModels
{
	[ImplementPropertyChanged]
	public class HomeViewModel : IHomeViewModel
	{
		public ICommand PlaceShape()
		{
			return null;
		}

		public string Title { get; set; }

		public HomeViewModel ()
		{
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

