@org
Feature: R044-AddDriverToOrganization
	



Scenario:1 User can navigate to Drivers tab and click Add Driver
	When User clicks Drivers Tab In Organization
	When User clicks Add Driver in Organization

Scenario Outline:2 Verify All Inputs on Add Driver Modal
	When Add Driver Modal User enter <Value> for <Input> 
	Then Add Driver Modal User should see <Value> For that <Input> 
	And Add Driver Modal User is required to have values for the <Input> as <Required>  

	Examples: 
	| Input         | Value    | Required |
	| first         | John     | true     |
	| middle        | J        | false     |
	| last          | Smith    | true     |
	| suffix        | Mr       | false     |
	| dob           | 7/8/1980 | true     |
	| licensenumber | 12312312 | true     |
	| licenseexp    | 7/8/2022 | true     |


Scenario Outline:3 Verify All Selects on Add Driver Modal
	When Add Driver Modal User clicks on <Select> 
	Then Add Driver Modal User should see all values to be present in <Select> 
	And Add Driver Modal User is required to have Select values for the <Select> as <SelectRequired> 

	Examples: 
	| Select       | SelectRequired |
	| licensestate | true           |
	| cdl          | true           |
	

Scenario:4 User is able to click cancel and exit the add driver modal
	When User clicks cancel to exit modal for Add Driver
	#Then User is no longer able to see the modal for Add Driver

Scenario: 5 User is able to add driver to an organization
	When User clicks Add Driver in Organization
	And user enters inputs for add driver in organization
	| First | Last | Middle | DOB        | State | Number  | Exp        | CDL |
	| Jacob | Seed | J      | 01/02/1975 | AZ    | AZ15435 | 01/01/2022 | No  |
	And user clicks submit to add driver
	Then User should see toast confirming driver was added

Scenario: 6 User is able to edit driver in an organization
	When User clicks edit driver
	And changes driver first name
	And user clicks submit to add driver
	Then User should see toast confirming driver was added
	Then wait 5 secs