Feature: RA001_SetupValidPolicy
	In order to test Rating Algorithms
	I want a policy with valid parameters
	So that I can modify parameters during testing
	

Scenario: Find a valid Policy
	Given User is on Homepage
	When User Navigates to Policy
	Then The policy should load successfully
	And The policy should have Driver
	And the policy should have Vehicle
	And the policy should have Coverage
