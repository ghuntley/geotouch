using System;
using System.Drawing;
using System.Windows.Input;
using PropertyChanged;
using GeoTouch.Models;
using Splat;

namespace GeoTouch.ViewModels
{
	[ImplementPropertyChanged]
	public class ShapeViewModel
	{
		public string Title {get; set;}
		public Shape Shape {get; set;}
		public string ImageUrl {get; set;}
		public string HexColour {get; set;}
		public RectangleF Dimensions {get; set;}
		public ICommand RefreshShape { get; private set; }
	}
}

