using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using PropertyChanged;

namespace GeoTouch.ViewModels
{
	[ImplementPropertyChanged]
	public class HomeViewModel : IHomeViewModel
	{
		public void PlaceShape(){}

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

