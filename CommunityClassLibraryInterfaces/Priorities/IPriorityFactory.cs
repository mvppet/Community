using GeneralWPFControlLibraryInterfaces;

namespace CommunityClassLibraryInterfaces.Priorities
{
	public enum PriorityType
	{
		Unknown,
		ProbabilityOfMoving,
		SleepThreshold,
		HungerThreshold
	}

	public interface IPriorityFactory
	{
		IPriority GetPriority(PriorityType name);
		void SetPriority(PriorityType pt, IPercent percent);
		int Count { get; }
	}
}
