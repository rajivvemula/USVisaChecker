Feature: Quote Section Driver
	In order to manage driver type risk in quote
	add, edit, view drivers should work properly
	

@ignore
#TODO
Scenario: Add a driver
	When user select a Driver with the following relevant values
	| CDL | License State |
	| No  | IL            |




@broken
#it's not garanteeed tha the quote will contain a driver to check this
#please avoid TC number on scenario title
Scenario: Quote Driver Section Schedule
	Given user is successfully logged into biberk
	When user clicks 'Quote' Button
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks 'Drivers' Sidetab
	And user waits for spinner to load
	And user checks for existing driver
	And user waits for spinner to load
	Then User verifies collapse all and expand all


#testing for color on Next button?
#please avoid TC number on scenario title
Scenario: Quote Driver Button Color is correct
	Given user is successfully logged into biberk
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks 'Drivers' Sidetab
	And user waits for spinner to load
	Then user checks Drivers grid page buttons

