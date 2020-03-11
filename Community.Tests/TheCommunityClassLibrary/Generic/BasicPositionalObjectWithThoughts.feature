Feature: Basic Positional Object With Thoughts
	The most basic sentient lifeform.
	This "being" has everything that everybody needs.
	Probably can't make a cup of tea...

#@Init
#Scenario: Create basic sentient object
#	Given I have a basic sentient object called "Slob" at (10.0, 10.0)
#	Then the number of priorities should be 0
#	And the number of thoughts should be 0
#	And the number of actions should be 0
#	And the pause for thoughts should be 100 milliseconds
#	And the health should be 100.0 percent
#	And the object should be at (10.0, 10.0)
#	And the name should be "Slob"

#@Life
#Scenario: Living Life
#	Given I have a basic sentient object called "Slob" at (10.0, 10.0)
#	When I wait for 5 iterations
#	Then the iteration should be 5

#
#@Health
#Scenario: Dying
#	Given I have a basic sentient object called "Slob" at (10.0, 10.0)
#	And I register a death event
#	When health becomes 0.0
#	Then a death event should happen
#
#
##@
##Scenario: I use 
#
#
##@Resources
##Scenario: I use food when I think
#
##
##		public event EventHandler<IHasThoughts> Updated;
##
##		public abstract void HaveThoughts();
##		public abstract void PerformActions();
##
