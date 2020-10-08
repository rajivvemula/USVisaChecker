Feature: RA001_SetupValidPolicy
	In order to test Rating Algorithms
	I want a policy with valid parameters
	So that I can modify parameters during testing
	

Scenario: Find a valid Policy
	Given User is on Homepage
	When User Navigates to Policy
	When user Selects Vehicle Type risks with the following relevant values
	| Vehicle Age | Radius | Class Code | 
	| 7           | 150    | 603        | 
	Then The policy should load successfully
	And The policy should have Driver
	And The policy should have Vehicle
	And The policy should have Coverage
