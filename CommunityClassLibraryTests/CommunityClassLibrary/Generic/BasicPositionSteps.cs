using CommunityClassLibrary.Locations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace CommunityTests.CommunityClassLibrary.Generic
{
    [Binding]
    public class BasicPositionSteps
    {
		BasicPosition bp;

        [Given(@"I have a new position object")]
        public void GivenIHaveANewPositionObject()
        {
			bp = new BasicPosition();
        }
        
        [Given(@"I have a new position object at \((.*), (.*)\)")]
        public void GivenIHaveANewPositionObjectAt(double  x, double y)
        {
			bp = new BasicPosition(x,y);
		}

		[Then(@"the coordinates should be \((.*), (.*)\)")]
        public void ThenTheCoordinatesShouldBe(double x, double y)
        {
			Assert.AreEqual(x, bp.Value.X);
			Assert.AreEqual(y, bp.Value.Y);
        }

		[Then(@"the string value should be ""(.*)""")]
		public void ThenTheStringValueShouldBe(string stringValue)
		{
			Assert.AreEqual(stringValue, bp.StringValue);
		}



	}
}
