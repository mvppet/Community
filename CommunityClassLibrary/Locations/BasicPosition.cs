using CommunityClassLibrary;
using GeneralWPFControlLibraryInterfaces;
using System;
using System.Windows;

namespace CommunityClassLibrary.Locations
{
	public class BasicPosition : MutablePosition
	{
		public BasicPosition()
		{
		}
		public BasicPosition(Point p) : base(p)
		{
		}
		public BasicPosition(double x, double y) : base(new Point(x, y))
		{
		}
	}
}
