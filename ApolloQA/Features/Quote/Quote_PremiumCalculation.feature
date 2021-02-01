Feature: Quote Premium Calculation
	In order to test Rating Algorithms
	setup a quote with valid parameters
	So that I can modify parameters during testing
	
#QA 2 rating algorithm not working
#BUG 28223
#TODO
@SmokeTest @bugReported
Scenario: Run Rate Calculation New Quote
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks New Button
	And user Selects Business Name as random
	And user Selects Line of Business as Commercial Auto
	And user Selects Policy Effective Date as Tomorrow
	And user clicks Next Button
	Then A new Quote should successfully be created	
	
	#Select Physical Address
	When user clicks Business Information Sidetab
	And user selects dropdown Physical Address option containing , IL,
	And user clicks Next Button
	
	#Answer UW Quesitons (Radius of Operation)
	When user clicks Underwriting Questions Sidetab
	And user selects answer to How far at most would your vehicles be driven from their base locations? as 0-50 Miles
	And user selects answer to What is the Motor Carrier Filing Type? as Single State
	And user selects answer to Covered Autos? as All Owned Autos
	And user clicks Next Button
	And user waits for spinner to load

	#Select a Driver
	When user clicks Drivers Sidetab
	And user clicks Driver Button
	And user select a Driver with the following relevant values
	And user selects answer to What is your current license status? as Active
	And user enters 0 into What is your Inspection Count? field
	And user selects answer to Exclude Driver? as No
	And user clicks Save Driver Button
	And user waits for spinner to load

	#Select a Vehicle
	When user clicks Vehicles Sidetab
	And user clicks Vehicle Button
	And user selects a Vehicle with the following relevant values
	And user selects dropdown Primary Driver option at index 0
	And user selects answer to Do you provide any charter servies such as group trips to events or vacation destinations? as No
	And user selects answer to Is this vehicle used to transport customers on tours or to other activities? as No
	And user selects answer to Is this vehicle: as Leased
	And user clicks Save Vehicle Button
	And user waits for spinner to load

	#Select a Policy Coverage
	When user clicks Policy Coverages Sidetab
	And user selects Bodily Injury Property Damage (BIPD) coverage with Combined Single Limit deductible of $75,000
	And user clicks Next Button
	And user waits for spinner to load

	#Generate Premium successful
	When user clicks Summary Sidetab
	And user waits '10' seconds
	And user waits for spinner to dissappear for 120 seconds
	Then the premium should be calculated

	#Test Premium Calculation
	When user clicks View Rating Worksheet Button
	Then Rating Worksheet should display the correct result

#ignored because it's covered with the above scenario
#implemented for testing purposes
@ignore
#TODO
Scenario: Run Rate Calculation Existing Quote
	Given user is successfully logged into biberk
	When User Navigates to Quote 11557
	#Generate Premium successful
	When user clicks Summary Sidetab
	And user waits '10' seconds
	And user waits for spinner to dissappear for 120 seconds
	Then the premium should be calculated

	#Test Premium Calculation
	When user clicks View Rating Worksheet Button
	Then Rating Worksheet should display the correct result