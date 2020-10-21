Feature: RA001_SetupValidPolicy
	In order to test Rating Algorithms
	I want a policy with valid parameters
	So that I can modify parameters during testing
	

Scenario: Find a valid Policy
	Given User is on Homepage
	When User navigates to policy ID 10539
	And user Selects Vehicle Type risks with the following relevant values
	| Vehicle Age | Radius | Class Code | 
	| 7           | 150    | 603        | 
	And User navigates to Policy Summary Section
	And the premium is calculated
	And User navigates to the Policy Rating Worksheet
	Then Rating Worksheet should display the correct result
