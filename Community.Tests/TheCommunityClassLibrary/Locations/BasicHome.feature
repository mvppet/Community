Feature: Basic Home
	In order to keep Dwellers alive
	I restore health
	Yeah


@Init
Scenario: Create new home
	Given I have a community
	And I have a new home at (100, 100) named "Home 1"
	When I add the building to the community
	Then there should be 0 dwellers inside the building
	And the position of the building should be (100.0, 100.0)


@Dwellers
Scenario: Sleeping Dweller
	Given I have a community
	And I have a new home at (100, 100) named "Home 1"
	And I have a dweller
	And the reward per iteration of the building is 10
	And I add the dweller to the building
	And the dweller has health of 50.0%
	When I wait for the next Dweller iteration
	Then the dweller's health should be 60.0%


