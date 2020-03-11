using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibraryInterfaces.Priorities;
using CommunityClassLibraryInterfaces.Thoughts;
using GeneralWPFControlLibraryInterfaces;
using System;

namespace CommunityClassLibraryInterfaces.Dwellers
{
	public enum Mood { Resting, Crisis }

	public interface IDweller: IIdAndName, IPositionalObject, IHasThoughts
	{
		IBirthday Birthday { get; }
		ICommunity Community { get; }

		IPercent Food { get; }
		IMutableVariable<double> Money { get; }

		void UseFood(double foodNeeded);

		void EnterBuilding(IBuilding building);
		void ExitBuilding();

		IBuilding InsideBuilding { get; }

		Mood Mood { get; }

	}
}
