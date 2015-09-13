using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ColourLovers.ServiceModel;

using ModernHttpClient;

using Refit;

namespace GeoTouch
{
    public interface IColourLoversService
    {
        IColourLoversApi Background
        {
            get;
        }

        IColourLoversApi Speculative
        {
            get;
        }

        IColourLoversApi UserInitiated
        {
            get;
        }

		Colors GetNextRandomColour();
		Patterns GetNextRandomPattern();
    }

    public class ColourLoversService : IColourLoversService
    {
        public const string ApiBaseAddress = "http://www.colourlovers.com/api";

        private readonly Lazy<IColourLoversApi> _background;
        private readonly Lazy<IColourLoversApi> _speculative;
        private readonly Lazy<IColourLoversApi> _userInitiated;

		private List<Colors> _colors = new List<Colors> ();
		private List<Patterns> _patterns = new List<Patterns> ();

		public Colors GetNextRandomColour()
		{
			var color = _colors.Last();
			_colors.Remove (color);

			return color;
		}

		public Patterns GetNextRandomPattern()
		{
			var pattern = _patterns.Last ();
			_patterns.Remove (pattern);

			return pattern;
		}

        public ColourLoversService(string apiBaseAddress = null)
        {
			Func<HttpMessageHandler, IColourLoversApi> createClient = messageHandler =>
            {
                var client = new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri(apiBaseAddress ?? ApiBaseAddress)
                };

                return RestService.For<IColourLoversApi>(client);
            };

            // https://github.com/paulcbetts/Fusillade#how-do-i-use-this-with-modernhttpclient
            // _background = new Lazy<IColourLoversApi>(() => createClient(
            //	new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Background)));
            _background = new Lazy<IColourLoversApi>(() => createClient(new NativeMessageHandler()));

            // https://github.com/paulcbetts/Fusillade#how-do-i-use-this-with-modernhttpclient
            // _userInitiated = new Lazy<IColourLoversApi>(() => createClient(
            //	new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.UserInitiated)));
            _userInitiated = new Lazy<IColourLoversApi>(() => createClient(new NativeMessageHandler()));

            // https://github.com/paulcbetts/Fusillade#how-do-i-use-this-with-modernhttpclient
            // _speculative = new Lazy<IColourLoversApi>(() => createClient(
            //	new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Speculative)));
            _speculative = new Lazy<IColourLoversApi>(() => createClient(new NativeMessageHandler()));

			Task.Run (async () =>
				{
					while (true)
					{
						try {
							if (_colors.Count < 50)
							{
								var response = await this.Background.GetRandomColour();
								var colour  = response.Single();
								_colors.Add(colour);
							}
							if (_patterns.Count < 50)
							{
								var response = await this.Background.GetRandomPattern();
								var pattern  = response.Single();
								_patterns.Add(pattern);
							}

							await Task.Delay(100);
						}
						catch (Exception ex)
						{
							// swallow
						}
					}
				});
			

        }

        public IColourLoversApi Background
        {
            get { return _background.Value; }
        }

        public IColourLoversApi Speculative
        {
            get { return _speculative.Value; }
        }

        public IColourLoversApi UserInitiated
        {
            get { return _userInitiated.Value; }
        }
    }
}