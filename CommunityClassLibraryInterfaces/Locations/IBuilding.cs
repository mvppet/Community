using CommunityClassLibraryInterfaces.Dwellers;
using GeneralWPFControlLibraryInterfaces;
using System.Collections.Generic;

namespace CommunityClassLibraryInterfaces.Locations
{
	public interface IBuilding: IIdAndName, IPositionalObject
	{
		IList<IDweller> Occupants { get; }
		void AffectObject(IPositionalObject obj);
		double ResourceCostPerIteration { get; set; }
		double RewardPerIteration { get; set; }

	}
}
