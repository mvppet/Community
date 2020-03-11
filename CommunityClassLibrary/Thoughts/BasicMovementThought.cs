using CommunityClassLibrary.Locations;
using CommunityClassLibraryInterfaces.Thoughts;
using GeneralWPFControlLibraryInterfaces;
using CommunityClassLibrary;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibrary.Actions;
using System;

namespace CommunityClassLibrary.Thoughts
{
	public class BasicMovementThought: ThoughtBase, IMovementThought
	{
		public IPosition Destination { get; private set; }
		public static MutablePosition Bounds { get; set; } = new MutablePosition();
		public override IMutableVariable<double> Value { get; }
		public IBuilding building;
		public event EventHandler<IPosition> DestinationChanged;


		//private IPosition _destination;


		//public IPosition Destination
		//{
		//	get => _destination;
		//	private set
		//	{
		//		_destination = value;

		//	}
		//}


		public BasicMovementThought(IHasThoughts thoughtObject) : base(thoughtObject) { }
		public BasicMovementThought(IHasThoughts thoughtObject, double x, double y)
			: this(thoughtObject, new BasicPosition(x, y)) { }
		public BasicMovementThought(IHasThoughts thoughtObject, IPosition position)
			: base(thoughtObject)
			=> Destination = position;
		public BasicMovementThought(IHasThoughts thoughtObject, IBuilding building)
			: base(thoughtObject)
		{
			Destination = building.Position;
			this.building = building;
		}

		protected void AddMovementAction(double x, double y) => AddMovementAction(new BasicPosition(x, y));
		protected void AddMovementAction(IPosition destination)
		{
			// store this for reference
			Destination = destination;
			DestinationChanged?.Invoke(this, destination);

			// Add an action the dweller's list
			dweller.MoveTo(this, destination);

		}

		public override void ThinkAboutActions()
		{
			AddMovementAction(Destination);
			if(building!=null)
			{
				thoughtObject.ActionManager.Push(new EnterBuildingAction(this, building));
			}
		}

	}
}
