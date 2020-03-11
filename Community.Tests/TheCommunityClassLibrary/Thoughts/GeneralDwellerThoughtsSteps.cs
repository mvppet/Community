using CommunityClassLibrary.Actions;
using CommunityClassLibrary.Dwellers;
using CommunityClassLibrary.Locations;
using CommunityClassLibrary.Thoughts;
using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Actions;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibraryInterfaces.Thoughts;
using GeneralWPFControlLibraryInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;

namespace Community.Tests.ClassLibrary.Thoughts
{
	[Binding]
	[Scope(Feature = "General Dweller Thoughts")]
	public class GeneralDwellerThoughtsSteps //: BasicBuildingStepsBase
	{
		IRoamingDweller dweller;
		//ICommunity community;
		//BasicActionManager manager;
		IBuilding building;
		IMovementThought thought;

		[Given(@"I have a dweller to enter the building at \((.*), (.*)\)")]
		public void GivenIHaveADwellerToEnterTheBuildingAt(double x, double y)
		{
			dweller = new RoamingDweller();
			dweller.Position.Value = new System.Windows.Point(x, y);
		}

		[Given(@"I have a building to enter at \((.*), (.*)\)")]
		public void GivenIHaveABuildingToEnterAt(double x, double y)
		{
			var mockPosition = new Mock<IPosition>();
			mockPosition.SetupGet(p=>p.Value).Returns(new System.Windows.Point(x, y));
			var mockBuilding = new Mock<BasicBuildingBase>("Test Building", mockPosition.Object).SetupAllProperties();
			building = mockBuilding.Object;
		}
		 
		[Given(@"I have an initiating thought to head to the building")]
		public void GivenIHaveAnInitiatingThoughtToHeadToTheBuilding()
		{
			//var mockthought = new Mock<BasicMovementThought>(dweller, building.Position).SetupAllProperties();
			//thought = mockthought.Object;
			thought = new BasicMovementThought(dweller, building);
		}

		[When(@"the thought is thunk")]
		public void WhenTheThoughtIsThunk()
		{
			thought.Think();
		}

		[Then(@"the dweller object should be heading to the building")]
		public void ThenTheDwellerObjectShouldBeHeadingToTheBuilding()
		{
			// find the first movement action
			var action = dweller.ActionManager.Actions[0] as BasicMovementAction;
			Assert.IsNotNull(action);

			// is it heading towards the right building?
			Assert.AreEqual(building.Position.Value, action.FinalDestination.Value);
		}

		[Then(@"the final action should be to enter the building")]
		public void ThenTheFinalActionShouldBeToEnterTheBuilding()
		{
			var action = dweller.ActionManager.Actions[dweller.ActionManager.Count-1] as EnterBuildingAction;
			Assert.IsNotNull(action, "Final Action is not an EnterBuildingAction");

			// is it the right building
			Assert.AreEqual(building.Id, action.BuildingToEnter.Id);
		}



		//[Given(@"I have a crisismood dweller")]
		//public void GivenIHaveACrisismoodDweller()
		//{
		//	// create life timer
		//	var mockLifeTimer = new Mock<ITimer>().SetupAllProperties();
		//	var lifeTimer = mockLifeTimer.Object;

		//	dweller = new RoamingDweller(community, lifeTimer);

		//}


		//[Given(@"I have a crisismood community")]
		//public void GivenIHaveACrisisMoodCommunity()
		//{
		//	community = CommunityClassLibrary.Community.Instance;
		//}

		//[Given(@"the dweller's mood is ""(.*)""")]
		//public void GivenTheDwellerSMoodIs(string p0)
		//{
		//}


		//		BasicRandomMovementThought thought;
		//		IRandom randomGenerator;
		//		//IRandom randomX;
		//		//IRandom randomY;


		//		[Given(@"I have a thought of moving to \((.*), (.*)\)")]
		//		public void GivenIHaveAThoughtOfMovingTo(double x, double y)
		//		{
		//			Mock<IPosition> mockPos = new Mock<IPosition>();
		//			mockPos.SetupGet(p=>p.Value).Returns(new Point(x,y));

		//			Mock<IRandom> mockRndX = new Mock<IRandom>();
		////			mockRndX.Setup(x=>x.NextPercent()).re




		//			thought = new BasicRandomMovementThought(dweller, randomGenerator);
		//			//thought.
		//			dweller.Thoughts.Add(thought);
		//		}

		//		[When(@"I use the thought to create actions")]
		//		public void WhenIUseTheThoughtToCreateActions()
		//		{
		//			thought.Think();
		//		}

		//		[Then(@"the dweller's Action Manager should have movement actions ending at \((.*), (.*)\)")]
		//		public void ThenTheDwellerSActionManagerShouldHaveMovementActionsEndingAt(double x, double y)
		//		{
		//			var lastPoint = default(Point);
		//			int numPoints = 0;
		//			foreach(var t in dweller.ActionManager.Actions)
		//			{
		//				if(t is IMovementThought mt)
		//				{
		//					// we have some movement. Where are we going?
		//					lastPoint = mt.Destination.Value;
		//					++numPoints;
		//				}
		//			}

		//			// did we get anything?
		//			Assert.AreNotEqual(0, numPoints, "There were no movement actions");

		//			// where did we end up?
		//			Assert.AreEqual(new Point(x,y), lastPoint, $"Final location should be ({x},{y}), but are ({lastPoint.X},{lastPoint.Y})");
		//		}


		//		[Given(@"a random nbumber generator is set to return (.*)%")]
		//		public void GivenARandomNbumberGeneratorIsSetToReturn(double percent)
		//		{
		//			var mockPercent = new Mock<IPercent>();
		//			mockPercent.SetupGet(p => p.Value).Returns(percent);

		//			Mock<IRandom> mockRandom = new Mock<IRandom>();
		//			mockRandom.Setup(r => r.NextPercent()).Returns(mockPercent.Object);
		//			//			rndMock.SetupGet(r=>r.NextDouble()).Returns(percent);

		//			randomGenerator = mockRandom.Object;
		//		}

		//		[Given(@"the dweller has (.*)% probability of moving")]
		//		public void GivenTheDwellerHasProbabilityOfMoving(double percent)
		//		{
		//			thought.ProbabilityOfMoving.Percent.Value = percent;
		//		}

	}
}
