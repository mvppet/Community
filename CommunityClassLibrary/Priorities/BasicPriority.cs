using CommunityClassLibraryInterfaces.Priorities;
using CommunityClassLibrary;
using GeneralWPFControlLibraryInterfaces;

namespace CommunityClassLibrary.Priorities
{
	public class BasicPriority : IPriority
	{
		public PriorityType PriorityType { get; }
		public IPercent Percent { get; }
		public static IPriority DefaultPriority { get; } = new BasicPriority(PriorityType.Unknown, 0);

		public BasicPriority(PriorityType pt, double value)
		{
			this.PriorityType = pt;
			Percent = new FloatingPointValue { Value=value };
		}
		public override string ToString() => $"{Percent.RoundedValue}%";
	}
}
