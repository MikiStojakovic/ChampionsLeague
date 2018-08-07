using Autofac;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace ChampionsLeague.Configuration
{
    public class WebAppConfiguration
    {
        public static void ConfigureWebApi(IAppBuilder app, HttpConfiguration httpConfig)
        {
            // map routes
            httpConfig.MapHttpAttributeRoutes();

            httpConfig.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            // configure formatters
            httpConfig.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            app.UseAutofacWebApi(httpConfig);
        }

        public static void ConfigureFileSystem(IAppBuilder app, string publicDirectoryPath)
        {
            app.UseFileServer(new FileServerOptions
            {
                RequestPath = PathString.Empty,
                FileSystem = new PhysicalFileSystem(publicDirectoryPath)
            });
        }

        public static void ConfigureAuthentication(IAppBuilder app)
        {
        }

        public static void ConfigureFilters(HttpConfiguration httpConfig, IContainer container)
        {
        }
    }
}