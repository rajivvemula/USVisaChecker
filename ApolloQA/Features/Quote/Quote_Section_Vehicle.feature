Feature: Quote Section Vehicle
	In order to manage Vehicle type risk in quote
	add, edit, view Vehicles should work properly
	

@ignore
#TODO
Scenario: Add a Vehicle
	When user selects a Vehicle with the following relevant values
	| Vehicle Age |
	| 7           | 

	When user adds a new Vehicle with the following relevant values
	| VIN    | Year | Make  | Model  | Body Category        | Seating Capacity | Gross Vehicle Weight | Vehicle Class Code | Stated Amount |
	| random | 2020 | Honda | Accord | Cars, Pickup, or SUV | 5 or less        | 0 - 5000             | index:0            | 10000         |


Scenario: Quote vehicle section QE vehicle owned
	Given user is successfully logged into biberk
	When user clicks Quote Button
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks Vehicles Sidetab
	When user clicks Vehicle Button
	And user waits for spinner to load
	When user selects Owned Button
	When user clicks The Business Button
	When user clicks One or more of the Business Owner(s) Button
	And user verifies owner input is visible
	When user clicks Someone else Button
	And user verifies owner input is visible
	Then user adds Address

Scenario: Quote vehicle section QE vehicle financed
	Given user is successfully logged into biberk
	When user clicks Quote Button
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks Vehicles Sidetab
	When user clicks Vehicle Button
	And user waits for spinner to load
	When user selects Financed Button
	And user enters Lienholder info
	Then user adds Address

Scenario: Quote vehicle section QE vehicle leased
	Given user is successfully logged into biberk
	When user clicks Quote Button
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks Vehicles Sidetab
	When user clicks Vehicle Button
	And user waits for spinner to load
	When user selects Leased Button
	And user enters Lessor info
	Then user adds Address
