using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using ModernHttpClient;

namespace GeoTouch
{
	public interface IColourLoversService
	{
		IColourLoversApi Speculative { get; }
		IColourLoversApi UserInitiated { get; }
		IColourLoversApi Background { get; }
	}

	public class ColourLoversService : IColourLoversService
	{
		public const string ApiBaseAddress = "http://www.colourlovers.com/api";

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
		}

		private readonly Lazy<IColourLoversApi> _background;
		private readonly Lazy<IColourLoversApi> _userInitiated;
		private readonly Lazy<IColourLoversApi> _speculative;

		public IColourLoversApi Background
		{
			get { return _background.Value; }
		}

		public IColourLoversApi UserInitiated
		{
			get { return _userInitiated.Value; }
		}

		public IColourLoversApi Speculative
		{
			get { return _speculative.Value; }
		}
	}
}
