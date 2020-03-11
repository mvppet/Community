Feature: Community
	In order to enable life
	As somewhere whre dwellers and buildings exist
	I manage the interactions between them all

@Init
Scenario: Create new community
	Given I have a new community
	Then there should be 0 dwellers in the community
	And there should be 0 homes in the community
	And there should be 0 workplaces in the community

@Add and remove
Scenario: Add a dweller
	Given I have a new community
	And I add a dweller to the community at (10, 10) named "blob"
	Then there should be one dweller in the community at (10, 10)
	And the name of the dweller should be "blob"
	And there should be 0 homes in the community
	And there should be 0 workplaces in the community
	And the dweller should not be inside a building

@Add and remove
Scenario: Add a home
	Given I have a new community
	And I add a home to the community at (10, 10)
	Then there should be one home in the community at (10, 10)
	And there should be 0 dwellers in the community
	And there should be 0 workplaces in the community

@Add and remove
Scenario: Add a workplace
	Given I have a new community
	And I add a workplace to the community at (10, 10)
	Then there should be one workplace in the community at (10, 10)
	And there should be 0 dwellers in the community
	And there should be 0 homes in the community

#@Dwellers
#Scenario: Add a dweller in the same place as the home
#	Given I have a new community
#	And I add a home to the community at (10, 10)
#	And I add a dweller to the community at (10, 10) named "blob"
#	Then there should be one dweller in the community at (10, 10)
#	And there should be one home in the community at (10, 10)
#	And the home should have 1 occupant
#	And the dweller should be inside a building
#	And the occupant of the home should be named "blob"

@Dwellers
Scenario: Add a dweller in the same place as the home, then move it out
	Given I have a new community
	And I add a home to the community at (10, 10)
	And I add a dweller to the community at (10, 10) named "blob"
	When I move the dweller to (50, 50)
	Then the home should have 0 occupant
	And the dweller should not be inside a building
	
#@Dwellers
#Scenario: Add a dweller in a different place to the home, then move it in
#	Given I have a new community
#	And I add a home to the community at (10, 10)
#	And I add a dweller to the community at (50, 50) named "blob"
#	When I move the dweller to (10, 10)
#	Then the home should have 1 occupant
#	And the dweller should be inside a building
#	And the occupant of the home should be named "blob"
	
@Nearest
Scenario: Find the nearest cafe
	Given I have a new community
	And I add a cafe to the community at (10.0, 10.0)
	And I add a cafe to the community at (100.0, 100.0)
	When ask the community to find the nearest cafe to (90.0, 90.0)
	Then the found building should at (100.0, 100.0)

	
@Nearest
Scenario: Find the nearest home
	Given I have a new community
	And I add a home to the community at (10, 10)
	And I add a home to the community at (100, 100)
	When ask the community to find the nearest home to (90.0, 90.0)
	Then the found building should at (100.0, 100.0)

	
@Nearest
Scenario: Find the nearest workplace
	Given I have a new community
	And I add a workplace to the community at (10.0, 10.0)
	And I add a workplace to the community at (100.0, 100.0)
	When ask the community to find the nearest workplace to (90.0, 90.0)
	Then the found building should at (100.0, 100.0)

	


