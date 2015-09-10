using System;
using PropertyChanged;

namespace GeoTouch
{
	[ImplementPropertyChanged]
	public class HomeViewModel : IHomeViewModel
	{
		public void PlaceShape();

		public HomeViewModel ()
		{
		}
	}
}

