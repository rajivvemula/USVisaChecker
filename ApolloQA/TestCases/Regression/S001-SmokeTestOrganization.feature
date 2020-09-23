@SmokeTestBase
Feature: S001-SmokeTest
Smoke Test that covers the Organization

Scenario:1 Create an Organization
	Given User is on Homepage
	When User creates an Organization
	| Name       | DBA   | OrgType     | TaxType | TaxIDNo | BusPhone     | BusEmail            | BusWeb        | YearStart | YearOwn | Keyword    |
	| Smoke Test | Smoke | Corporation | FEIN    | Random  | 123-456-7890 | smoketest@gmail.com | smoketest.com | 2011      | 2012    | Accountant |
	Then Verify organization is created

Scenario:2 Save Changes To An Organization
	#Given User is on organization Created
	When User changes dropdown busInfoOrgType to LLC
	When User clicks orgInsertSave button
	Then Verify correct toast was saved. is displayed

Scenario:3 Add an address to Organization
	When User adds address to Organization 
	| Line1        | City         | State | Zip   |
	| 39 Public Sq | Wilkes Barre | PA    | 18701 |
	Then Verify address is added to Organization

Scenario: Add a Driver to A Given Organization
	When User adds driver to Organization
	| First | Last | Middle | DOB        | State | Number | Exp        | CDL |
	| Jacob | Seed | J      | 01/02/1975 | AZ    | Random | 01/01/2022 | No  |
	Then Verify driver is added to Organization

Scenario: Add a Vehicle to Organization
	When User adds vehicle to Organization
	| VIN    | Year | Make   | Model | Trim |  Category             | SubCategory | Code                    | Seating   | Gross    | Cost  | Value | Stated |
	| Random | 2015 | Toyota | Camry | SE   |  Cars, Pickup, or SUV | Car - Coupe | Airport Limousines -826 | 5 or less | 0 - 5000 | 10000 | 11000 | 12000  |
	Then Verify vehicle is added to Organization