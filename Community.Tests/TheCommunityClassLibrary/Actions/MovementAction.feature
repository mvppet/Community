Feature: Movement Action Base
	Due to some thought,
	we have decided to move.
	Sort this out...

@Init
Scenario: Create movement action
	Given I have an initiating thought
	And I have a new movement action heading to (10.0, 10.0) using the thought
	Then the initiating thought of our action should be the created thought
	And the destination should be (10.0, 10.0)
	And the action name should be "Move"

@Affect
Scenario: An object is moved by the action
	Given I have an initiating thought
	And I have a new movement action heading to (10.0, 10.0) using the thought
	And I have a test object at (0.0, 0.0)
	When I apply the movement action to the object
	Then the test object should be heading to (10.0, 10.0)



