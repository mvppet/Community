using System;
using CommunityClassLibrary.Actions;
using CommunityClassLibrary.Locations;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Thoughts;
using GeneralWPFControlLibraryInterfaces;

namespace CommunityClassLibrary.Thoughts
{
	public class BasicSleepThought: ThoughtBase, IThought
	{
		private IRoamingDweller _dweller;
		public override IMutableVariable<double> Value => _dweller?.Health;

		public BasicSleepThought(IRoamingDweller dweller) : base(dweller)
		{
			_dweller = dweller;
			_dweller.Health.Changed += (s, e) =>
			{
				Threshold.Value = dweller.Health;
			};
			Threshold.ThresholdCrossed += CheckForGettingSleepy;
		}

		private void CheckForGettingSleepy(object sender, IThresholdCrossedEventArgs e)
		{
			// have we just gone below our threshold?
			if (e.ThresholdCrossed == ThresholdType.Lower && e.Direction == CrossingDirection.HighToLow)
			{
				// we are getting sleepy
				GettingSleepy();
			}
			else if (e.ThresholdCrossed == ThresholdType.Upper && e.Direction == CrossingDirection.LowToHigh)
			{
				// we are getting sleepy
				WakeUp();
			}
		}

		private void WakeUp()
		{
			_dweller?.ExitBuilding();
		}

		/// <summary>
		/// Getting Sleepy
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GettingSleepy()
		{
			var home = Community.FindNearestHome(_dweller.Position.Value);
			if (home != null)
			{
				_dweller.MoveTo(this, home);

			}
		}



		public override void ThinkAboutActions()
		{
		}

	}
}
