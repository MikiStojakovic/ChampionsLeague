using ChampionsLeague.Configuration;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ChampionsLeague
{
    public class ChampionsLeagueWebApp : IDisposable
    {
        private readonly IDisposable _webApp;

        private ChampionsLeagueWebApp(string hmiHostUrl, string publicDirectoryPath)
        {
            _webApp = WebApp.Start(hmiHostUrl, app => BuildApp(app, publicDirectoryPath));
        }

        private static void BuildApp(IAppBuilder app, string publicDirectoryPath)
        {
            var container = IoCConfiguration.CreateIoCContainer();

            var httpConfig = new HttpConfiguration
            {
                DependencyResolver = container.Resolve<System.Web.Http.Dependencies.IDependencyResolver>()
            };

            WebAppConfiguration.ConfigureFileSystem(app, publicDirectoryPath);

            WebAppConfiguration.ConfigureAuthentication(app);

            WebAppConfiguration.ConfigureWebApi(app, httpConfig);

            WebAppConfiguration.ConfigureFilters(httpConfig, container);

            app.UseAutofacMiddleware(container);

            // must be at the end
            app.UseWebApi(httpConfig);
        }

            public void Dispose()
        {
            if (_webApp != null)
                _webApp.Dispose();
        }
    }
}