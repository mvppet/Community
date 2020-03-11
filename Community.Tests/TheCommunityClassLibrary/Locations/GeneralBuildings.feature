Feature: General Buildings
	Houses, Cafes, Workplaces
	As a dweller
	I need some basic rules

#@Buildings
#Scenario: Dwellers can only be in one building at a time
#	Given
#	When
#	Then

@Buildings
Scenario: Entering buildings
	Given I have a dweller who wants to enter a building
	And the dweller has an action to enter a building
	When the action affects the dweller
	Then the dweller should be inside the building


