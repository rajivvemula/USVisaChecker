Feature: Quote Premium Calculation
	In order to test Rating Algorithms
	setup a quote with valid parameters
	So that I can modify parameters during testing
	
#QA 2 rating algorithm not working
#BUG 28223
@SmokeTest
Scenario: Rate Calculation New Quote
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks 'New' Button
	And user selects dropdown Line of Business option equaling Commercial Auto

	#Business 
	When user selects dropdown Named Insured option at index 0	
	And user enters Accounting Services into Keyword field
	And user selects dropdown Keyword option equaling Accounting Services	
	And user selects dropdown Physical Address option containing , IL,
	And user clicks 'Next' Button
	Then A new Quote should successfully be created	

	#Select a Vehicle
	When user clicks 'Vehicles' Sidetab
	And user clicks 'Vehicle' Button
	When user adds a new Vehicle with the following relevant values
	| VIN    | Year | Make  | Model  | Body Category        | Body Subcategory |Gross Vehicle Weight | Stated Amount |
	| random | 2020 | Honda | Accord | Cars, Pickup, or SUV | Car - Sedan      | 1 - 5000             | 10000         |
	And user selects answer to Is this vehicle used to transport customers on tours or to other activities? as No
	And user selects answer to Is this vehicle owned, financed, or leased? as Leased
	And user selects answer to Is this vehicle's parking address in a state different than your businesses' main state? as No
	And user clicks 'Save Vehicle' Button
	And user waits for spinner to load
	And user clicks 'Vehicle' Button
	When user adds a new Vehicle with the following relevant values
	| VIN    | Year | Make  | Model  | Body Category        | Body Subcategory |Gross Vehicle Weight | Stated Amount |
	| random | 2020 | Honda | Accord | Cars, Pickup, or SUV | Car - Sedan      | 1 - 5000             | 10000         |
	And user selects answer to Is this vehicle used to transport customers on tours or to other activities? as No
	And user selects answer to Is this vehicle owned, financed, or leased? as Leased
	And user selects answer to Is this vehicle's parking address in a state different than your businesses' main state? as No
	And user clicks 'Save Vehicle' Button
	And user waits for spinner to load
	And user clicks 'Vehicle' Button
	When user adds a new Vehicle with the following relevant values
	| VIN    | Year | Make  | Model  | Body Category        | Body Subcategory |Gross Vehicle Weight | Stated Amount |
	| random | 2020 | Honda | Accord | Cars, Pickup, or SUV | Car - Sedan      | 1 - 5000             | 10000         |
	And user selects answer to Is this vehicle used to transport customers on tours or to other activities? as No
	And user selects answer to Is this vehicle owned, financed, or leased? as Leased
	And user selects answer to Is this vehicle's parking address in a state different than your businesses' main state? as No
	And user clicks 'Save Vehicle' Button
	And user waits for spinner to load

	#Select a Driver
	When user clicks 'Drivers' Sidetab
	And user clicks 'Driver' Button
	#And user select a Driver with the following relevant values
	When user adds a new Driver with the following relevant values
	| First Name | Last Name | Date of Birth | Drivers License State | Drivers License Number | Expiration Date |
	| Miguel     | Acosta    | 10/26/1996    | IL                   |  random           | 1/30/2025       |  
	And user enters answer to What is your Inspection Count? as 0
	And user selects answer to Exclude Driver? as No
	And user selects answer to Has this driver had any of the following: Accident or Violation in the last 3 years, Convictions in the last 5 years? as No
	And user clicks 'Save Driver' Button
	And user waits for spinner to load
	And user clicks 'Driver' Button
	#And user select a Driver with the following relevant values
	When user adds a new Driver with the following relevant values
	| First Name | Last Name | Date of Birth | Drivers License State | Drivers License Number | Expiration Date |
	| Miguel2     | Acosta    | 10/26/1996    | IL                   |  random           | 1/30/2025       |  
	And user enters answer to What is your Inspection Count? as 0
	And user selects answer to Exclude Driver? as No
	And user selects answer to Has this driver had any of the following: Accident or Violation in the last 3 years, Convictions in the last 5 years? as No
	And user clicks 'Save Driver' Button
	And user waits for spinner to load
	And user clicks 'Driver' Button
	#And user select a Driver with the following relevant values
	When user adds a new Driver with the following relevant values
	| First Name | Last Name | Date of Birth | Drivers License State | Drivers License Number | Expiration Date |
	| Miguel3     | Acosta    | 10/26/1996    | IL                   |  random           | 1/30/2025       |  
	And user enters answer to What is your Inspection Count? as 0
	And user selects answer to Exclude Driver? as No
	And user selects answer to Has this driver had any of the following: Accident or Violation in the last 3 years, Convictions in the last 5 years? as No
	And user clicks 'Save Driver' Button
	And user waits for spinner to load

	
	#Answer Operations (Radius of Operation)
	When user clicks 'Operations' Sidetab
	And user selects answer to What is the furthest any of your vehicles travel in any one direction from their home base? as 50 miles or less
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
	And user waits for spinner to dissappear for 120 seconds
	Then the premium should be calculated


@broken
#needs objects update for Tether and RatableObject
Scenario: Rating Result Accuracy
	Given user is in the Rating Worksheet Page
	Then Rating Worksheet should display the correct result