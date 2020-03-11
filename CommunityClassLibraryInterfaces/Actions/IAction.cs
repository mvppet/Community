using GeneralWPFControlLibraryInterfaces;
using CommunityClassLibraryInterfaces.Thoughts;

namespace CommunityClassLibraryInterfaces.Actions
{
	public interface IAction: IIdAndName
	{
		IThought InitiatingThought { get; }
		IPercent Priority { get; }
		IPositionalObject Subject { get; }
		ActionType ActionType { get; }
	
		void AffectObject(IPositionalObject dweller);
	}
}
