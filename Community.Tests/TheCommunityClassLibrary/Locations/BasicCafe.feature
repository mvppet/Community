Feature: Basic Cafe
	In order to keep Dwellers alive
	I feed dwellers
	With food

@Init
Scenario: Create new cafe
	Given I have a community
	And I have a new cafe at (100, 100)
	When I add the building to the community
	Then there should be 0 dwellers inside the building
	And the position of the building should be (100.0, 100.0)

@Cafe
Scenario: Hungry Dweller Eating
	Given I have a community
	And I have a new cafe at (100, 100)
	And the reward per iteration of the building is 10
	And the resource cost per iteration of the building is 5
	And I have a dweller
	And the dweller has food of 50.0%
	And I add the dweller to the building
	When I wait for the next Dweller iteration
	Then the dweller's food should be 60.0%

@Cafe
Scenario: Food costs money
	Given I have a community
	And I have a new cafe at (100, 100)
	And the reward per iteration of the building is 10
	And the resource cost per iteration of the building is 5
	And I have a dweller
	And the dweller has 100.0 cash
	And the dweller has food of 50.0%
	And I add the dweller to the building
	When the building affects the dweller
	Then the dweller's cash should be 95
	And the dweller's food should be 60.0%


