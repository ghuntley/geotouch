using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Refit;

namespace GeoTouch
{
	[Headers("Accept: application/json", "User-Agent: " + AppSettings.ApiClientUserAgent)]
	public interface IColourLoversApi
	{
		[Get("/colors/random?format=json")]
		Task<List<ColourLovers.ServiceModel.Colors>> GetRandomColour();

		[Get("/patterns/random?format=json")]
		Task<List<ColourLovers.ServiceModel.Patterns>> GetRandomPattern();
	}
}
