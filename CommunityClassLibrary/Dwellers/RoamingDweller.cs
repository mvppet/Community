using CommunityClassLibrary.Actions;
using CommunityClassLibrary.Locations;
using CommunityClassLibrary.Thoughts;
using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Actions;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibraryInterfaces.Priorities;
using CommunityClassLibraryInterfaces.Thoughts;
using CommunityClassLibrary;
using GeneralWPFControlLibraryInterfaces;
using Unity;

namespace CommunityClassLibrary.Dwellers
{
	/// <summary>
	/// A basic Roaming Dwller has no purpose other than to move around and consume food and health.
	/// They call me a wanderer, a wanderer...
	/// </summary>
	public class RoamingDweller : AbstractDweller, IRoamingDweller
	{
		public IPosition Destination { get; private set; }

		//
		// Constructors
		//
		public RoamingDweller() : this(null) { }
		[InjectionConstructor]
		public RoamingDweller(string name) : this(name, new MutablePosition()) { }  //base(name, new MutablePosition(), lifeTimer) => CreateBasicRoamingDweller();
		public RoamingDweller(string name, IPosition position) : base(name, position) => CreateBasicRoamingDweller();

		public bool IsMoving => ActionManager?.ContainsActionType(ActionType.Move) ?? false;

		//
		// Setup
		//
		private void CreateBasicRoamingDweller()
		{
			// think about moving to a random position every now and then.
			Thoughts.Add(new BasicRandomMovementThought(this));

			// think about food
			var bfd = new BasicFoodThought(this);
			Thoughts.Add(bfd);

			// think about sleeping
			var bst = new BasicSleepThought(this);
			Thoughts.Add(bst);
		}


		//
		// Do Stuff
		//

		public virtual void MoveTo(IThought initiatingThought, IPosition destination)
		{
			// are we trying to go to the same place?
			if(ActionManager.FindOne(ActionType.Move) is BasicMovementAction ma)
			{
				// we have a movement action
				if(ma.FinalDestination == destination)
				{
					// we're already going there
					return;
				}
			}

			// stop going where we *were* going
			ActionManager.Remove(ActionType.Move);

			// now go somewhere else
			Destination = destination;
			double[] steps = { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0 };

			double xRange = destination.Value.X - Position.Value.X;
			double yRange = destination.Value.Y - Position.Value.Y;

			// add some actions to iterate there
			foreach (double fraction in steps)
			{
				ActionManager.Push(new BasicMovementAction(initiatingThought, new BasicPosition(
																							Position.Value.X + (fraction * xRange),
																							Position.Value.Y + (fraction * yRange)
																						)));
			}

		}
		public virtual void MoveTo(IThought initiatingThought, IBuilding building)
		{
			// remove any Move or EnterBuilding actions
			ActionManager.Remove(ActionType.Move);
			ActionManager.Remove(ActionType.EnterBuilding);

			// Set our destination
			MoveTo(initiatingThought, building.Position);

			// a final thought to enter the building
			ActionManager.Push(new EnterBuildingAction(initiatingThought, building));
		}

		public void ActuallyMoveTo(IPosition position) => base.MoveTo(position);


		/// <summary>
		/// override this to stop this Dweller updating its own position.
		/// Actions should control the movement
		/// </summary>
		/// <param name="position"></param>
		public override void MoveTo(IPosition position) { }


	}
}
