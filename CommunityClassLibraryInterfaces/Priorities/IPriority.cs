using GeneralWPFControlLibraryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityClassLibraryInterfaces.Priorities
{
	public interface IPriority
	{
		/// <summary>
		/// What is this trait called?
		/// </summary>
		PriorityType PriorityType { get; }

		/// <summary>
		/// How likely are we to do this?
		/// </summary>
		IPercent Percent { get; }

	}
}
