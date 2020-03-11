Feature: Basic Workplace
	In order to keep Dwellers wealthy
	I give them cash
	In return for for work

	
@Init
Scenario: Create new workplace
	Given I have a community
	And I have a new workplace at (100, 100)
	When I add the building to the community
	Then there should be 0 dwellers inside the building
	And the position of the building should be (100.0, 100.0)

@Workplace
Scenario: Dweller Working
	Given I have a community
	And I have a new workplace at (100, 100)
	And the reward per iteration of the building is 10
	And the resource cost per iteration of the building is 5
	And I have a dweller
	And I add the dweller to the building
	And the dweller has 100.0 cash
	When I wait for the next Dweller iteration
	Then the dweller's cash should be 110

@Workplace
Scenario: Working costs health
	Given I have a community
	And I have a new workplace at (100, 100)
	And the reward per iteration of the building is 10
	And the resource cost per iteration of the building is 5
	And I have a dweller
	And the dweller has 100.0 cash
	And the dweller has health of 50.0%
	And I add the dweller to the building
	When the building affects the dweller
	Then the dweller's cash should be 110
	And the dweller's health should be 45.0%


