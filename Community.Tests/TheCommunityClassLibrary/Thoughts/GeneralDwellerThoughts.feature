Feature: General Dweller Thoughts
	Some things matter more
	As a dweller
	I want to manage my shit


@Buildings
Scenario: Entering a building
	Given I have a dweller to enter the building at (0.0, 0.0)
	And I have a building to enter at (10.0, 10.0)
	And I have an initiating thought to head to the building
	When the thought is thunk
	Then the final action should be to enter the building
	And the dweller object should be heading to the building




#
#
#
#@Crisis
#Scenario: If a dweller goes from crisis mood to another mood, then any actions should be added to the Action Manager that were attempted during crisis mood


#
#@thoughts
#Scenario: Basic Random Movement Movement Thoughts create movement actions
#	Given I have a community
#	And a random nbumber generator is set to return 100.0%
#	And I have a dweller
#	And the dweller has a position of (10.0 ,11.0)
#	And I have a thought of moving to (25.0, 26.0)
#	And the dweller has 90.0% probability of moving
#	When I use the thought to create actions
#	Then the dweller's Action Manager should have movement actions ending at (25.0, 26.0)
#
#@thoughts
#Scenario: Actions are aware of the intiating thought
#	Given I have a basic thought
#	When 
#	Then 
#
#@thoughts
#Scenario: A thought can produce many actions
#	Given I have a thoughtful dweller in a community
#	And
#	When 
#	Then 
#
#
#@thoughts
#Scenario: The highest priority action is performed on one iteration, and then removed from the queue if it is not persistent
#	Given I have a thoughtful dweller in a community
#	And
#	When 
#	Then 
#
#@thoughts
#Scenario: When a dweller has a queue of actions, they are Busy
#	Given I have a thoughtful dweller in a community
#	And
#	When 
#	Then 
#
#@thoughts
#Scenario: Actions last for only one iteration
#	Given I have a thoughtful dweller in a community
#	And
#	When 
#	Then 
#
#@thoughts
#Scenario: If many acions match on highest Resting Priority, then the action is chosen with highest Busy Priority
#	Given I have a thoughtful dweller in a community
#	And
#	When 
#	Then 
#
#@thoughts
#Scenario: If the dweller is busy, the current action can be only interupted by one with higher Busy Priority than the Current Action's priority
#	Given I have a thoughtful dweller in a community
#	And
#	When 
#	Then 


#
#@thoughts
#Scenario: 
#	Given 
#	And
#	When 
#	Then 
#
#@thoughts
#Scenario: 
#	Given 
#	And
#	When 
#	Then 
#
#@thoughts
#Scenario: 
#	Given 
#	And
#	When 
#	Then 
#
