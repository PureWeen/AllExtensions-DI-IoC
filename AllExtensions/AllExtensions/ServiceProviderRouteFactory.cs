using AllExtensions.View;
using Microsoft.Extensions.DependencyInjection;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AllExtensions
{

	public static class  ServiceProviderRouteFactoryExtensions
	{
		public static IServiceCollection RegisterRoute(this IServiceCollection services, Type type)
		{
			services.AddTransient(type);
			ServiceProviderRouteFactory.RegisterRoute(type);
			return services;
		}

		public static IServiceCollection RegisterRoute(this IServiceCollection services, Type type, string routename)
		{
			services.AddTransient(type);
			ServiceProviderRouteFactory.RegisterRoute(type, routename);
			return services;
		}
	}

	public class ServiceProviderRouteFactory : RouteFactory
	{	
		public static void RegisterRoute(Type type)
		{
			RegisterRoute(type, type.Name);
		}

		public static void RegisterRoute(Type type, string routename)
		{
			Routing.RegisterRoute(type.Name, new ServiceProviderRouteFactory(typeof(SecondPage)));
		}

		readonly Type _type;

		public ServiceProviderRouteFactory(Type type)
		{
			_type = type;
		}

		public override Element GetOrCreate()
		{
			return (Element)App.ServiceProvider.GetService(_type);
		}

		public override bool Equals(object obj)
		{
			if ((obj is ServiceProviderRouteFactory typeRouteFactory))
				return typeRouteFactory._type == _type;

			return false;
		}

		public override int GetHashCode()
		{
			return _type.GetHashCode();
		}
	}
}