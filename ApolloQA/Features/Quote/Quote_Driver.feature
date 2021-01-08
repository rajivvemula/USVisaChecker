@broken
Feature: Quote_Driver


Scenario: TC 26736 Show All Collapse All on Quote Drivers tab
	Given user is successfully logged into biberk
	When user clicks Quote Button
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks Drivers Sidetab
	And user waits for spinner to load
	And user checks for existing driver
	And user waits for spinner to load
	Then User verifies collapse all and expand all


Scenario: TC 25560 25562 Button Color is correct
	Given user is successfully logged into biberk
	When user clicks Quote Button
	When user clicks New Button
	And user waits for spinner to load
	And user checks Quote info page buttons
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks Drivers Sidetab
	And user waits for spinner to load
	Then user checks Drivers grid page buttons
