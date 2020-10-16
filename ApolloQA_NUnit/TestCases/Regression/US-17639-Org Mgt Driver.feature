Feature: US-17639-Org Mgt Driver
	As an underwriter, 
	I want to update the Driver functionality at the Organization Level, 
	so that I can pull it in as necessary at the Application Quote level.


Scenario:TC01 Verify Grid Titles in Vehicle Organization
	Given User is on Homepage
	When User creates an Organization
	| Name       | DBA   | OrgType     | TaxType | TaxIDNo | BusPhone     | BusEmail            | BusWeb        | YearStart | YearOwn | Keyword    |
	| Smoke Test | Smoke | Corporation | FEIN    | Random  | 123-456-7890 | smoketest@gmail.com | smoketest.com | 2011      | 2012    | Accountant |
	Then Verify organization is created
	When User navigates to Drivers SideTab
	Then Verify correct page orgDriver is displayed
	Then Grid column label is displayed
	| Key | Value       |
	| a   | First Name  |
	| b   | Last Name   |
	| c   | Middle Name |
	| d   | Suffix      |
	| e   | DOB         |
	| f   | State       |
	| g   | License #   |
	| h   | Expiration  |

Scenario:TC02 Add a Driver to Organization
	When User adds driver to Organization
	| First | Last | Middle | DOB        | State | Number | Exp        | CDL |
	| Jacob | Seed | J      | 01/02/1975 | AZ    | Random | 01/01/2022 | No  |
	Then Verify driver is added to Organization

Scenario: TC03 Verify Cancel Modal Functionality 
	When User clicks orgDriverAdd button
	When User clicks buttonCancel button

Scenario:TC04 Verify left navigation bar sections
	Then Verify sidetab is present
	| Key | Value                |
	| a   | Business Information |
	| b   | Addresses            |
	| d   | Drivers              |
	| e   | Vehicles             |
	| f   | Trailers             |
	#| c   | Contacts             | Tab Not In Current Build
