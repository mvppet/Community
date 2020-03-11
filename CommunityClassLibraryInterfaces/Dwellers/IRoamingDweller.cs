using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibraryInterfaces.Priorities;
using CommunityClassLibraryInterfaces.Thoughts;
using GeneralWPFControlLibraryInterfaces;
using System;

namespace CommunityClassLibraryInterfaces.Dwellers
{
	public interface IRoamingDweller : IDweller
	{
		void ActuallyMoveTo(IPosition position);
		void MoveTo(IThought initiatingThought, IPosition position);
		void MoveTo(IThought initiatingThought, IBuilding building);
		IPosition Destination { get; }
		bool IsMoving { get; }

	}
}
