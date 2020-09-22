
@reg @org
Feature: R040-InsertNewOrganization
	As Any User
	I want to verify all inputs and selects are working as intended

Scenario: 1 Insert New Organization
	Given I am on the OrganizationGrid page
	When I click the New Organization button
	Then I am taken to the OrganizationInsert page

Scenario Outline:4 Verify All Inputs on Organization Insert
	When Organization Insert User enter <Value> for <Input> 
	Then Organization Insert User should see <Value> For that <Input> 
	And Organization Insert User is required to have values for the <Input> as <Required>  

	Examples: 
	| Input           | Value          | Required |
	| name            | TestAutomation | true     |
	| dba             | Test           | false    |
	| businessphone   | 123-456-7890     | false    |
	| businessemail   | test@gmail.com | false    |
	| businesswebsite | biberk.com     | false    |
	| description     | sample         | false    |
	| yearstarted     | 2005           | true     |
	| yearownership   | 2005           | true     |


Scenario Outline:5 Verify All Selects on Organization Insert
	When Organization Insert User clicks on <Select> 
	Then Organization Insert User should see all values to be present in <Select> 
	And Organization Insert User is required to have Select values for the <Select> as <SelectRequired> 

	Examples: 
	| Select       | SelectRequired |
	| orgtype      | true           |
	| industrytype | true           |
	| subtype      | true           |
	| class        | true           |
	| taxtype      | true           |

Scenario: 6 Click cancel to exit organization insert
	When User clicks on cancel Button in IOrganization Insert
	When User clicks continue anyway


