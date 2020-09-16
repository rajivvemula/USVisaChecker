Feature: S001-SmokeTest
Smoke Test that covers the Organization

Scenario:1 Create an Organization
	Given User is on Homepage
	When User creates an Organization
	| Name       | DBA   | OrgType     | TaxType | TaxIDNo | BusPhone     | BusEmail            | BusWeb        | YearStart | YearOwn | Keyword    |
	| Smoke Test | Smoke | Corporation | FEIN    | Random  | 123-456-7890 | smoketest@gmail.com | smoketest.com | 2011      | 2012    | Accountant |
	Then Verify organization is created

Scenario:2 Save Changes To An Organization
	Given User is on organization Created
	When User changes dropdown busInfoOrgType to LLC
	When User clicks orgInsertSave button
	Then Verify correct toast "was saved." is displayed

Scenario:3 Add an address to Organization
	When User adds address to Organization 
	| Line1        | City         | State | Zip   |
	| 39 Public Sq | Wilkes Barre | PA    | 18701 |
	Then Verify address is added to Organization