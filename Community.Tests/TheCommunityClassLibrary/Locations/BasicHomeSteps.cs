using Community.Tests.ClassLibrary.BaseClasses;
using CommunityClassLibrary;
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
	[Scope(Feature = "Basic Home")]
	public class BasicHomeSteps: BasicBuildingStepsBase
	{
		BasicHome home;


		[Given(@"I have a new home at \((.*), (.*)\) named ""(.*)""")]
		public void GivenIHaveANewHomeAtNamed(double x, double y, string homeName)
		{
			var pos = new Mock<IPosition>();
			pos.SetupGet(p => p.Value).Returns(new System.Windows.Point(x, y));
			building = home = new BasicHome(homeName, pos.Object);
			
		}

	}
}
