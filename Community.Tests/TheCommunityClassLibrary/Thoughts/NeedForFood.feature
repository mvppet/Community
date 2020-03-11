Feature: Need For Food
	When I get hungry
	As a dweller (Basic Sentient Object)
	I want to go to a cafe

@Cafe
Scenario: Going to a cafe
	Given I have a community
	And I have a new cafe at (100, 100)
	And I have a dweller
	And the dweller has a lower food threshold of 40.0%
	And the dweller has food of 35.0%
	And the dweller has a position of (10.0 ,10.0)
	When I wait for the next Dweller iteration
	Then the dweller's final destination should be (100, 100)
