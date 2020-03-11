using CommunityClassLibrary;
using CommunityClassLibrary.Dwellers;
using CommunityClassLibrary.IoC;
using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibraryInterfaces.UI;
using CommunityViewModels.Commands;
using CommunityClassLibrary;
using GeneralWPFControlLibraryInterfaces;
using GeneralWPFControlLibraryViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace CommunityViewModels
{

	public class CommunityViewModel : ViewModelBase, IConsole, ICommunity, IViewModelBase, ICommunityViewModel
	{
		// use this instead of the constructor
		//public static CommunityViewModel Instance { get; private set; } = new CommunityViewModel();
		protected ICommunity Community = IoCContainer.Resolve<ICommunity>();

		// commands
		public IDwellerCommandProcessor DwellerCommandProcessor => IoCContainer.Resolve<IDwellerCommandProcessor>();


		// other stuff
		public DateTime Started { get; } = DateTime.Now;
		private StringBuilder _sbEcho = new StringBuilder();
		public IConsole Console { get; set; }

		public IList<IRoamingDweller> Dwellers => Community?.Dwellers;
		public IList<IDwellerViewModel> DwellerViewModels { get; } = new ObservableCollection<IDwellerViewModel>();
		public IList<IHome> Homes => Community?.Homes;
		public IList<ICafe> Cafes => Community?.Cafes;
		public IList<IWorkplace> Workplaces => Community?.Workplaces;
		public void Clear() => Community?.Clear();
		public int Iteration => Community?.Iteration ?? 0;

		public ICafe FindNearestCafe(Point point) => Community?.FindNearestCafe(point);
		public IHome FindNearestHome(Point point) => Community?.FindNearestHome(point);
		public IWorkplace FindNearestWorkplace(Point point) => Community?.FindNearestWorkplace(point);

		public CommunityViewModel()
		{
			//Community = CommunityClassLibrary.Community.Instance;
			if (InDesignMode)
			{
				AddDebugDwellers(3);
			}
		}

		private void AddDebugDwellers(int numDwellers)
		{
			for (int i = 0; i < numDwellers; ++i)
			{
				Add(new RoamingDweller($"Dweller {i}", new MutablePosition(0, 0)));
			}
		}

		public void Add(IRoamingDweller dweller)
		{
			Community.Add(dweller);
			DwellerViewModels.Add(new BasicDwellerViewModel(dweller));
			NotifyPropertyChanged(() => DwellerViewModels);
		}

		public void Add(IBuilding building)
		{
			Community.Add(building);

			switch (building)
			{
				case IHome home:
					NotifyPropertyChanged(() => Community.Homes);
					break;

				case IWorkplace workplace:
					NotifyPropertyChanged(() => Community.Workplaces);
					break;

				case ICafe cafe:
					NotifyPropertyChanged(() => Community.Cafes);
					break;
			}
		}

		public void Add(ICafe cafe)
		{
			Community.Add(cafe);
			NotifyPropertyChanged(() => Community.Cafes);
		}

		public void Add(IWorkplace workplace)
		{
			Community.Add(workplace);
			NotifyPropertyChanged(() => Community.Workplaces);
		}

		#region Console

		public void WriteLine(object o) => Console?.WriteLine(o);
		public void WriteLine(object o, object data) => Console?.WriteLine(o, data);



		#endregion
	}
}
