Feature: secondScenario
Scenario Outline: secondScenario
	Given Main form is open
	When Select option <Orientation> from View menu bar
	When Click on numbers "1 2"
	When Click Plus
	When Click on numbers "9 9 9"
	Then Click on equals
	When Add result to memory
	When Click on numbers "1 9"
	When Click Plus
	When Get saved result
	Then Click on equals
	Then the result of math should be "1030"

Examples:
	| Orientation |
	| Standard    |
	| Scientific  |