Feature: TwoStepDefinitions
	Scenario context attributes work accross two step definition classes

@mytag
Scenario: Sharing automatic scenario context between step definition files
	Given I have a step definition file with a scenario context property	
	When I set the property in one step definition class
	Then I can read the property in a different step definition class
