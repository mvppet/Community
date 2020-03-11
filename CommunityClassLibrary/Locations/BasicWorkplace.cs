using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibrary;
using GeneralWPFControlLibraryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityClassLibrary.Locations
{
	public class BasicWorkplace: BasicBuildingBase, IWorkplace
	{
		public BasicWorkplace(string name, IPosition position) : base(name, position) { }
		public BasicWorkplace(string name) : base(name, new MutablePosition()) { }
		public BasicWorkplace(IPosition position) : base(null, position) { }

		// A day in the office
		public override void AffectObject(IPositionalObject obj)
		{
			if (obj is IDweller d)
			{
				d.Money.Value += RewardPerIteration;
				d.Health.Value -= ResourceCostPerIteration;
			}
		}

	}
}
