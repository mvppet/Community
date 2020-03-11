Feature: Percent
	I'm a percentage
	I act like a FloatingPointValue
	But I keep my range from 0.0 to 100.0 inclusive

@Init
Scenario: Create a percentage with a value
	Given I have a new percent object of 1.23
	Then the percent value should be 1.23

@RangeChecking
Scenario: Create percent less than zero
	Given I have a new percent object of -1.23
	Then the percent value should be 0.0

@RangeChecking
Scenario: create percentage greater than 100
	Given I have a new percent object of 100.23
	Then the percent value should be 100.0

@RangeChecking
Scenario: Increment beyond 100
	Given I have a new percent object of 1.23
	When I add 1000.0 to it
	Then the percent value should be 100.0

@RangeChecking
Scenario: Decrement below 0
	Given I have a new percent object of 1.23
	When I add -1000.0 to it
	Then the percent value should be 0.0


@ToString
Scenario: Check string value has percentage sign, and is rounded to default decimal places
	Given I have a new percent object of 45.6789
	Then the percent string value should be "46%"

@ToString
Scenario: Check string value has percentage sign, and is rounded to 2 decimal places
	Given I have a new percent object of 45.6789
	Then the percent string value rounded to 2 decimal places should be "45.68%"

@ToString
Scenario: Check string value still works after a change
	Given I have a new percent object of 10
	When I add 10 to it
	Then the percent string value should be "20%"

