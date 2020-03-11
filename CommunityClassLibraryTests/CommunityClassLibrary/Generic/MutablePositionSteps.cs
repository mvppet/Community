using GeneralWPFClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace CommunityTests.CommunityClassLibrary.Generic
{
    [Binding]
    public class MutablePositionSteps
    {
		MutablePosition pos;

		[Given(@"I have an object to move at \((.*), (.*)\)")]
		public void GivenIHaveAnObjectToMoveAt(double x, double y)
		{
			pos = new MutablePosition(new System.Windows.Point(x, y));
		}

		[When(@"I move it to \((.*), (.*)\)")]
		public void WhenIMoveItTo(double x, double y)
		{
			pos.Value = new System.Windows.Point(x, y);
		}

		[Then(@"the object should be at \((.*), (.*)\)")]
		public void ThenTheObjectShouldBeAt(double x, double y)
		{
			Assert.AreEqual(pos.Value, new System.Windows.Point(x, y));
		}

		[Then(@"the old position should be \((.*), (.*)\)")]
		public void ThenTheOldPositionShouldBe(double oldx, double oldy)
		{
			Assert.AreEqual(pos.PreviousValue, new System.Windows.Point(oldx, oldy));
		}


	}
}
