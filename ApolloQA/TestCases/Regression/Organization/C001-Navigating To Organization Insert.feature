@navigation @smoketest
Feature: C001-Navigating To Organization Insert
	Navigate To Organization Insert


Scenario: 1 Navigate to Organization Insert Page
	Given User is on Homepage
	When User navigates to Organization Tab
	Then Tab navigates to Organization URL
	When User clicks orgGridNew button
	Then Verify correct page orgInsert is displayed