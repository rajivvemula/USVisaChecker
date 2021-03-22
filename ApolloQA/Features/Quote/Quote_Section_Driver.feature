Feature: Quote Section Driver
	In order to manage driver type risk in quote
	add, edit, view drivers should work properly
	
@tc:34148
Scenario: Add a driver
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks 'New' Button

	#Business 
	When user selects dropdown Named Insured option at index 0	
	And user enters Accounting Services into Keyword field
	And user selects dropdown Keyword option equaling Accounting Services	
	And user selects dropdown Physical Address option containing , IL,
	And user clicks 'Next' Button
	Then A new Quote should successfully be created	
	When user clicks 'Drivers' Sidetab
	And user clicks 'Driver' Button
	#And user select a Driver with the following relevant values
	When user adds a new Driver with the following relevant values
	| First Name | Last Name | Date of Birth | Drivers License State | Drivers License Number |
	| Miguel     | Acosta    | 10/26/1996    | IL                    | random                 |
	#And user enters answer to What is your Inspection Count? as 0
	And user selects answer to Exclude Driver? as No
	And user selects answer to Has this driver had an accident or violation in the past 3 years, or a conviction in the past 5 years? as No
	And user clicks 'Save Driver' Button
	And user waits for spinner to load


@ignore
#TODO
Scenario: TBD
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

