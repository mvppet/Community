using CommunityClassLibrary;
using CommunityClassLibrary.Dwellers;
using CommunityClassLibrary.Thoughts;
using CommunityClassLibraryInterfaces.Thoughts;
using System;
using System.Linq;

namespace CommunityViewModels
{
	public class BasicFoodThoughtViewModel : BasicThoughtViewModel, IThoughtViewModel
	{
		public double Food => Thought?.Threshold?.Value?.RoundedValue ?? 0;

		public BasicFoodThoughtViewModel(IThought thought) : base(thought)
		{
			if(thought is BasicFoodThought bft)
			{
				bft.Threshold.Value.Changed += Value_Changed;
			}
			else
			{
				throw new NotSupportedException($"{nameof(thought)} must be derived from BasicFoodThought");
			}
		}
		private void Value_Changed(object sender, EventArgs e)
		{
			NotifyPropertyChanged(nameof(Food));
		}
		public BasicFoodThoughtViewModel() : base(null)
		{
			// this is design time
			if (InDesignMode)
			{
				var d = new RoamingDweller();

				//				Thought = new BasicMovementThought(d, 0, 0);
				Thought = d.Thoughts.FirstOrDefault(t => t is BasicFoodThought);
			}
			else
			{
				throw new Exception("This constructor should only be called in Designer Mode");
			}
		}
	}
}
