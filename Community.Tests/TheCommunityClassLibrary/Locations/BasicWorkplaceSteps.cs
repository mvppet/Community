using Community.Tests.ClassLibrary.BaseClasses;
using CommunityClassLibrary.Locations;
using CommunityClassLibraryInterfaces.Locations;
using GeneralWPFControlLibraryInterfaces;
using Moq;
using System;
using TechTalk.SpecFlow;

namespace Community.Tests.ClassLibrary.Locations
{
    [Binding]
	[Scope(Feature = "Basic Workplace")]
	public class BasicWorkplaceSteps: BasicBuildingStepsBase
    {
		IWorkplace workplace;

		[Given(@"I have a new workplace at \((.*), (.*)\)")]
		public void GivenIHaveANewWorkplaceAt(double x, double y)
		{
			var pos = new Mock<IPosition>();
			pos.SetupGet(p => p.Value).Returns(new System.Windows.Point(x, y));
			building = workplace = new BasicWorkplace(pos.Object);
		}

	}
}
