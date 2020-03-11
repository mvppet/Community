using CommunityClassLibrary.Dwellers;
using CommunityClassLibraryInterfaces.Actions;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibraryInterfaces.Thoughts;
using CommunityClassLibrary;
using GeneralWPFControlLibraryInterfaces;

namespace CommunityClassLibrary.Actions
{
	public class BasicMovementAction : ActionBase, IMovementAction
	{
//		private const string _actionName = "Movement";
		//public static ActionType ActionTypeName { get; } = ActionType.Movement;
		private const double _defaultPriority = 100; // assume "must-do-this". Lowering this will make the Thing move if it can be bothered...

		public IPosition Destination { get; }
		public IPosition FinalDestination { get; private set; }

		public BasicMovementAction(IThought initiatingThought, IBuilding building) : this(initiatingThought, building.Position) { }
		public BasicMovementAction(IThought initiatingThought, IPosition destination)
			: base(initiatingThought, ActionType.Move, new Percent(_defaultPriority))
		{
			Destination = destination;
			if (initiatingThought is IMovementThought mt)
			{
				FinalDestination = mt.Destination;
			}
		}



		/// <summary>
		/// Easy version: Just zap there...
		/// </summary>
		/// <param name="obj"></param>
		public override void AffectObject(IPositionalObject obj)
		{
			if(obj is IRoamingDweller dweller)
			{
				dweller.ActuallyMoveTo(Destination);
			}


			// setting the Position.Values will fire the Changed events on those objects
			//obj.Position.Value = Destination.Value;
		}

		public override string ToString()
		{
			return $"{base.ToString()} to ({Destination})";
		}

	}
}
