using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityViewModels.Commands;
using GeneralWPFControlLibraryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommunityClassLibraryInterfaces.UI
{
	public interface ICommunityViewModel
	{

		IList<ICafe> Cafes { get; }
		IConsole Console { get; set; }
		IDwellerCommandProcessor DwellerCommandProcessor { get; }
		IList<IRoamingDweller> Dwellers { get; }
		IList<IDwellerViewModel> DwellerViewModels { get; }
		IList<IHome> Homes { get; }
		int Iteration { get; }
		DateTime Started { get; }
		IList<IWorkplace> Workplaces { get; }

		void Add(IBuilding building);
		void Add(ICafe cafe);
		void Add(IRoamingDweller dweller);
		void Add(IWorkplace workplace);
		void Clear();
		ICafe FindNearestCafe(Point point);
		IHome FindNearestHome(Point point);
		IWorkplace FindNearestWorkplace(Point point);

		void WriteLine(object o);
		void WriteLine(object o, object data);

	}
}
