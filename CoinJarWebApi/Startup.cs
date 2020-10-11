using System.Web.Http;
using System.Web.Http.OData.Extensions;
using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common;
using Owin;
using CoinJarWebApi.Services;
using WebApiContrib.IoC.Ninject;
using CoinJarLogic;

[assembly: OwinStartup(typeof(CoinJarWebApi.Startup))]

namespace CoinJarWebApi
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration
			{
				DependencyResolver = new NinjectResolver(CreateKernel())
			};

			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
					name: "DefaultApi",
					routeTemplate: "{controller}/{id}",
					defaults: new { id = RouteParameter.Optional }
			);

			config.AddODataQueryFilter();

			app.UseWebApi(config);
			SwaggerConfig.Register(config);
		}

		public static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();

			kernel.Bind<ICoinJarManager>().ToConstant(new CoinJarManager());
			kernel.Bind<ICoinJarMapper>().To<CoinJarMapper>().InRequestScope();

			return kernel;
		}
	}
}
