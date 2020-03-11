using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityClassLibrary;
using CommunityClassLibrary.Dwellers;
using CommunityClassLibrary.IoC;
using CommunityClassLibrary.Locations;
using CommunityClassLibrary.VariablesProcessing;
using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibraryInterfaces.UI;
using CommunityViewModels;
using CommunityViewModels.Commands;
using GeneralWPFControlLibraryInterfaces;
using GeneralWPFControlLibraryViewModels;

namespace WPFCommunityHost.Setup
{
	public static class IoCRegistration
	{
		private static bool firstPass = true;

		static IoCRegistration()
		{
			Initialise();
		}

		public static void Initialise()
		{
			if (firstPass)
			{
				firstPass = false;

				IoCContainer.RegisterSingleton<ICommunity, Community>();
				IoCContainer.RegisterSingleton<ICommunityViewModel, CommunityViewModel>();
				IoCContainer.RegisterSingleton<DwellerStatisticsViewModel>();
				IoCContainer.RegisterSingleton<ConsoleWindowViewModel>();
				IoCContainer.RegisterSingleton<IDwellerCommandProcessor, DwellerCommandProcessor>();
				IoCContainer.RegisterSingleton<IRandom, BasicRandomGenerator>();
				
				IoCContainer.RegisterTransient<IDwellerViewModel, BasicDwellerViewModel>();
				IoCContainer.RegisterTransient<IHome, BasicHome>();
				IoCContainer.RegisterTransient<ICafe, BasicCafe>();
				IoCContainer.RegisterTransient<IWorkplace, BasicWorkplace>();

				//IoCContainer.RegisterTransient<IRoamingDweller, RoamingDweller>();
				IoCContainer.RegisterTransient<IRoamingDweller, RoamingDweller>("Normal");
				
			}
		}

		public static T Resolve<T>() => IoCContainer.Resolve<T>();
	}
}
