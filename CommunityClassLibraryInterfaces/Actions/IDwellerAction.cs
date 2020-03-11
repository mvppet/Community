using GeneralWPFControlLibraryInterfaces;

namespace CommunityClassLibraryInterfaces.Actions
{
	public interface IDwellerAction
	{
		IMutableVariable<double> Priority { get; }
		void PerformAction();
	}
}
