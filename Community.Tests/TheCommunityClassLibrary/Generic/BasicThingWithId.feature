Feature: Basic Thing With Id
	Used for several types of object
	I need a unique Id
	And a Name

@Init
Scenario: Create with defaults
	Given I have a basic object
	Then the Id should be non-zero
	And the Name should be non-blank

@Init
Scenario: Create with name
	Given I have a basic object named "Elephant"
	Then the Id should be non-zero
	And the Name should be "Elephant"

@Init
Scenario: Create two objects and check Ids are different
	Given I have a basic object
	When I create another basic object
	Then the Id of both objects should be different

