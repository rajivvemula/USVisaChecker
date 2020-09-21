Feature: US-15363-App Quote
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


#Also covers TC02 and TC03
#TC 02 - Verify existing Organization name display in search result
#TC 03 -Verify Application Information page and Next should navigate Business Information page
Scenario: TC1 - Verify business name is new and Organization has not been created
	Given User is on Homepage
	When User Navigates to Application Insert 
	When User searches ShouldNotExist in Business Name
	Then Search ShouldNotExist displayed is false
	When User creates an Organization
	| Name            | DBA   | OrgType     | TaxType | TaxIDNo | BusPhone     | BusEmail            | BusWeb        | YearStart | YearOwn | Keyword    |
	| Smoke Test10023 | Smoke | Corporation | FEIN    | Random  | 123-456-7890 | smoketest@gmail.com | smoketest.com | 2011      | 2012    | Accountant |
	Then Verify organization is created
	When User Navigates to Application Insert 
	When User searches Smoke Test10023 in Business Name
	Then Search Smoke Test10023 displayed is true
	When User enters Smoke Test10023 in Business Name
	And User clicks appInsertNext button
	Then <pageName> page is displayed
	