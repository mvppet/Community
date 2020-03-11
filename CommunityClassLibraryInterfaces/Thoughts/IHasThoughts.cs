using CommunityClassLibraryInterfaces.Actions;
using CommunityClassLibraryInterfaces.Priorities;
using GeneralWPFControlLibraryInterfaces;
using System;
using System.Collections.Generic;

namespace CommunityClassLibraryInterfaces.Thoughts
{
	public interface IHasThoughts
	{
		/// <summary>
		/// What are our Priorities in life?
		/// </summary>
//		IPriorityFactory Priorities { get; }

		/// <summary>
		/// Our Thoughts
		/// </summary>
		void HaveThoughts();
		ICollection<IThought> Thoughts { get; }

		/// <summary>
		/// The Actions we perform based on our Thoughts and Priorities
		/// </summary>
		void PerformActions();
		IActionManager ActionManager { get; }

		//TimeSpan PauseForThoughts { get; set; }
		IPercent Health { get; }
		//int Iteration { get; }

		/// <summary>
		/// this is called at end of one iteration of thoughts and actions
		/// </summary>
		event EventHandler<IHasThoughts> Updated;

		/// <summary>
		/// This is called when we die
		/// </summary>
		event EventHandler<IHasThoughts> Death;

		void LiveLifeFrame(ICommunity community);


	}
}
