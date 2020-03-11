using CommunityClassLibrary.IoC;
using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Thoughts;
using CommunityClassLibrary;
using GeneralWPFControlLibraryInterfaces;
using System;

namespace CommunityClassLibrary.Thoughts
{
	public abstract class ThoughtBase : IThought
	{
		public virtual long Id => throw new NotImplementedException();
		public virtual string Name => throw new NotImplementedException();
		protected IHasThoughts thoughtObject = null;
		protected IRoamingDweller dweller = null;
		private IRandom _rnd = IoCContainer.Resolve<IRandom>();
		protected IRandom Random { get => _rnd; }
		public abstract IMutableVariable<double> Value { get; }
		private IMutableVariable<double> PreviousValue;

		public IThreshold Threshold { get; } = new BasicThreshold(new Percent(30), new Percent(90));
		protected ICommunity Community { get; } = IoCContainer.Resolve<ICommunity>();


		public ThoughtBase(IHasThoughts thoughtObject)
		{
			this.thoughtObject = thoughtObject ?? throw new ArgumentNullException($"{nameof(thoughtObject)} cannot be null");
			if (thoughtObject is IRoamingDweller d)
			{
				dweller = d;
			}
		}

		public void Think()
		{
			// are we a dweller? If so, do our own thoughts
			if (dweller!=null)
			{
				ThinkAboutActions();
			}

			PreviousValue = Value;

		}
		public abstract void ThinkAboutActions();

	}
}
