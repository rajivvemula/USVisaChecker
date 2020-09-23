@reg @pol
Feature: R019-PolicyHistoryVerify
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario: 1 User Can Navigate To Policy History
When User refreshes browser
	When User Click on Policy History
	Then User is shown the Policy History screen for that policy
	

Scenario: Verify policy
	Then Verify policy was intialized
	
Scenario: Verify location
	Then Verify location was added

Scenario: Verify Driver
	Then Verify driver was added