using CommunityClassLibrary.Dwellers;
using CommunityClassLibrary.IoC;
using CommunityClassLibrary.Thoughts;
using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibrary;
using GeneralWPFControlLibraryInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TechTalk.SpecFlow;

namespace Community.Tests.ClassLibrary.BaseClasses
{
	public class BasicBuildingStepsBase
	{
		//protected ICommunity community;
		public ICommunity Community { get; } = IoCContainer.Resolve<ICommunity>();

		protected IBuilding building;
		protected IRoamingDweller dweller;
		//protected ITimer lifeTimer;
		//protected Mock<ITimer> mockLifeTimer;

		#region Community

		[Given(@"I have a community")]
		public void GivenIHaveACommunity()
		{
			//community = CommunityClassLibrary.Community.Instance;
		}

		#endregion
		#region Dweller

		[Given(@"I have a dweller")]
		public void GivenIHaveADweller()
		{
			// create life timer
			//mockLifeTimer = new Mock<ITimer>().SetupAllProperties();
			//lifeTimer = mockLifeTimer.Object;

			dweller = new RoamingDweller();

		}

		[When(@"I wait for the next Dweller iteration")]
		public void WhenIWaitForTheNextDwellerIteration()
		{
			dweller.LiveLifeFrame(Community);
			//mockLifeTimer.Raise(m => m.Elapsed += null, new EventArgs());
		}

		[Given(@"the dweller has a position of \((.*) ,(.*)\)")]
		public void GivenTheDwellerHasAPositionOf(double x, double y)
		{
			dweller.Position.Value = new Point(x, y);
		}

		[Then(@"the dweller's destination should be \((.*), (.*)\)")]
		public void ThenTheDwellerSDestinationShouldBe(double x, double y)
		{
			Assert.AreEqual(new Point(x, y), dweller.Position.Value);
		}


		//[Given(@"the dweller has a lower food threshold of (.*)%")]
		//public void GivenTheDwellerHasALowerFoodThresholdOf(Decimal p0)
		//{
		//	ScenarioContext.Current.Pending();
		//}

		[Then(@"the dweller's final destination should be \((.*), (.*)\)")]
		public void ThenTheDwellerSFinalDestinationShouldBe(double x, double y)
		{

			Assert.AreEqual(new Point(x,y), dweller.Destination.Value);
		}




		#endregion
		#region Buildings

		[When(@"I add the building to the community")]
		public void WhenIAddTheBuildingToTheCommunity()
		{
			Community.Add(building);
		}

		[Then(@"there should be (.*) dwellers inside the building")]
		public void ThenThereShouldBeDwellersInsideTheBuilding(int numDwellers)
		{
			Assert.AreEqual(numDwellers, building.Occupants.Count);
		}

		[Given(@"the resource cost per iteration of the building is (.*)")]
		public void GivenTheResourceCostPerIterationOfTheBuildingIs(double amount)
		{
			building.ResourceCostPerIteration = amount;
		}
		[Given(@"the reward per iteration of the building is (.*)")]
		public void GivenTheRewardPerIterationOfTheBuildingIs(double amount)
		{
			building.RewardPerIteration = amount;
		}

		[Given(@"I add the dweller to the building")]
		public void GivenIAddTheDwellerToTheBuilding()
		{
			dweller.EnterBuilding(building);
		}
		
		[Then(@"the position of the building should be \((.*), (.*)\)")]
		public void ThenThePositionOfTheHomeShouldBe(double x, double y)
		{
			Assert.AreEqual(new System.Windows.Point(x, y), building.Position.Value);
		}

		[When(@"the building affects the dweller")]
		public void WhenTheBuildingAffectsTheDweller()
		{
			building.AffectObject(dweller);
		}

		#endregion
		#region Resources

		[Given(@"the dweller has health of (.*)%")]
		public void GivenTheDwellerHasHealthOf(double health)
		{
			dweller.Health.Value = health;
		}

		[Then(@"the dweller's health should be (.*)%")]
		public void ThenTheDwellersHealthShouldBe(double health)
		{
			Assert.AreEqual(health, dweller.Health.Value);
		}


		[Given(@"the dweller has food of (.*)%")]
		public void GivenTheDwellerHasFoodOf(double food)
		{
			dweller.Food.Value = food;
		}

		[Then(@"the dweller's food should be (.*)%")]
		public void ThenTheDwellersFoodShouldBe(double food)
		{
			Assert.AreEqual(food, dweller.Food.Value);
		}

		[Given(@"the dweller has (.*) cash")]
		public void GivenTheDwellerHasCash(double cash)
		{
			dweller.Money.Value = cash;
		}

		[Then(@"the dweller's cash should be (.*)")]
		public void ThenTheDwellerSCashShouldBe(double cash)
		{
			Assert.AreEqual(cash, dweller.Money.Value);
		}

		[Given(@"the dweller has an upper food threshold of (.*)%")]
		public void GivenTheDwellerHasAnUpperFoodThresholdOf(double threshold)
		{
			((BasicFoodThought)dweller.Thoughts.First(t => t is BasicFoodThought)).Threshold.Value.Value = threshold;
		}
		[Given(@"the dweller has a lower food threshold of (.*)%")]
		public void GivenTheDwellerHasALowerFoodThresholdOf(double thresholdValue)
		{
			var thought = dweller.Thoughts.First(t => t is BasicFoodThought);

			var thresholdObject = thought.Threshold;
			thresholdObject.LowerThreshold.Value = thresholdValue;


			//((BasicFoodThought)dweller.Thoughts.First(t => t is BasicFoodThought)).Threshold.Value.Value = threshold;
		}

		[Given(@"the dweller has an upper sleep threshold of (.*)%")]
		public void GivenTheDwellerHasAnUpperSleepThresholdOf(double threshold)
		{
			((BasicSleepThought)dweller.Thoughts.First(t => t is BasicSleepThought)).Threshold.UpperThreshold.Value = threshold;
		}
		[Given(@"the dweller has a lower sleep threshold of (.*)%")]
		public void GivenTheDwellerHasALowerSleepThresholdOf(double threshold)
		{
			((BasicSleepThought)dweller.Thoughts.First(t => t is BasicSleepThought)).Threshold.LowerThreshold.Value = threshold;
		}



		#endregion

		#region Tests

		protected void Pending()
		{
			ScenarioContext.Current.Pending();
		}

		#endregion
	}
}
