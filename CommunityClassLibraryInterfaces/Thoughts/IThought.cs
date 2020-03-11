using GeneralWPFControlLibraryInterfaces;

namespace CommunityClassLibraryInterfaces.Thoughts
{
	public interface IThought: IIdAndName
	{
		void Think();
		IMutableVariable<double> Value { get; }
		IThreshold Threshold { get; }


	}
}
