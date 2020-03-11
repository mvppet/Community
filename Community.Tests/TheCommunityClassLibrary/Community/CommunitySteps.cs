using CommunityClassLibrary.Dwellers;
using CommunityClassLibrary.IoC;
using CommunityClassLibrary.Locations;
using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using GeneralWPFControlLibraryInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Windows;
using TechTalk.SpecFlow;

namespace Community.Tests.ClassLibrary.Community
{
    [Binding]
    public class CommunitySteps
    {
		ICommunity community;
		IHome home;
		IRoamingDweller dweller;
		IBuilding building;

        [Given(@"I have a new community")]
        public void GivenIHaveANewCommunity()
        {
			community = IoCContainer.Resolve<ICommunity>();
			community.Clear();
        }
        
        [Then(@"there should be (.*) dwellers in the community")]
        public void ThenThereShouldBeDwellersInTheCommunity(int numDwellers)
        {
			Assert.AreEqual(numDwellers, community.Dwellers?.Count);
        }
        
        [Then(@"there should be (.*) homes in the community")]
        public void ThenThereShouldBeHomesInTheCommunity(int numHomes)
        {
			Assert.AreEqual(numHomes, community.Homes?.Count);
		}

		[Then(@"there should be (.*) workplaces in the community")]
        public void ThenThereShouldBeWorkplacesInTheCommunity(int numWorkplaces)
        {
			Assert.AreEqual(numWorkplaces, community.Workplaces?.Count);
		}

		[Then(@"the id of the dweller should be (.*)")]
		public void ThenTheIdOfTheDwellerShouldBe(int dwellerId)
		{
			Assert.AreEqual(dwellerId, community.Dwellers[0].Id);
		}

		[Then(@"the name of the dweller should be ""(.*)""")]
		public void ThenTheNameOfTheDwellerShouldBe(string dwellerName)
		{
			Assert.AreEqual(dwellerName, community.Dwellers[0].Name);
		}

		[Then(@"there should be one dweller in the community at \((.*), (.*)\)")]
		public void ThenThereShouldBeOneDwellerInTheCommunityAt(double x, double y)
		{
			Assert.AreEqual(1, community.Dwellers.Count);
			Assert.AreEqual(new Point(x,y), community.Dwellers[0].Position.Value);
		}

		[Given(@"I add a home to the community at \((.*), (.*)\)")]
		public void WhenIAddAHomeToTheCommunityAt(double x, double y)
		{
			home = new BasicHome(null, new BasicPosition(x, y));
			community.Add(home);
		}

		[Then(@"there should be one home in the community at \((.*), (.*)\)")]
		public void ThenThereShouldBeOneHomeInTheCommunityAt(double x, double y)
		{
			Assert.AreEqual(1, community.Homes.Count);
			Assert.AreEqual(new Point(x, y), community.Homes[0].Position.Value);
		}

		[Given(@"I add a workplace to the community at \((.*), (.*)\)")]
		public void WhenIAddAWorkplaceToTheCommunityAt(double x, double y)
		{
			var mockWorkplace = new Mock<IWorkplace>().SetupAllProperties();
			mockWorkplace.SetupGet(d => d.Position).Returns(NewPosition(x, y));

			community.Add(mockWorkplace.Object);
		}

		[Then(@"there should be one workplace in the community at \((.*), (.*)\)")]
		public void ThenThereShouldBeOneWorkplaceInTheCommunityAt(double x, double y)
		{
			Assert.AreEqual(1, community.Workplaces.Count);
			Assert.AreEqual(new Point(x, y), community.Workplaces[0].Position.Value);
		}

		[Given(@"I add a dweller to the community at \((.*), (.*)\) named ""(.*)""")]
		public void WhenIAddADwellerToTheCommunityAtNamedWithId(double x, double y, string dwellerName)
		{
			//var mockLifeTimer = new Mock<ITimer>().SetupAllProperties();

			dweller = new RoamingDweller(dwellerName);
			community.Add(dweller);
			dweller.Position.Value = new Point(x, y);

		}

		[Then(@"the home should have (.*) occupant")]
		public void ThenTheHomeShouldHaveOccupant(int numOccupants)
		{
			Assert.AreEqual(numOccupants, community.Homes[0].Occupants.Count);
		}

		[Then(@"the occupant of the home should be named ""(.*)""")]
		public void ThenTheOccupantOfTheHomeShouldBeNamedWithId(string dwellerName)
		{
			Assert.AreEqual(dwellerName, community.Homes[0].Occupants[0].Name);
		}

		[Then(@"the dweller should not be inside a building")]
		public void ThenTheDwellerShouldNotBeInsideABuilding()
		{
			Assert.IsNull(dweller.InsideBuilding);
		}
		[Then(@"the dweller should be inside a building")]
		public void ThenTheDwellerShouldBeInsideABuilding()
		{
			Assert.IsNotNull(dweller.InsideBuilding);
		}

		[When(@"I move the dweller to \((.*), (.*)\)")]
		public void WhenIMoveTheDwellerTo(double x, double y)
		{
			dweller.Position.Value = new Point(x, y);
		}

		[Given(@"I add a cafe to the community at \((.*), (.*)\)")]
		public void GivenIAddACafeToTheCommunityAt(double x, double y)
		{
			var mockCafe = new Mock<ICafe>().SetupAllProperties();
			mockCafe.SetupGet(d => d.Position).Returns(NewPosition(x, y));

			community.Add(mockCafe.Object);
		}

		[When(@"ask the community to find the nearest cafe to \((.*), (.*)\)")]
		public void WhenAskTheCommunityToFindTheNearestCafeTo(double x, double y)
		{
			building = community.FindNearestCafe(new Point(x,y));
		}

		[Then(@"the found building should at \((.*), (.*)\)")]
		public void ThenTheFoundBuildingShouldAt(double x, double y)
		{
			Assert.AreEqual(new Point(x,y), building.Position.Value);
		}

		[When(@"ask the community to find the nearest home to \((.*), (.*)\)")]
		public void WhenAskTheCommunityToFindTheNearestHomeTo(double x, double y)
		{
			building = community.FindNearestHome(new Point(x, y));
		}

		[When(@"ask the community to find the nearest workplace to \((.*), (.*)\)")]
		public void WhenAskTheCommunityToFindTheNearestWorkplaceTo(double x, double y)
		{
			building = community.FindNearestWorkplace(new Point(x, y));
		}







		/// <summary>
		/// Create a position Mock
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		IPosition NewPosition(double x, double y)
		{
			var pos = new Mock<IPosition>();
			pos.SetupGet(p => p.Value).Returns(new Point(x, y));
			return pos.Object;
		}
	}
}
