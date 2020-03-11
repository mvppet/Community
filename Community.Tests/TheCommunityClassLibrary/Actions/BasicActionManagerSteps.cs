using CommunityClassLibrary.Actions;
using CommunityClassLibraryInterfaces.Actions;
using GeneralWPFControlLibraryInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TechTalk.SpecFlow;

namespace Community.Tests.ClassLibrary.Actions
{
	[Binding]
	public class BasicActionManagerSteps
	{
		BasicActionManager manager;

		[Given(@"I have a new basic action manager")]
		public void GivenIHaveANewBasicActionManager() => manager = new BasicActionManager();

		[Then(@"the manager should have (.*) actions")]
		public void ThenTheManagerShouldHaveActions(int numActions) => Assert.AreEqual(numActions, manager.Count, "Manager has no actions");

		[When(@"i remove the ""(.*)"" actions")]
		public void WhenIRemoveTheActions(string actionName)
		{
			manager.Remove(GetActionType(actionName));
		}

		[When(@"I add an action named ""(.*)"" with priority (.*)")]
		public void WhenIAddAnActionNamedWithPriority(string name, double priority) => manager.Push(MakeNewAction(GetActionType(name), priority).Object);

		[When(@"I add a persistent action named ""(.*)"" with priority (.*)")]
		public void WhenIAddAPersistentActionNamedWithPriority(string name, double priority) => manager.Push(MakeNewAction(GetActionType(name), priority).Object);

		[When(@"I add an action named ""(.*)""")]
		public void WhenIAddAnActionNamed(string actionName) => manager.Push(MakeNewAction(GetActionType(actionName), 100.0).Object);


		//[Then(@"Action (.*) should be ""(.*)"" with priority (.*)")]
		//public void ThenActionShouldBeWithPriority(int actionNumberFrom1, string actionName, double priority)
		//{

		//}
		[Then(@"Action (.*) should be ""(.*)"" with priority (.*)")]
		public void ThenActionShouldBeWithPriority(int itemNumber, string actionName, double priority)
		{
			var index = itemNumber - 1; // "index" is origin 1, so make it origin 0
			var a = manager.Actions[index];
			Assert.AreEqual(actionName, a.Name);
			Assert.AreEqual(priority, a.Priority.Value);
		}




		[When(@"I add (.*) actions")]
		public void WhenIAddActions(int numActions)
		{
			int maxActions = Enum.GetValues(typeof(ActionType)).Length;

			if (numActions>maxActions)
			{
				throw new ArgumentOutOfRangeException($"ActionType only has {maxActions} values");
			}

			for (int i = 0; i < numActions; ++i)
			{
				manager.Push(MakeNewAction((ActionType)i, 100.0).Object);
			}
		}

		private ActionType GetActionType(string actionName)
		{
			if (Enum.TryParse(actionName, out ActionType actionType))
			{
				return actionType;
			}
			else
			{
				throw new InvalidCastException($"Cannot convert \"{actionName}\" to ActionType enum");
			}
		}

		//// misc
		//private IAction GetAction(string name) => manager.GetAction(GetActionType(name)) ?? throw new NullReferenceException($"Manager does not contain an action named \"{name}\"");


		private Mock<IAction> MakeNewAction(ActionType actionType, double priority)
		{
			// make a percent
			var mockPercent = new Mock<IPercent>();
			mockPercent.SetupGet(p => p.Value).Returns(priority);

			// make an action
			var mockAction = new Mock<IAction>();
			mockAction.SetupGet(a => a.ActionType).Returns(actionType);
			mockAction.SetupGet(a => a.Name).Returns(actionType.ToString());
			mockAction.SetupGet(a => a.Priority).Returns(mockPercent.Object);

			return mockAction;
		}
	}
}
