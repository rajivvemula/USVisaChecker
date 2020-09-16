
Feature: F001-Navigating To FNOL Insert
	Navigate To FNOL Insert


Scenario: 1 Navigate to FNOL Insert Page
	Given User is on Homepage
	Given User opens Waffle Menu
	When User navigates to Claims Tab
	Then Tab navigates to Claims URL
	When User clicks fnolGridNew button
	Then Verify correct page fnolInsert is displayed