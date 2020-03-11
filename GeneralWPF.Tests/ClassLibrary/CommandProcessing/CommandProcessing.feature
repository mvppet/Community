Feature: CommandProcessing
	This feature allows functions to be mapped to buttons
	Used to fire code from buttons in UI
	Commands are passed from buttons via the XAML Command Argument

@mytag
Scenario: Text command processor check
	Given a I have a new text command processor
	When simulate a button firing the command "Hello"
	Then the function should receive "Hello"

