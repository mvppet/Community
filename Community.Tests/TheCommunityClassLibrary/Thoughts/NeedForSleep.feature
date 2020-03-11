Feature: Need For Sleep
	When I get tired
	As a dweller (Basic Sentient Object)
	I want to think about sleeping

@Home
Scenario: Going home
	Given I have a community
	And I have a new home at (100, 100)
	And I have a dweller
	And the dweller has a lower sleep threshold of 50.0%
	And the dweller has health of 45.0%
	And the dweller has a position of (10.0 ,10.0)
	When I wait for the next Dweller iteration
	Then the dweller's final destination should be (100, 100)

@Home
Scenario: Not Waking Up
	Given I have a community
	And I have a new home at (100, 100)
	And I have a dweller
	And the dweller has a lower sleep threshold of 50.0%
	And the dweller has an upper sleep threshold of 60.0%
	And the dweller has health of 45.0%
	And I add the dweller to the building
	When I change the dweller health to 59.9%
	Then the dweller should be asleep

@Home
Scenario: Waking Up
	Given I have a community
	And I have a new home at (100, 100)
	And I have a dweller
	And the dweller has a lower sleep threshold of 50.0%
	And the dweller has an upper sleep threshold of 60.0%
	And the dweller has health of 45.0%
	And I add the dweller to the building
	When I change the dweller health to 60.1%
	Then the dweller should be wake up



