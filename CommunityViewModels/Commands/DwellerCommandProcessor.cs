using CommunityClassLibrary;
using CommunityClassLibrary.Dwellers;
using CommunityClassLibrary.IoC;
using CommunityClassLibrary.Locations;
using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibraryInterfaces.Thoughts;
using CommunityClassLibraryInterfaces.UI;
using CommunityClassLibrary;
using System;

namespace CommunityViewModels.Commands
{
	public class DwellerCommandProcessor : TextCommandProcessorBase, IDwellerCommandProcessor
	{
		public event EventHandler<IRoamingDweller> NewDwellerCreated;
		public event EventHandler<IBuilding> NewBuildingCreated;
		protected ICommunity Community { get; } = IoCContainer.Resolve<ICommunity>();
		protected ICommunityViewModel CommunityViewModel => IoCContainer.Resolve<ICommunityViewModel>();


		public override void ExecuteCommand(string dwellerType)
		{
			switch (dwellerType?.ToLower())
			{
				default:
				case "newnormaldweller":
					NewNormalDweller();
					break;
					//case "newhome":
					//	NewNormalHome();
					//	break;
			}
		}

		public void NewNormalDweller(string name=null)
		{
			CommunityViewModel.WriteLine("Making a new Dweller");



			//var d = new RoamingDweller(CommunityViewModel.Instance);
			var d = IoCContainer.ResolveWithConstructorParameterOverride<IRoamingDweller>("Normal", "name", name);
			//var vm = new BasicDwellerViewModel(d);
			var vm = IoCContainer.ResolveWithConstructorParameterOverride<IDwellerViewModel>("dweller", d);

			CommunityViewModel.Add(vm);
			NewDwellerCreated?.Invoke(this, vm);
		}

		//public void NewNormalHome()
		//{
		//	CommunityViewModel.Instance.WriteLine("Making a new Home");

		//	var h = new BasicHome(new BasicPosition(50, 50));
		//	var vm = new BasicBuildingViewModel(h);
		//	CommunityViewModel.Instance.Add(h);
		//	NewBuildingCreated?.Invoke(this, vm);
		//}



		public void NewHome(IHome home)
		{
			CommunityViewModel.WriteLine("Adding a new Home");

			CommunityViewModel.Add(home);
			NewBuildingCreated?.Invoke(this, home);
		}
		public void NewCafe(ICafe cafe)
		{
			CommunityViewModel.WriteLine("Adding a new Cafe");

			CommunityViewModel.Add(cafe);
			NewBuildingCreated?.Invoke(this, cafe);
		}
		public void NewWorkplace(IWorkplace workplace)
		{
			CommunityViewModel.WriteLine("Adding a new Cafe");

			CommunityViewModel.Add(workplace);
			NewBuildingCreated?.Invoke(this, workplace);
		}
		public void NewDweller(IRoamingDweller vm)
		{
			CommunityViewModel.WriteLine("Adding a new Dweller");

			CommunityViewModel.Add(vm);
			NewDwellerCreated?.Invoke(this, vm);
		}


		private void D_Updated(object sender, IHasThoughts e)
		{
			if (e is IDweller dweller)
			{
				CommunityViewModel.WriteLine($"{dweller.Id}/{dweller.Name} Finished Thought {Community.Iteration}");
			}
		}
	}


}
