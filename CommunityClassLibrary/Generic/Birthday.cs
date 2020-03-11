using CommunityClassLibraryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityClassLibrary
{
	public class Birthday : IBirthday
	{
		public DateTime Born { get; } = DateTime.Now;
		public double Age => (DateTime.Now - Born).TotalMinutes;
		public double AgeRounded => Math.Round((DateTime.Now - Born).TotalMinutes, 1);
		public override string ToString() => Born.ToString();

	}
}
