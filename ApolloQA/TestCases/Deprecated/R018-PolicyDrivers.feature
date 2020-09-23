@reg @pol
Feature: R018-PolicyDrivers
	
	As any user(defaults to admin)
	I want to be able to add a new driver to an existing policy


# Scenario: 1 User Can Navigate To General Information
#	Given User navigates to Policy Page For Policy 10146
#	When User Click on General Information
#	Then User is shown the General Information screen for that policy

Scenario: 2 User Can Navigate To Drivers
	When User Click on Drivers
	Then User is shown the Drivers screen for that policy

Scenario: 3 User Can Click Add Driver
	When User Click on Add Driver
	Then User is shown the Add Driver Modal

Scenario Outline:4 Verify All Inputs on Add Driver Modal
	When Add Driver Modal User enter <Value> for <Input> 
	Then Add Driver Modal User should see <Value> For that <Input> 
	And Add Driver Modal User is required to have values for the <Input> as <Required>  

	Examples: 
	| Input         | Value    | Required |
	| first         | John     | true     |
	| middle        | J        | false    |
	| last          | Smith    | true     |
	| suffix        | Mr       | false    |
	| dob           | 7/8/1980 | true     |
	| licensenumber | 12312312 | true     |
	| licenseexp    | 7/8/2022 | true     |


Scenario Outline:5 Verify All Selects on Add Driver Modal
	When Add Driver Modal User clicks on <Select> 
	Then Add Driver Modal User should see all values to be present in <Select> 
	And Add Driver Modal User is required to have Select values for the <Select> as <SelectRequired> 

	Examples: 
	| Select       | SelectRequired |
	| licensestate | true           |
	| cdl          | true           |
	

Scenario:7 User is able to click cancel and exit the add driver modal
	When User clicks cancel to exit modal for Add Driver

	Scenario: 8 User is able to add driver to an organization
	When User clicks Add Driver in Organization
	And user enters inputs for add driver in organization
	| First | Last | Middle | DOB        | State | Number  | Exp        | CDL |
	| Jacob | Seed | J      | 01/02/1975 | AZ    | AZ27545 | 01/01/2022 | Yes  |
	And User select coverage
	And Special Step after coverage for driver
	And user clicks submit to add driver
	Then User should see toast confirming driver was added

Scenario: 9 User is able to edit driver in an organization
	When User clicks edit driver
	And changes driver first name
	And User select coverage
	And user clicks submit to add driver
	Then User should see toast confirming driver was added