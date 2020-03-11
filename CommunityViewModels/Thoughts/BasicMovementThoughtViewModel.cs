using CommunityClassLibrary;
using CommunityClassLibrary.Dwellers;
using CommunityClassLibrary.Thoughts;
using CommunityClassLibraryInterfaces.Thoughts;
using System.Linq;
using System;
using GeneralWPFControlLibraryInterfaces;

namespace CommunityViewModels
{
	public class BasicMovementThoughtViewModel : BasicThoughtViewModel, IThoughtViewModel
	{
		const string NotMoving = "<Not Moving>";
		public string Destination => (Thought as BasicMovementThought)?.Destination?.ToString() ?? NotMoving;
		//public string Position => (Thought as BasicMovementThought)?.Destination?.Value?.ToString() ?? string.Empty;


		public BasicMovementThoughtViewModel(IThought thought) : base(thought)
		{
			if (thought is BasicMovementThought bmt)
			{
				if(bmt.Destination!=null)
				{
					bmt.DestinationChanged += Destination_Changed;
				}
			}
			else
			{
				throw new NotSupportedException($"{nameof(thought)} must be derived from BasicMovementThought");
			}

		}

		private void Destination_Changed(object sender, IPosition pos)
		{
			NotifyPropertyChanged(nameof(Destination));
		}

		public BasicMovementThoughtViewModel() : base(null)
		{
			// this is design time
			if (InDesignMode)
			{
				var d = new RoamingDweller();
				//				Thought = new BasicMovementThought(d, 0, 0);
				Thought = d.Thoughts.FirstOrDefault(t => t is BasicMovementThought);
			}
			else
			{
				throw new Exception("This constructor should only be called in Designer Mode");
			}
		}
	}
}
