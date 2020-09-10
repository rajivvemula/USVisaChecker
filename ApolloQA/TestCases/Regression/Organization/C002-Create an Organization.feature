@navigation @smoketest
Feature: C002-Create an Organization
Create an organization with given parameters


Scenario: Create an Organization
	When User creates an Organization
	| Name       | DBA   | OrgType     | TaxType | TaxIDNo | BusPhone     | BusEmail            | BusWeb        | YearStart | YearOwn | Keyword    |
	| Smoke Test | Smoke | Corporation | FEIN    | Random  | 123-456-7890 | smoketest@gmail.com | smoketest.com | 2011      | 2012    | Accountant |
	Then Verify organization is created
