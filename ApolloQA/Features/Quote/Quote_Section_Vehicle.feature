Feature: Quote Section Vehicle
	In order to manage Vehicle type risk in quote
	add, edit, view Vehicles should work properly
	
@tc:34147
Scenario: Add a Vehicle
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks 'New' Button

	#Business 
	When User Selects Name Insured from dropdown
	And user selects dropdown Organization Type option equaling LLC
	And user selects dropdown Tax ID Type option equaling FEIN
	And user enters tax Id number
	And user enters abcTest@example.com into Business Email Address field
	And user enters 4843668104 into Business Phone No field
	And user enters Accounting Services into Keyword field
	And user selects dropdown Keyword option equaling Accounting Services
	And user enters 2001 into Year Business Started field
	And user enters 2003 into Year Ownership Started field
	And user sets Orgnaization Address
	And user clicks 'Next' Button
	Then A new Quote should successfully be created	

	#Select a Vehicle
	When user clicks 'Vehicles' Sidetab
	And user clicks 'Vehicle' Button
	When user adds a new Vehicle with the following relevant values
	| VIN    | Year | Make  | Model  | Body Category        | Body Subcategory | Gross Vehicle Weight     | Underwriter Value |
	| random | 2020 | Honda | Accord | Cars, Pickup, or SUV | Car - Sedan      | 1 - 5000 lbs             | 10000             |
    And user answers vehicle garaging location question as 'No'
	And user sets answer to Is this vehicle owned, financed, or leased? as 'Leased'
	And user clicks 'Add Address' Button
	And user completes address form
	And user selects Collision coverage with Deductible deductible of $5,000
	And user selects Comprehensive coverage with Deductible deductible of $5,000
	And user clicks 'Save Vehicle' Button
	And user waits for spinner to load


Scenario: Quote vehicle section QE vehicle owned
	Given user is successfully logged into biberk
	When user clicks 'Quote' Button
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks 'Vehicles' Sidetab
	When user clicks 'Vehicle' Button
	And user waits for spinner to load
	When user selects Owned Button
	When user clicks 'The Business' Button
	When user clicks 'One or more of the Business Owner(s)' Button
	And user verifies owner input is visible
	When user clicks 'Someone else' Button
	And user verifies owner input is visible
	Then user adds Address

Scenario: Quote vehicle section QE vehicle financed
	Given user is successfully logged into biberk
	When user clicks 'Quote' Button
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks 'Vehicles' Sidetab
	When user clicks 'Vehicle' Button
	And user waits for spinner to load
	When user selects Financed Button
	And user enters Lienholder info
	Then user adds Address

Scenario: Quote vehicle section QE vehicle leased
	Given user is successfully logged into biberk
	When user clicks 'Quote' Button
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks 'Vehicles' Sidetab
	When user clicks 'Vehicle' Button
	And user waits for spinner to load
	When user selects Leased Button
	And user enters Lessor info
	Then user adds Address


	@ignore
#TODO
Scenario: TBD
	When user selects a Vehicle with the following relevant values
	| Vehicle Age |
	| 7           | 