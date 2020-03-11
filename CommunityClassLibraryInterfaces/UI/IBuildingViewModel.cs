using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using GeneralWPFControlLibraryInterfaces;

namespace CommunityClassLibraryInterfaces.UI
{
	public interface IBuildingViewModel: IPositionalObjectWithInterpolation, IBuilding
	{
		IBuilding Building { get; }
	}
}
