using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using System.Collections.Generic;
using System.Windows;

namespace CommunityClassLibraryInterfaces
{
	public interface ICommunity
	{
		IList<IRoamingDweller> Dwellers { get; }
		IList<IHome> Homes { get; }
		IList<IWorkplace> Workplaces { get; }
		IList<ICafe> Cafes { get; }

		ICafe FindNearestCafe(Point point);
		IHome FindNearestHome(Point point);
		IWorkplace FindNearestWorkplace(Point point);



		void Add(IRoamingDweller dweller);
		//void Add(IHome home);
		//void Add(ICafe home);
		//void Add(IWorkplace workplace);
		void Add(IBuilding building);

		void Clear();

		int Iteration { get; }

	}
}
