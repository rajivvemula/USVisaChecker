Feature: Quote_Driver


Scenario: TC 26736: Show All / Collapse All on Quote -> Drivers tab
	Given user is successfully logged into biberk
	When user clicks Quote Button
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks  Drivers  Sidetab
	And user waits for spinner to load
	And user checks for existing driver
	And user waits for spinner to load
	Then User verifies collapse all and expand all