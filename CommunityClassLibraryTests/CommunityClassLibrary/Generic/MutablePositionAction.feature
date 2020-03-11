Feature: MutablePositions
	In order to allow things to move
	As an action
	I want to move something

@Movement
Scenario: Move an object
	Given I have an object to move at (1.0, 2.0)
	When I move it to (2.5, 7.5)
	Then the object should be at (2.5, 7.5)
	And the old position should be (1.0, 2.0)
