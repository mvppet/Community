using Community.Tests.ClassLibrary.BaseClasses;
using CommunityClassLibrary.Dwellers;
using CommunityClassLibrary.Locations;
using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using GeneralWPFControlLibraryInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Community.Tests.ClassLibrary.Locations
{
	[Binding]
	[Scope(Feature = "Basic Cafe")]
	public class BasicCafeSteps: BasicBuildingStepsBase
	{
		BasicCafe cafe;

		[Given(@"I have a new cafe at \((.*), (.*)\)")]
		public void GivenIHaveANewCafeAt(double x, double y)
		{
			var pos = new Mock<IPosition>();
			pos.SetupGet(p => p.Value).Returns(new System.Windows.Point(x, y));
			building = cafe = new BasicCafe(pos.Object);
		}
	}
}
