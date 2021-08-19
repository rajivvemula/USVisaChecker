@SmokeTest
Feature: Quote Premium Calculation
	In order to test Rating Algorithms
	setup a quote with valid parameters
	So that I can modify parameters during testing
	
@tc:29105 @tc:34153 @tc:40354
Scenario: Rate Calculation New Quote
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
	And user enters <Keyword> into Keyword field
	And user selects dropdown Keyword option equaling <Keyword>
	And user enters 2001 into Year Business Started field
	And user enters 2003 into Year Ownership Started field
	And user sets Orgnaization Address
	And user clicks 'Next' Button
	Then A new Quote should successfully be created	

	#	User Adds 1 Tractor Truck, 1 sedan, 1 bus, and 1 Trailer 
	When user clicks 'Vehicles' Sidetab
	And user clicks 'Vehicle' Button
	When user adds a new Vehicle with the following relevant values
	| VIN    | Year | Make		   | Model  | Body Category        | Body Subcategory   | Gross Vehicle Weight     | Underwriter Value |
	| random | 2020 | Freightliner | 114SD  | Trucks			   | Truck Tractor      | 45001+ lbs               | 114001            |
	And user answers vehicle garaging location question as 'No'
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
	| VIN    | Year | Make		| Model  | Body Category         | Body Subcategory   | Gross Vehicle Weight    | Underwriter Value |
	| random | 2020 | Honda     | Accord | Cars, Pickup, or SUV  | Car - Sedan        | 5001 - 10000 lbs        | 19000             |
	And user answers vehicle garaging location question as 'No'
	And user sets answer to Is this vehicle owned, financed, or leased? as 'Leased'
	And user clicks 'Add Address' Button
	And user completes address form
	And user clicks 'Save Vehicle' Button
	And user waits for spinner to load
	And user clicks 'Vehicle' Button
	When user adds a new Vehicle with the following relevant values
	| VIN    | Year | Make  | Model           | Body Category  | Body Subcategory | Gross Vehicle Weight      | Underwriter Value |
	| random | 2020 | Ford  | Transit Connect | Other          | Bus              | 20001 - 30000 lbs         | 89000             |
	And user answers vehicle garaging location question as 'No'
	And user sets answer to Is this vehicle owned, financed, or leased? as 'Leased'
	And user clicks 'Add Address' Button
	And user completes address form
	And user clicks 'Save Vehicle' Button
	And user waits for spinner to load
	When user clicks 'Vehicles' Sidetab
	And user clicks 'Vehicle' Button
	When user adds a new Vehicle with the following relevant values
	| VIN    | Year | Make		   | Model    | Body Category  | Body Subcategory                                  | Estimated Current Value |
	| random | 2020 | Tuff Boy Inc | Trailer  | Trailer		   | Other Enclosed Trailer (2001+ lbs load capacity)  | 19000                   |
	And user answers trailer garaging location question as 'No'
	And user sets answer to Is this trailer owned, financed, or leased? as 'Leased'
	And user clicks 'Add Address' Button
	And user completes address form
	And user waits for spinner to load
	And user selects Collision coverage with Deductible deductible of $5,000
	And user waits for spinner to load
	And user selects Comprehensive coverage with Deductible deductible of $5,000
	And user waits for spinner to load
	And user clicks 'Save Vehicle' Button
	And user waits for spinner to load

	#	User Adds 3 Drivers
	When user clicks 'Drivers' Sidetab
	And user clicks 'Driver' Button
	When user adds a new Driver with the following relevant values
	| First Name   | Last Name | Date of Birth | Drivers License State | Drivers License Number |
	| MigueOne     | Acosta    | 10/26/1996    | IL                    | random                 |
	And user selects answer to Exclude Driver? as No
	And user selects answer to Has this driver had an accident or violation in the past 3 years, or a conviction in the past 5 years? as No
	And user answer CDL question
	And user clicks 'Save Driver' Button
	And user waits for spinner to load
	And user clicks 'Driver' Button
	When user adds a new Driver with the following relevant values
	| First Name   | Last Name | Date of Birth | Drivers License State | Drivers License Number |
	| MiguelTwo    | Acosta    | 10/26/1996    | IL                    | random                 |
	And user selects answer to Exclude Driver? as No
	And user selects answer to Has this driver had an accident or violation in the past 3 years, or a conviction in the past 5 years? as No
	And user answer CDL question
	And user clicks 'Save Driver' Button
	And user waits for spinner to load
	And user clicks 'Driver' Button
	When user adds a new Driver with the following relevant values
	| First Name     | Last Name | Date of Birth | Drivers License State | Drivers License Number |
	| MiguelThree    | Acosta    | 10/26/1996    | IL                    | random                 |
	And user selects answer to Exclude Driver? as No
	And user selects answer to Has this driver had an accident or violation in the past 3 years, or a conviction in the past 5 years? as No
	And user answer CDL question
	And user clicks 'Save Driver' Button
	And user waits for spinner to load
	
	#Answer Operations
	When user clicks 'Operations' Sidetab
	And user answers Operations questions
	And user clicks Next Button to complete Operations
	And user waits for spinner to load

	#Select a Policy Coverage
	When user clicks 'Policy Coverages' Sidetab
	And user select Policy Coverages according to Keyword
	And user clicks 'Next' Button
	And user waits for spinner to load 
	Then Toast containing Coverages saved. is visible
	#Summary
	When user clicks 'Summary' Sidetab
	And user waits '10' seconds
	And user waits for spinner to dissappear for 240 seconds
	Then the premium should be calculated

Examples:
| Keyword                                              |
| Trucking: Long Distance Hauling: more than 300 miles |
| Towing Services                                      |
| Limousine Company                                    |
| Bus Company                                          |

@broken
#needs objects update for Tether and RatableObject
Scenario: Rating Result Accuracy
	Given user is in the Rating Worksheet Page
	Then Rating Worksheet should display the correct result                                 