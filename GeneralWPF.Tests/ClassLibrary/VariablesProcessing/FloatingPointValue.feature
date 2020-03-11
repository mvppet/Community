Feature: FloatingPointValue
	In order to do maths
	As a number
	I want to be non-integer, but be friendly and track changes

@InitialChecks
Scenario: Create new number
	Given I create a new floating point number with defaults
	Then the floating point value should be 0.0
	And the previous value should be 0.0

@InitialChecks
Scenario: Create new number with a value
	Given I have a floating point number of 23.456789
	Then the floating point value should be 23.456789
	And the previous value should be 0.0



@Convert
Scenario: Create new number and check string value
	Given I have a floating point number of 23.456789
	Then the floating point string value should be "23.456789"

@Convert
Scenario: Create new number and check integer value
	Given I have a floating point number of 23.456789
	Then the floating point integer value should be 23

@Convert
Scenario: Create new number and check rounded value
	Given I have a floating point number of 23.456789
	Then the floating point rounded value should be 23.46

@Convert
Scenario: Create new number and check rounded value to arbitary decimal places
	Given I have a floating point number of 23.456789
	Then the floating point rounded value to 3 decimal places should be 23.457



@OnChange
Scenario: Check state after a change
	Given I have a floating point number of 23.456789
	When I change the floating point number to 12.3456
	Then the floating point value should be 12.3456
	And the previous value should be 23.456789

@OnChange
Scenario: register an event to check OnChange feature
	Given I have a floating point number of 23.456789
	And I register a function to fire when value changed
	When I change the floating point number to 12.3456
	Then make sure the registered function has fired
	And the floating point value should be 12.3456
	And the previous value should be 23.456789


