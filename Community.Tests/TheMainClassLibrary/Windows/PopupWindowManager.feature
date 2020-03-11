Feature: Popup Window Manager
	I want to manage the collection of popups

Scenario: Creating Popup Window from View Model
	And I have a ViewModel for the Popup Window Manager with ID 123
	When I create the Popup Window from the View Model
	And the Popup Window should have ID 123

Scenario: Adding a Popup Window to the Popup Window Manager
	Given I have a Popup Window Manager
	And I have a ViewModel for the Popup Window Manager with ID 10
	When I add the ViewModel to the Popup Window Manager
	Then the Popup Window count should be 1
	And Popup Window Manager at index 0 should have ID 10


#@Non-Persistent Windows
#Scenario: Adding a Popup Window to the Non Persistent Popup Window Manager
#	Given I have a Non Persistent Popup Window Manager
#	And I have a ViewModel for Popup Window Manager with ID 10
#	When I add the ViewModel to the Popup Window Manager
#	Then the Popup Window count should be 1
#	And the View Model of Popup Window 1 should have ID 10

#
#Scenario: Persistent windows use same window for multiple viewmodel submissions
#	Given I have a Persistent Popup Window Manager
#	And I have a ViewModel for Popup Window Manager with ID 10
#	And I have a second ViewModel for Popup Window Managers with ID 10
#	When I add the ViewModel to the Popup Window Manager
#	And I add the second ViewModel to the Popup Window Manager
#	Then the Popup Window count should be 1
#	And the View Model of Popup Window 1 should have ID 10

#Scenario: Non-persistent windows use new windows for every viewmodel submission, even if the viewmodel has been used before
#	Given I have a Persistent Popup Window Manager
#	And I have a ViewModel for Popup Window Manager with ID 10
#	And I have a second ViewModel for Popup Window Managers with ID 10
#	When I add the ViewModel to the Popup Window Manager
#	And I add the second ViewModel to the Popup Window Manager
#	Then the Popup Window count should be 2
#	And the View Model of Popup Window 1 should have ID 10
#	And the View Model of the Second Popup Window 1 should have ID 10


# when windows are closed, an event should be raised to identify which window and viewmodel closed
# window positioning

