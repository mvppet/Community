using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibrary;
using GeneralWPFControlLibraryInterfaces;

namespace CommunityClassLibrary.Locations
{
	public class BasicCafe: BasicBuildingBase, ICafe
	{
		public BasicCafe(string name, IPosition position) : base(name, position) { }
		public BasicCafe(string name) : base(name, new MutablePosition()) { }
		public BasicCafe(IPosition position) : base(null, position) { }

		// Feed a hungry dweller
		public override void AffectObject(IPositionalObject obj)
		{
			if (obj is IDweller d)
			{
				d.Food.Value += RewardPerIteration;
				d.Money.Value -= ResourceCostPerIteration;
			}
		}


	}
}
