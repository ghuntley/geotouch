using System;
using Splat;
using Xamarin.Forms;

namespace GeoTouch
{
	public interface IRandomColourService
	{
		Color GenerateRandomColour();
	}

	/// <summary>
	/// http://stackoverflow.com/questions/730625/how-do-i-create-a-random-hex-string-that-represents-a-color
	/// </summary>
	public class RandomColourService : IRandomColourService
	{
		private Random _random;

		public RandomColourService ()
		{
			_random = new Random ();
		}

		public Color GenerateRandomColour()
		{
			return Color.FromHex(String.Format("#{0:X6}", _random.Next(0x1000000)));
		}
	}
}

