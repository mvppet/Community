using CommunityClassLibrary;
using GeneralWPFControlLibraryInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using System.Windows;
using TechTalk.SpecFlow;

namespace Community.Tests.ClassLibrary.Generic
{
    [Binding]
    public class BasicPositionalObjectWithThoughtsSteps
    {
		//Mock<BasicPositionalObjectWithThoughts> mockSentientBeing;
		//Mock<ITimer> mockLifeTimer;
		//ITimer lifeTimer;
		//BasicPositionalObjectWithThoughts sentientBeing;

		//[Given(@"I have a basic sentient object called ""(.*)"" at \((.*), (.*)\)")]
  //      public void GivenIHaveABasicSentientObjectCalledAt(string name, double x, double y)
  //      {
		//	// position
		//	Mock<IPosition> pos = new Mock<IPosition>();
		//	pos.SetupGet(p => p.Value).Returns(new Point(x, y));

		//	// life timer
		//	mockLifeTimer = new Mock<ITimer>().SetupAllProperties();
		//	//mockLifeTimer.Setup(t=> t.Elapsed += T_Elapsed);
		//	//			mockLifeTimer.Object.Elapsed += T_Elapsed;
		//	lifeTimer = mockLifeTimer.Object;

		//	// the Being

		//	mockSentientBeing = new Mock<BasicPositionalObjectWithThoughts>(name, pos.Object, lifeTimer).SetupAllProperties();
		//	sentientBeing = mockSentientBeing.Object;
  //      }


		////[Then(@"the iteration should be (.*)")]
  ////      public void ThenTheIterationShouldBe(int num)
  ////      {
		////	Assert.AreEqual(num, sentientBeing.Iteration);
		////}

		//[Then(@"the pause for thoughts should be (.*) milliseconds")]
  //      public void ThenThePauseForThoughtsShouldBeMilliseconds(int millseconds)
  //      {
		//	Assert.AreEqual(millseconds, sentientBeing.PauseForThoughts.TotalMilliseconds);
		//}

		//[Then(@"the health should be (.*) percent")]
  //      public void ThenTheHealthShouldBePercent(double health)
  //      {
		//	Assert.AreEqual(health, sentientBeing.Health.Value);
		//}

		//[Then(@"the object should be at \((.*), (.*)\)")]
		//public void ThenTheObjectShouldBeAt(double x, double y)
		//{
		//	Assert.AreEqual(new Point(x,y), sentientBeing.Position.Value);
		//}

		//[Then(@"the name should be ""(.*)""")]
		//public void ThenTheNameShouldBe(string name)
		//{
		//	Assert.AreEqual(name, sentientBeing.Name);
		//}

		////[Then(@"the number of priorities should be (.*)")]
		////public void ThenTheNumberOfPrioritiesShouldBe(int num)
		////{
		////	Assert.AreEqual(num, sentientBeing.Priorities?.Count);
		////}

		//[Then(@"the number of thoughts should be (.*)")]
		//public void ThenTheNumberOfThoughtsShouldBe(int num)
		//{
		//	Assert.AreEqual(num, sentientBeing.Thoughts?.Count);
		//}

		//[Then(@"the number of actions should be (.*)")]
		//public void ThenTheNumberOfActionsShouldBe(int num)
		//{
		//	Assert.AreEqual(num, sentientBeing.ActionManager?.Count);
		//}

		//[When(@"I wait for (.*) seconds")]
		//public void WhenIWaitForSeconds(Decimal seconds)
		//{
		//	Task.Delay((int)(seconds * 1000)).Wait();
		//}

		//[Then(@"the iteration should not be (.*)")]
		//public void ThenTheIterationShouldNotBe(int num)
		//{
		//	Assert.AreNotEqual(num, sentientBeing.Iteration);
		//}
		//[When(@"health becomes (.*)")]
		//public void WhenHealthBecomes(double healthValue)
		//{
		//	sentientBeing.Health.Value = healthValue;
		//}

		//[Then(@"a death event should happen")]
		//public void ThenADeathEventShouldHappen()
		//{
		//	ScenarioContext.Current.Pending();
		//}
		//[Given(@"I register a death event")]
		//public void GivenIRegisterADeathEvent()
		//{
		//	ScenarioContext.Current.Pending();

		//}
		//[When(@"I wait for (.*) iterations")]
		//public void WhenIWaitForIterations(int iterations)
		//{
		//	for(int i = 0; i < iterations; ++i)
		//	{
		//		mockLifeTimer.Raise(p => p.Elapsed+=null, this, null);
		//	}
		//}

	}
}
