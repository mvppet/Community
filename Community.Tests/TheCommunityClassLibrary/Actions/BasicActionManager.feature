Feature: Basic Action Manager
	When things are thought about,
	actions can be initiated.
	I am a basic manager of those actions

@Init
Scenario: Create manager
	Given I have a new basic action manager
	Then the manager should have 0 actions

@Add
Scenario: Add actions
	Given I have a new basic action manager
	When I add 2 actions
	Then the manager should have 2 actions

@Add
Scenario: Add an action with a name
	Given I have a new basic action manager
	When I add an action named "Move" with priority 50
	Then the manager should have 1 actions
	And Action 1 should be "Move" with priority 50

@Add
Scenario: Add four actions with same priority
	Given I have a new basic action manager
	When I add an action named "Move" with priority 50
	And I add an action named "Eat" with priority 50
	And I add an action named "Sleep" with priority 50
	And I add an action named "Move" with priority 50
	Then the manager should have 4 actions
	And Action 1 should be "Move" with priority 50
	And Action 2 should be "Eat" with priority 50
	And Action 3 should be "Sleep" with priority 50
	And Action 4 should be "Move" with priority 50

@Priorities
Scenario: Add an action with a higher priority
	Given I have a new basic action manager
	When I add an action named "Move" with priority 50
	And I add an action named "Move" with priority 75
	Then the manager should have 2 actions
	And Action 1 should be "Move" with priority 75
	And Action 2 should be "Move" with priority 50

@Priorities
Scenario: Add an action with a lower priority
	Given I have a new basic action manager
	When I add an action named "Move" with priority 80
	And I add an action named "Move" with priority 75
	Then the manager should have 2 actions
	And Action 1 should be "Move" with priority 80
	And Action 2 should be "Move" with priority 75

@Priorities
Scenario: Add three actions with varying priority, then check the order
	Given I have a new basic action manager
	When I add an action named "Move" with priority 80
	And I add an action named "Eat" with priority 70
	And I add an action named "Sleep" with priority 85
	Then the manager should have 3 actions
	Then Action 1 should be "Sleep" with priority 85
	And Action 2 should be "Move" with priority 80
	And Action 3 should be "Eat" with priority 70


@Remove
Scenario: Add some actions, then remove an action type
	Given I have a new basic action manager
	When I add an action named "Move" with priority 5
	And I add an action named "Eat" with priority 4
	And I add an action named "Move" with priority 3
	And I add an action named "Move" with priority 2
	And I add an action named "Sleep" with priority 1
	And i remove the "Move" actions
	Then the manager should have 2 actions
	And Action 1 should be "Eat" with priority 4
	And Action 2 should be "Sleep" with priority 1














