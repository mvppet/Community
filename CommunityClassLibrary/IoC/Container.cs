using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Resolution;

namespace CommunityClassLibrary.IoC
{
	public static class IoCContainer
	{
		private static UnityContainer _container = new UnityContainer();

		// prevent access to the constructor of this class from outside
		static IoCContainer()
		{
		}

		#region Singleton
		public static void RegisterSingleton<T>()
		{
			_container.RegisterType<T>(new ContainerControlledLifetimeManager());
		}
		public static void RegisterSingleton<T>(string name)
		{
			_container.RegisterType<T>(name, new ContainerControlledLifetimeManager());
		}

		public static void RegisterSingleton<T1, T2>() where T2 : T1
		{
			_container.RegisterType<T1, T2>(new ContainerControlledLifetimeManager());
		}
		public static void RegisterSingleton<T1, T2>(string name) where T2 : T1
		{
			_container.RegisterType<T1, T2>(name, new ContainerControlledLifetimeManager());
		}

		#endregion
		#region Transient

		public static void RegisterTransient<T>()
		{
			_container.RegisterType<T>();
		}
		public static void RegisterTransient<T>(string name)
		{
			_container.RegisterType<T>(name);
		}


		public static void RegisterTransient<T1, T2>() where T2 : T1
		{
			_container.RegisterType<T1, T2>();
		}
		public static void RegisterTransient<T1, T2>(string name) where T2 : T1
		{
			_container.RegisterType<T1, T2>(name);
		}

		#endregion
		#region Hierarchical

		public static void RegisterHierarchical<T>()
		{
			_container.RegisterType<T>(new HierarchicalLifetimeManager());
		}

		public static void RegisterHierarchical<T>(string name)
		{
			_container.RegisterType<T>(name, new HierarchicalLifetimeManager());
		}

		public static void RegisterHierarchical<T1, T2>() where T2 : T1
		{
			_container.RegisterType<T1, T2>(new HierarchicalLifetimeManager());
		}

		public static void RegisterHierarchical<T1, T2>(string name) where T2 : T1
		{
			_container.RegisterType<T1, T2>(name, new HierarchicalLifetimeManager());
		}

		#endregion
		#region Resolve


		public static T Resolve<T>() => _container.Resolve<T>();

		public static T Resolve<T>(string name) => _container.Resolve<T>(name);

		public static T ResolveWithConstructorParameterOverride<T>(string constructorVariableName, object value) => _container.Resolve<T>(new ParameterOverride(constructorVariableName, value));
		public static T ResolveWithConstructorParameterOverride<T>(string name, string constructorVariableName, object value) => _container.Resolve<T>(name, new ParameterOverride(constructorVariableName, value));
		public static T ResolveWithPropertyOverride<T>(string propertyName, object value) => _container.Resolve<T>(new PropertyOverride(propertyName, value));
		public static T ResolveWithPropertyOverride<T>(string name, string propertyName, object value) => _container.Resolve<T>(name, new PropertyOverride(propertyName, value));


		#endregion

	}
}
