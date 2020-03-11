using GeneralWPFClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace GeneralWPF.Tests.ClassLibrary.VariablesProcessing
{
    [Binding]
    public class PercentSteps
    {
		Percent percent;

		[Given(@"I have a new percent object of (.*)")]
		public void GivenIHaveANewPercentObjectOf(double p) => percent = new Percent(p);


		[When(@"I add (.*) to it")]
		public void WhenIAddToIt(double number) => percent.Value += number;


		[Then(@"the percent value should be (.*)")]
		public void ThenThePercentValueShouldBe(double num) => Assert.AreEqual(num, percent.Value);

		[Then(@"the percent string value should be ""(.*)""")]
		public void ThenThePercentStringValueShouldBe(string str) => Assert.AreEqual(str, percent.StringValue);

		[Then(@"the percent string value rounded to (.*) decimal places should be ""(.*)""")]
		public void ThenThePercentStringValueRoundedToDecimalPlacesShouldBe(int precision, string str) => Assert.AreEqual(str, percent.ToString(precision));

	}
}
