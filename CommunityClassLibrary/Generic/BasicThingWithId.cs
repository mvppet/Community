using CommunityClassLibrary.IoC;
using CommunityClassLibraryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityClassLibrary
{
	public class BasicThingWithId
	{
		private static int globalId = 0;
		public long Id { get; } = ++globalId;
		public string Name { get; private set; }
		public string ToStringName { get; private set; }
		public ICommunity Community { get; } = IoCContainer.Resolve<ICommunity>();

		public BasicThingWithId() : this(null) { }
		public BasicThingWithId(string name)
		{
			Id = ++globalId;
			Name = name ?? $"Object {Id}";

			ToStringName = $"ID {Id}: {Name}";
		}

		public override string ToString() => ToStringName;

	}
}
