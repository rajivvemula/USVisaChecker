Feature: PolicyTest
	

@mytag
Scenario: Navigate Policy
	Given User is on Policy Page
	When User clicks Policy Summary
	Then user is shown the Summary screen
