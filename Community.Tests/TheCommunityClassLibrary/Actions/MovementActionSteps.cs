using CommunityClassLibrary.Actions;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibraryInterfaces.Thoughts;
using GeneralWPFControlLibraryInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TechTalk.SpecFlow;

namespace Community.Tests.ClassLibrary.Actions
{
    [Binding]
    public class MovementActionSteps
    {
		BasicMovementAction action;
		Mock<IMovementThought> thought;
		Mock<IRoamingDweller> testObject;
		IRoamingDweller dweller;
		//IBuilding building;

		[Given(@"I have an initiating thought")]
		public void GivenIHaveAnInitiatingThought()
		{
			thought = new Mock<IMovementThought>();
		}

		[Given(@"I have a new movement action heading to \((.*), (.*)\) using the thought")]
		public void GivenIHaveANewMovementActionHeadingToUsingTheThought(double x, double y)
		{
			Mock<IPosition> destination = new Mock<IPosition>();
			destination.SetupGet(a => a.Value).Returns(new System.Windows.Point(x, y));

			action = new BasicMovementAction(thought.Object, destination.Object);
		}


		[Then(@"the initiating thought of our action should be the created thought")]
		public void ThenTheInitiatingThoughtOfOurActionShouldBeTheCreatedThought()
		{
			Assert.AreEqual(thought.Object.Id, action.InitiatingThought.Id);
		}

		[Then(@"the destination should be \((.*), (.*)\)")]
		public void ThenTheDestinationShouldBe(double x, double y)
		{
			Assert.AreEqual(new System.Windows.Point(x,y), action.Destination.Value);
		}

		[Then(@"the action name should be ""(.*)""")]
		public void ThenTheActionNameShouldBe(string name)
		{
			Assert.AreEqual(name, action.Name);
		}


		[Given(@"I have a test object at \((.*), (.*)\)")]
		public void GivenIHaveATestObjectAt(double x, double y)
		{
			Mock<IPosition> position = new Mock<IPosition>().SetupAllProperties();

			testObject = new Mock<IRoamingDweller>();
			testObject.SetupGet(to => to.Position).Returns(position.Object);

			dweller = testObject.Object;

		}


		[When(@"I apply the movement action to the object")]
		public void WhenIApplyTheMovementActionToTheObject()
		{
			action.AffectObject(dweller);

		}

		[Then(@"the test object should be heading to \((.*), (.*)\)")]
		public void ThenTheTestObjectShouldBeHeadingTo(double x, double y)
		{
			Assert.AreEqual(new System.Windows.Point(x, y),
				action.Destination.Value,
					$"Object is not heading to {x},{y}, it is heading to {dweller.Position}"
				);
		}


//		[Given(@"I have a new movement action heading to the building")]
//		public void GivenIHaveANewMovementActionHeadingToTheBuilding()
//		{
////			Mock<IPosition> destination = new Mock<IPosition>();
////			destination.SetupGet(a => a.Value).Returns(new System.Windows.Point(x, y));

//			action = new BasicMovementAction(thought.Object, building);
//		}

		//[Then(@"the final action should be to enter the building")]
		//public void ThenTheFinalActionShouldBeToEnterTheBuilding()
		//{
		//	ScenarioContext.Current.Pending();
		//}


	}
}
