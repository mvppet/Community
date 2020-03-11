using CommunityClassLibraryInterfaces.Thoughts;
using GeneralWPFControlLibraryViewModels;

namespace CommunityViewModels
{
	public class BasicThoughtViewModel: ViewModelBase, IThoughtViewModel
	{
		public IThought Thought { get; protected set; }
		public BasicThoughtViewModel(IThought thought) => Thought = thought;
	}
}
