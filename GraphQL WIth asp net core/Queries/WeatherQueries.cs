using GraphQL_WIth_asp_net_core.Services;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_WIth_asp_net_core.Queries
{
    public class WeatherQueries
    {
        [HotChocolate.Types.Relay.UsePaging]
        public IEnumerable<WeatherForecast>  GetWeatherForecasts([Service] IWeatherService weatherService)
        {
            return weatherService.GetWeatherForecast();
        }
    }
}
