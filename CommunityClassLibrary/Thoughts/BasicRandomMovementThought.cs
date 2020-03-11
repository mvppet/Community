using CommunityClassLibrary.Priorities;
using CommunityClassLibraryInterfaces.Actions;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Priorities;
using CommunityClassLibrary.VariablesProcessing;
using GeneralWPFControlLibraryInterfaces;

namespace CommunityClassLibrary.Thoughts
{
	public class BasicRandomMovementThought: BasicMovementThought
	{
		private IRoamingDweller _dweller;
		public IPriority ProbabilityOfMoving { get; } = new BasicPriority(PriorityType.ProbabilityOfMoving, 10);

		public BasicRandomMovementThought(IRoamingDweller dweller) : base(dweller)
		{
			_dweller = dweller;
		}


		public override void ThinkAboutActions()
		{
			// OK, we're a positional dweller. Do we want to move?
			IPercent percent = Random.NextPercent();
			if (percent.Value < ProbabilityOfMoving.Percent.Value)
			{
				// do we have any movement actions?
				if (!_dweller.ActionManager.ContainsActionType(ActionType.Move))
				{
					AddMovementAction(
						Random.NextDouble() * (Bounds.Value.X - 50.0),
						Random.NextDouble() * (Bounds.Value.Y - 50.0)
					);
				}
			}
		}
	}
}
