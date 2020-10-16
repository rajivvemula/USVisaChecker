@org
Feature: R041-AddNewOrganization
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: 1 Insert New Organization
	#Given I am on the OrganizationGrid page
	When I click the New Organization button
	Then I am taken to the OrganizationInsert page


Scenario: User is able to add new organization 
	When I user enter all info into Organization Insert
	| Name             | DBA | OrgType | TaxType | TaxNo | Phone | Email | Website | IndustryType | SubType | Class | YearStarted | YearOwnership | Desc |
	| BiberkAutomation | BA  | Corporation | FEIN    | 12-3489779 | 123-456-7890 | automation@biberk.com | biberk.com | Aviation     | Carpentry | Commercial | 2005        | 2005          | Sample  |
	Then Organization with those inputs is added and confirmed via toast