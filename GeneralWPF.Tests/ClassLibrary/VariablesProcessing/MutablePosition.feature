Feature: MutablePosition
	In order to give things coordinates
	As a puck
	I want to allow my position to be set

@Position
Scenario: Default Position
	Given I have a new position object
	Then the coordinates should be (0.0, 0.0)

@Position
Scenario: Create With Position
	Given I have an object to move at (2.5, 3.5)
	Then the coordinates should be (2.5, 3.5)

@StringValue
Scenario: Create With Position And Check String Value
	Given I have an object to move at (2, 4)
	Then the string value should be "2,4"

@StringValue
Scenario: Create With Non Integer Position And Check String Value
	Given I have an object to move at (2.3, 3.5)
	Then the string value should be "2,4"

@Movement
Scenario: Move an object
	Given I have an object to move at (1.0, 2.0)
	When I move it to (2.5, 7.5)
	Then the coordinates should be (2.5, 7.5)
	And the old coordinates should be (1.0, 2.0)
