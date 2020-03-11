using GeneralWPFControlLibraryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityClassLibraryInterfaces.Thoughts
{
	public interface IMovementThought: IThought
	{
		IPosition Destination { get; }
		event EventHandler<IPosition> DestinationChanged;
	}
}
