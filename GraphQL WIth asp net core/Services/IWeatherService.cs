using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_WIth_asp_net_core.Services
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> GetWeatherForecast();
    }
}
