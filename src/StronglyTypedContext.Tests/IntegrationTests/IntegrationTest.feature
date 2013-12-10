Feature: IntegrationTest
	In order to make using spec flow less error prone.
	I want to avoid the use of magic strings in scenrio contexts by having them strongly typed


Scenario: Strongly Typed Scenario Context
	Given I have a step definiton with a strongly typed scenario context	
	When I set properties on the scenario context
	Then the properties are persisted
