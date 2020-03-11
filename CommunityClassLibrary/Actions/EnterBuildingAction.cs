using CommunityClassLibraryInterfaces.Actions;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibraryInterfaces.Thoughts;
using CommunityClassLibrary;
using GeneralWPFControlLibraryInterfaces;

namespace CommunityClassLibrary.Actions
{
	public class EnterBuildingAction : ActionBase
	{
		private const double _defaultPriority = 100; // assume "must-do-this.
		public IBuilding BuildingToEnter { get; }

		public EnterBuildingAction(IThought initiatingThought, IBuilding building)
			: base(initiatingThought, ActionType.EnterBuilding, new Percent(_defaultPriority))
		{
			BuildingToEnter = building;
		}

		public override void AffectObject(IPositionalObject obj)
		{
			if(obj is IDweller dweller)
			{
				dweller.EnterBuilding(BuildingToEnter);
			}
		}

		public override string ToString()
		{
			return $"Enter Building \"{BuildingToEnter}\" at {BuildingToEnter.Position}";
		}

	}
}
