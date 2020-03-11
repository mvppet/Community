using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Actions;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibrary;
using GeneralWPFControlLibraryInterfaces;
using System;

namespace CommunityClassLibrary.Dwellers
{
	public abstract class AbstractDweller : BasicPositionalObjectWithThoughts, IDweller
	{
		public IDweller Me => this;
		private static object globalLock = new object();

		public IBirthday Birthday { get; } = new Birthday();
		public IPercent Food { get; protected set; } = new Percent(100);
		public IMutableVariable<double> Money { get; protected set; } = new FloatingPointValue { Value = 100 };
		public double HealthCostPerThought { get; } = 0.01 + Rnd.NextDouble();
		public virtual IBuilding InsideBuilding { get; protected set; }
		public Mood Mood { get; set; }

		public AbstractDweller(IPosition position) : this(null, position) { }
		public AbstractDweller(string name, IPosition position) : base(name, position)
		{
		}

		public void EnterBuilding(IBuilding o)
		{
			lock (globalLock)
			{
				if (o?.Id != InsideBuilding?.Id)
				{
					if (InsideBuilding != null)
					{
						// Check we're not in a building
						ExitBuilding();
					}
					// add ourself to the building's occupants
					o.Occupants.Add(this);

					// and place ourself inside
					InsideBuilding = o;
				}
			}
		}

		public void ExitBuilding()
		{
			lock (globalLock)
			{
				// are we in a building?
				if (InsideBuilding != null)
				{
					// remove ourself from the building
					if (InsideBuilding.Occupants.Contains(this))
					{
						InsideBuilding.Occupants.Remove(this);
					}
					InsideBuilding = null;
				}
			}
		}

		public override void HaveThoughts()
		{
			// are we in a building? If so, then we should be doing whatever we're supposed to. Sleeping, eating, earning money, whatever... Not thinking...
			if (InsideBuilding == null)
			{
				foreach (var thought in Thoughts)
				{
					thought.Think();
				}

				// else each thought iteration costs health
				Health.Value -= HealthCostPerThought;
			}
		}

		public override void PerformActions()
		{
			if (InsideBuilding != null)
			{
				// we are inside a building
				InsideBuilding.AffectObject(this);
			}
			else
			{

				// Did I think about something?
				IAction a = ActionManager.Pop();

				if (a != null && Food.Value > 0)
				{
					a.AffectObject(this);
				}
			}
		}

		public void UseFood(double foodNeeded)
		{
			Food.Value -= foodNeeded;
		}
	}
}
