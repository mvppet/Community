using CommunityClassLibraryInterfaces.Priorities;
using GeneralWPFControlLibraryInterfaces;
using System.Collections.Generic;

namespace CommunityClassLibrary.Priorities
{
	public class BasicPriorityFactory : IPriorityFactory
	{
		private IDictionary<PriorityType, IPriority> priorities = new Dictionary<PriorityType, IPriority>();
		private static object lockObject = new object();
		public int Count => priorities.Count;


		public IPriority GetPriority(PriorityType pt) => LookupOrCreate(pt);
		private IPriority LookupOrCreate(PriorityType pt)
		{
			IPriority retval = null;

			lock (lockObject)
			{
				if (!priorities.TryGetValue(pt, out retval))
				{
					// doesn't exist so far, so add it
					priorities.Add(pt, retval = new BasicPriority(pt, 0));
				}
			}

			return retval;
		}

		public void SetPriority(PriorityType pt, IPercent percent)
		{
			GetPriority(pt).Percent.Value = percent.Value;
		}
	}
}
