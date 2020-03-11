using CommunityClassLibrary.Actions;
using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Actions;
using CommunityClassLibraryInterfaces.Thoughts;
using CommunityClassLibrary;
using GeneralWPFControlLibraryInterfaces;
using System;
using System.Collections.Generic;

namespace CommunityClassLibrary
{
	public abstract class BasicPositionalObjectWithThoughts : BasicPositionalThingWithId, IHasThoughts
	{
//		public IPriorityFactory Priorities { get; } = new BasicPriorityFactory();
//		public ICommunity Community { get; }
		public ICollection<IThought> Thoughts { get; } = new List<IThought>();
		public IActionManager ActionManager { get; } = new BasicActionManager();
		//public TimeSpan PauseForThoughts { get; set; } = new TimeSpan(0,0,0,0,100);
		//public int Iteration { get; private set; }
		protected static Random Rnd { get; } = new Random();

		public event EventHandler<IHasThoughts> Updated;
		public event EventHandler<IHasThoughts> Death;

		public abstract void HaveThoughts();
		public abstract void PerformActions();

		//private Task LifeLoop;
		public IPercent Health { get; protected set; } = new Percent { Value = 100 };

		protected BasicPositionalObjectWithThoughts(string name, IPosition position) : base(name, position)
		{
			// Look for death happening
			Health.Changed += (sender, e) => Health_Changed(sender as IMutableVariable<double>) ;// += Health_Changed;
		}

		private void Health_Changed(IMutableVariable<double> e)
		{
			if (e?.Value <= 0)
			{
				Death?.Invoke(this, this);
			}
		}

		public void LiveLifeFrame(ICommunity community)
		{
			if (Health.Value > 0)
			{
				HaveThoughts();
				PerformActions();
				//++Iteration;
				Updated?.Invoke(this, this);
			}
		}

	}
}
