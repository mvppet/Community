using GeneralWPFClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace GeneralWPF.Tests.ClassLibrary.VariablesProcessing
{
    [Binding]
    public class FloatingPointValueSteps
    {
		FloatingPointValue fp;
		int counter;

        [Given(@"I have a floating point number of (.*)")]
        public void GivenIHaveAFloatingPointNumberOf(double num) => fp = new FloatingPointValue { Value = num };

		[Given(@"I create a new floating point number with defaults")]
		public void GivenICreateANewFloatingPointNumberWithDefaults() => fp = new FloatingPointValue();



		[Then(@"the floating point value should be (.*)")]
        public void ThenTheFloatingPointValueShouldBe(double num) => Assert.AreEqual(num, fp.Value);
        
        [Then(@"the floating point string value should be ""(.*)""")]
        public void ThenTheFloatingPointStringValueShouldBe(string num) => Assert.AreEqual(num, fp.StringValue);

		[Then(@"the floating point integer value should be (.*)")]
        public void ThenTheFloatingPointIntegerValueShouldBe(int num) => Assert.AreEqual(num, fp.IntegerValue);

		[Then(@"the floating point rounded value should be (.*)")]
        public void ThenTheFloatingPointRoundedValueShouldBe(double num) => Assert.AreEqual(num, fp.RoundedValue);

		[Then(@"the floating point rounded value to (.*) decimal places should be (.*)")]
        public void ThenTheFloatingPointRoundedValueToDecimalPlacesShouldBe(int decimalPlaces, double num) => Assert.AreEqual(num, fp.GetRoundedValue(decimalPlaces));

		[Then(@"the previous value should be (.*)")]
		public void ThenThePreviousValueShouldBe(double num) => Assert.AreEqual(num, fp.PreviousValue);

		[When(@"I change the floating point number to (.*)")]
		public void WhenIChangeTheFloatingPointNumberTo(double value) => fp.Value = value;


		[Given(@"I register a function to fire when value changed")]
		public void GivenIRegisterAFunctionToFireWhenValueChanged()
		{
			// reset our counter
			counter = 0;
			// register a change that increments the counter by 1
			fp.Changed += (sender, e) => ++counter;
		}

		[Then(@"make sure the registered function has fired")]
		public void ThenMakeSureTheRegisteredFunctionHasFired() => Assert.AreEqual(1, counter, $"Registered change fired {counter} times");


	}
}
