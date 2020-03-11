using CommunityClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TechTalk.SpecFlow;

namespace Community.Tests.ClassLibrary.Generic
{
    [Binding]
    public class BasicThingWithIdSteps
    {
		BasicThingWithId obj;
		BasicThingWithId obj2;

        [Given(@"I have a basic object")]
        public void GivenIHaveABasicObject()
        {
			obj = new BasicThingWithId();
        }
        
        [Then(@"the Id should be non-zero")]
        public void ThenTheIdShouldBeNon_Zero()
        {
			Assert.AreNotEqual(0, obj.Id);
        }


		[Then(@"the Name should be non-blank")]
		public void ThenTheNameShouldBeNon_Blank()
		{
			Assert.AreNotEqual(0, obj.Name.Length);
		}

		[Given(@"I have a basic object named ""(.*)""")]
		public void GivenIHaveABasicObjectNamed(string name)
		{
			obj = new BasicThingWithId(name);
		}

		[Then(@"the Name should be ""(.*)""")]
		public void ThenTheNameShouldBe(string name)
		{
			Assert.AreEqual(name, obj.Name);
		}

		[When(@"I create another basic object")]
		public void WhenICreateAnotherBasicObject()
		{
			obj2 = new BasicThingWithId();
		}

		[Then(@"the Id of both objects should be different")]
		public void ThenTheIdOfBothObjectsShouldBeDifferent()
		{
			Assert.AreNotEqual(obj.Id, obj2.Id);
		}


	}
}
