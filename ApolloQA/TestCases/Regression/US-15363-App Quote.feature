Feature: US-15363-App Quote
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario: TC1 - Verify business name is new and Organization has not been created
	Given User is on Homepage
	When User Navigates to Application Insert 
	When User searches ShouldNotExist in Business Name
	Then Search ShouldNotExist displayed is false
	| Name            | DBA   | OrgType     | TaxType | TaxIDNo | BusPhone     | BusEmail            | BusWeb        | YearStart | YearOwn | Keyword    |
	| Smoke Test10023 | Smoke | Corporation | FEIN    | Random  | 123-456-7890 | smoketest@gmail.com | smoketest.com | 2011      | 2012    | Accountant |
	Then Verify organization is created
	When User Navigates to Application Insert 
	When User searches Smoke Test10023 in Business Name
	Then Search Smoke Test10023 displayed is true