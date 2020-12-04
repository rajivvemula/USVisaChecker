Feature: Quote_PremiumCalculation
	In order to test Rating Algorithms
	setup a quote with valid parameters
	So that I can modify parameters during testing
	

@mytag
Scenario: Run Rate Calculation
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks New Button
	And user Selects Business Name as random
	And user Selects Line of Business as Commercial Auto
	And user Selects Policy Effective Date as Tomorrow
	And user clicks Next Button
	Then A new Quote should successfully be created
	When user adds a random driver
	And user adds a Vehicle Type risks with the following relevant values
	| Vehicle Age | Radius | Class Code | 
	| 7           | 150    | 603        | 
	And user selects a random coverage
	And user navigates to Summary Section
	Then the premium should be calculated
	And Rating Worksheet should display the correct result
