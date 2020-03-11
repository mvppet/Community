using GeneralWPFClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace GeneralWPF.Tests.ClassLibrary.CommandProcessing
{
	[Binding]
	public class CommandProcessingSteps
	{
		ExampleCommandProcessor proc;

		[Given(@"a I have a new text command processor")]
		public void GivenAIHaveANewTextCommandProcessor() => proc = new ExampleCommandProcessor();

		[When(@"simulate a button firing the command ""(.*)""")]
		public void WhenSimulateAButtonFiringTheCommand(string cmd) => proc.Execute(cmd);

		[Then(@"the function should receive ""(.*)""")]
		public void ThenTheFunctionShouldReceive(string cmd) => Assert.AreEqual(cmd, proc.CommandText);


	}

	internal class ExampleCommandProcessor : TextCommandProcessorBase
	{
		public string CommandText { get; set; } = string.Empty;
		public override void ExecuteCommand(string commandText) => CommandText = commandText;
	}
}