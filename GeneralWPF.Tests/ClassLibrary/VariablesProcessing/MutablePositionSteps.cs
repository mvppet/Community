using GeneralWPFClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace GeneralWPF.Tests.ClassLibrary.VariablesProcessing
{
    [Binding]
    public class MutablePositionSteps
    {
		MutablePosition pos;

		[Given(@"I have a new position object")]
        public void GivenIHaveANewPositionObject()
        {
			pos = new MutablePosition();
		}

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

		[Then(@"the coordinates should be \((.*), (.*)\)")]
		public void ThenTheCoordinatesShouldBe(double x, double y)
		{
			Assert.AreEqual(x, pos.Value.X);
			Assert.AreEqual(y, pos.Value.Y);
		}

		[Then(@"the string value should be ""(.*)""")]
		public void ThenTheStringValueShouldBe(string stringValue)
		{
			Assert.AreEqual(stringValue, pos.StringValue);
		}
       
        [Then(@"the old coordinates should be \((.*), (.*)\)")]
        public void ThenTheOldCoordinatesShouldBe(double oldX, double oldY)
        {
			Assert.AreEqual(pos.PreviousValue, new System.Windows.Point(oldX, oldY));
		}
	}
}
