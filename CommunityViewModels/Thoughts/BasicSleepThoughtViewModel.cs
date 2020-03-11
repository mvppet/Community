using CommunityClassLibrary;
using CommunityClassLibrary.Dwellers;
using CommunityClassLibrary.Thoughts;
using CommunityClassLibraryInterfaces.Thoughts;
using System;
using System.Linq;

namespace CommunityViewModels
{
	public class BasicSleepThoughtViewModel : BasicThoughtViewModel, IThoughtViewModel
	{
		public double Health => Thought?.Threshold?.Value?.RoundedValue ?? 0;

		public BasicSleepThoughtViewModel(IThought thought) : base(thought)
		{
			if (thought is BasicSleepThought bsl)
			{
				bsl.Threshold.Value.Changed += Value_Changed;
			}
			else
			{
				throw new NotSupportedException($"{nameof(thought)} must be derived from BasicSleepThought");
			}
		}

		private void Value_Changed(object sender, EventArgs e)
		{
			NotifyPropertyChanged(nameof(Health));
		}

		public BasicSleepThoughtViewModel() : base(null)
		{
			// this is design time
			if (InDesignMode)
			{
				var d = new RoamingDweller();
				//				Thought = new BasicMovementThought(d, 0, 0);
				Thought = d.Thoughts.FirstOrDefault(t => t is BasicSleepThought);
			}
			else
			{
				throw new Exception("This constructor should only be called in Designer Mode");
			}
		}
	}
}
