using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibrary;
using GeneralWPFControlLibraryInterfaces;
using System.Collections.Generic;

namespace CommunityClassLibrary.Locations
{
	public class BasicHome : BasicBuildingBase, IHome
	{
		public BasicHome(string name, IPosition position) : base(name, position) { }
		public BasicHome(string name) : base(name, new MutablePosition()) { }
		public BasicHome(IPosition position) : base(null, position) { }

		// give health to a sleepy dweller
		public override void AffectObject(IPositionalObject obj)
		{
			if(obj is IDweller d)
			{
				d.Health.Value += RewardPerIteration;
			}
		}

	}
}
