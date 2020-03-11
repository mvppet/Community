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
	public class BasicBuildingBase: BasicPositionalThingWithId, IBuilding
	{
		public IList<IDweller> Occupants { get; } = new List<IDweller>();
		public double ResourceCostPerIteration { get; set; }
		public double RewardPerIteration { get; set; }

		public BasicBuildingBase(string name, IPosition position) : base(name, position) { }
		public BasicBuildingBase(string name) : base(name, new MutablePosition()) { }
		public BasicBuildingBase(IPosition position) : base(null, position) { }

		public virtual void AffectObject(IPositionalObject obj) { }
	}
}
