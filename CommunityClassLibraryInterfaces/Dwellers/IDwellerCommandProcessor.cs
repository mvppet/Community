using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using System;

namespace CommunityViewModels.Commands
{
	public interface IDwellerCommandProcessor
	{
		event EventHandler<IBuilding> NewBuildingCreated;
		event EventHandler<IRoamingDweller> NewDwellerCreated;

		void ExecuteCommand(string dwellerType);
		void NewCafe(ICafe cafe);
		void NewDweller(IRoamingDweller vm/*, DwellerType dwellerType=DwellerType.Normal*/);
		void NewHome(IHome home);
		void NewNormalDweller(string name);
		void NewWorkplace(IWorkplace workplace);
	}
}