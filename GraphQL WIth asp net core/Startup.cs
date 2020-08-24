using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL_WIth_asp_net_core.Queries;
using GraphQL_WIth_asp_net_core.Services;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphQL_WIth_asp_net_core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IWeatherService, WeatherService>();
            services.AddGraphQL(sp =>
            {
                return SchemaBuilder.New() 
                                .AddQueryType<WeatherQueries>()
                                .Create();
            }) ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseGraphQL("/graphql")
               .UsePlayground("/graphql")
               .UseVoyager("/voyager");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
