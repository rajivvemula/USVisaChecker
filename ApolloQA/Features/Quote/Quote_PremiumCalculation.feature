Feature: Quote Premium Calculation
	In order to test Rating Algorithms
	setup a quote with valid parameters
	So that I can modify parameters during testing
	
#QA 2 rating algorithm not working
#BUG 28223
@SmokeTest @tc:29105 @tc:34153
Scenario: Rate Calculation New Quote
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks 'New' Button
	#And user selects dropdown Line of Business option equaling Commercial Auto

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
	| VIN    | Year | Make  | Model  | Body Category        | Body Subcategory | Gross Vehicle Weight | Underwriter Value |
	| random | 2020 | Honda | Accord | Cars, Pickup, or SUV | Car - Sedan      | 1 - 5000 lbs         | 10000             |
	And user selects answer to Is this vehicle's parking address in a state different than your businesses' main state? as No
	And user sets answer to Is this vehicle owned, financed, or leased? as 'Leased'
	And user clicks 'Add Address' Button
	And user completes address form
	And user selects Collision coverage with Deductible deductible of $5,000
	And user selects Comprehensive coverage with Deductible deductible of $5,000

	And user waits for spinner to load
	And user clicks 'Save Vehicle' Button
	And user waits for spinner to load
	And user clicks 'Vehicle' Button
	When user adds a new Vehicle with the following relevant values
	| VIN    | Year | Make  | Model  | Body Category        | Body Subcategory | Gross Vehicle Weight | Underwriter Value |
	| random | 2020 | Honda | Accord | Cars, Pickup, or SUV | Car - Sedan      | 1 - 5000 lbs         | 10000             |
	And user selects answer to Is this vehicle's parking address in a state different than your businesses' main state? as No
	And user sets answer to Is this vehicle owned, financed, or leased? as 'Leased'
	And user clicks 'Add Address' Button
	And user completes address form
	And user clicks 'Save Vehicle' Button
	And user waits for spinner to load
	And user clicks 'Vehicle' Button
	When user adds a new Vehicle with the following relevant values
	| VIN    | Year | Make  | Model  | Body Category        | Body Subcategory | Gross Vehicle Weight | Underwriter Value |
	| random | 2020 | Honda | Accord | Cars, Pickup, or SUV | Car - Sedan      | 1 - 5000 lbs         | 10000             |
	And user selects answer to Is this vehicle's parking address in a state different than your businesses' main state? as No
	And user sets answer to Is this vehicle owned, financed, or leased? as 'Leased'
	And user clicks 'Add Address' Button
	And user completes address form
	And user clicks 'Save Vehicle' Button
	And user waits for spinner to load

	#Select a Driver
	When user clicks 'Drivers' Sidetab
	And user clicks 'Driver' Button
	#And user select a Driver with the following relevant values
	When user adds a new Driver with the following relevant values
	| First Name   | Last Name | Date of Birth | Drivers License State | Drivers License Number |
	| MigueOne     | Acosta    | 10/26/1996    | IL                    | random                 |
	And user selects answer to Exclude Driver? as No
	And user selects answer to Has this driver had an accident or violation in the past 3 years, or a conviction in the past 5 years? as No
	And user clicks 'Save Driver' Button
	And user waits for spinner to load
	And user clicks 'Driver' Button
	#And user select a Driver with the following relevant values
	When user adds a new Driver with the following relevant values
	| First Name   | Last Name | Date of Birth | Drivers License State | Drivers License Number |
	| MiguelTwo    | Acosta    | 10/26/1996    | IL                    | random                 |
	And user selects answer to Exclude Driver? as No
	And user selects answer to Has this driver had an accident or violation in the past 3 years, or a conviction in the past 5 years? as No
	And user clicks 'Save Driver' Button
	And user waits for spinner to load
	And user clicks 'Driver' Button
	#And user select a Driver with the following relevant values
	When user adds a new Driver with the following relevant values
	| First Name     | Last Name | Date of Birth | Drivers License State | Drivers License Number |
	| MiguelThree    | Acosta    | 10/26/1996    | IL                    | random                 |
	And user selects answer to Exclude Driver? as No
	And user selects answer to Has this driver had an accident or violation in the past 3 years, or a conviction in the past 5 years? as No
	And user clicks 'Save Driver' Button
	And user waits for spinner to load

	
	#Answer Operations (Radius of Operation)
	When user clicks 'Operations' Sidetab
	And user selects answer to What is the furthest any of your vehicles travel in any one direction from their home base? as 50 miles or less
	And user enters answer to How many auto insurance claims did your business file in the last 3 years? as 0

	And user clicks 'Next' Button
	And user waits for spinner to load
	

	#Select a Policy Coverage
	When user clicks 'Policy Coverages' Sidetab
	And user selects Bodily Injury Property Damage (BIPD) coverage with Combined Single Limit deductible of $100,000
	And user clicks 'Next' Button
	And user waits for spinner to load

	#Generate Premium successful
	#added wait because the JS was breaking
	And user waits '3' seconds
	When user clicks 'Summary' Sidetab
	And user waits '10' seconds
	And user waits for spinner to dissappear for 240 seconds
	Then the premium should be calculated


@broken
#needs objects update for Tether and RatableObject
Scenario: Rating Result Accuracy
	Given user is in the Rating Worksheet Page
	Then Rating Worksheet should display the correct result