using CommunityClassLibraryInterfaces.Locations;
using GeneralWPFControlLibraryInterfaces;

namespace CommunityClassLibraryInterfaces.Actions
{
	public interface IMovementAction: IAction
	{
		IPosition Destination { get; }
	}
}
