using Community.Tests.ClassLibrary.BaseClasses;
using CommunityClassLibrary.Locations;
using GeneralWPFControlLibraryInterfaces;
using Moq;
using System.Windows;
using TechTalk.SpecFlow;

namespace Community.Tests.ClassLibrary.Thoughts
{
	[Binding]
	[Scope(Feature = "Need For Sleep")]
	public class NeedForSleepSteps: BasicBuildingStepsBase
	{
		BasicHome home;

		[Given(@"I have a new home at \((.*), (.*)\)")]
		public void GivenIHaveANewHomeAtNamed(double x, double y)
		{
			var pos = new Mock<IPosition>();
			pos.SetupGet(p => p.Value).Returns(new Point(x, y));
			building = home = new BasicHome(pos.Object);
			Community.Add(home);
		}
		

		[When(@"I change the dweller health to (.*)%")]
		public void WhenIChangeTheDwellerHealthTo(double value)
		{
			dweller.Health.Value = value;
		}

		[Then(@"the dweller should be asleep")]
		public void ThenTheDwellerShouldBeAsleep()
		{
			ScenarioContext.Current.Pending();
		}

		[Then(@"the dweller should be wake up")]
		public void ThenTheDwellerShouldBeWakeUp()
		{
			ScenarioContext.Current.Pending();
		}



	}
}
