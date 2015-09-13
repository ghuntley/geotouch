using System;

using Splat;

using Xamarin.Forms;

namespace GeoTouch.Services
{
    public interface IRandomColorService
    {
        Color GenerateRandomColor();
    }

    /// <summary>
    /// http://stackoverflow.com/questions/730625/how-do-i-create-a-random-hex-string-that-represents-a-color
    /// </summary>
    public class RandomColorService : IRandomColorService
    {
        private Random _random;

        public RandomColorService()
        {
            _random = new Random ();
        }

        public Color GenerateRandomColor()
        {
            return Color.FromHex(String.Format("#{0:X6}", _random.Next(0x1000000)));
        }
    }
}