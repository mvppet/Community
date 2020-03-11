using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using GeneralWPFControlLibraryInterfaces;

namespace CommunityClassLibraryInterfaces.UI
{
	public interface IDwellerViewModel: IPositionalObjectWithInterpolation, IRoamingDweller, IViewModelBase
	{
		IRoamingDweller Dweller { get; }
	}
}
