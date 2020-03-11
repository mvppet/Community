using CommunityClassLibrary.IoC;
using CommunityClassLibrary.Locations;
using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Thoughts;
using GeneralWPFControlLibraryInterfaces;

namespace CommunityClassLibrary.Thoughts
{
	public class BasicFoodThought: ThoughtBase, IThought
	{
		private IRoamingDweller _dweller;
		public override IMutableVariable<double> Value => _dweller?.Food;

		public BasicFoodThought(IRoamingDweller dweller) : base(dweller)
		{
			_dweller = dweller;
			_dweller.Food.Changed += (s, e) =>
			{
				Threshold.Value = dweller.Food;
			};
			Threshold.ThresholdCrossed += CheckForGettingHungry;
		}

		private void CheckForGettingHungry(object sender, IThresholdCrossedEventArgs e)
		{

			// have we just gone below our threshold?
			if (e.ThresholdCrossed == ThresholdType.Lower && e.Direction == CrossingDirection.HighToLow)
			{
				// we are getting sleepy
				GettingHungry();
			}
			else if (e.ThresholdCrossed == ThresholdType.Upper && e.Direction == CrossingDirection.LowToHigh)
			{
				// we are getting sleepy
				StopEating();
			}


		}


		private void StopEating()
		{
			_dweller?.ExitBuilding();
		}


		/// <summary>
		/// I need to find a cafe
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GettingHungry()
		{
			var cafe = Community.FindNearestCafe(_dweller.Position.Value);
			if (cafe != null)
			{
				_dweller.MoveTo(this, cafe);
			}
		}

		public override void ThinkAboutActions()
		{
			// have we gone below our food threshold
			Threshold.Value = dweller.Food;
		}

	}
}
