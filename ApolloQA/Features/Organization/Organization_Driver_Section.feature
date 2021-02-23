
Feature: Organization Driver Section

Scenario: Driver Add New
	Given user is successfully logged into biberk
	When user navigates to latest organization
	When user clicks 'Drivers' Sidetab
	When user clicks Driver Button
	Then Add Driver modal is visible
	When user enters following values
	| Display Name           | Field Type | Value      |
	| First Name             | Input      | Joseph     |
	| Last Name              | Input      | Driver     |
	| Date of Birth          | Input      | 10/14/1994 |
	| Drivers License State  | Dropdown   | IL         |
	| Drivers License Number | Input      | Random     |
	| Expiration Date        | Input      | 10/15/2023 |
	When user clicks Save button
	Then Toast appears containing text: Driver saved
	Then Verify grid contains entry with column equals value
	| Column    | Value                              |
	| License # | Last Random Drivers License Number |
	When user clicks Edit option for grid with column equals value
	| Column    | Value                              |
	| License # | Last Random Drivers License Number |
	Then Add Driver modal is visible
	And the following fields have values
	| Display Name           | Field Type | Value       |
	| First Name             | Input      | Joseph      |
	| Last Name              | Input      | Driver      |
	| Date of Birth          | Input      | 10/14/1994  |
	| Drivers License State  | Dropdown   | IL          |
	| Drivers License Number | Input      | Last Random |
	| Expiration Date        | Input      | 10/15/2023  |
	When user clicks Cancel button

# Broken - Defect 32288
@bugReported
Scenario: Driver delete
	Given user is successfully logged into biberk
	When user navigates to latest organization
	When user clicks 'Drivers' Sidetab
	When user clicks Driver Button
	Then Add Driver modal is visible
	When user enters following values
	| Display Name           | Field Type | Value      |
	| First Name             | Input      | Joseph     |
	| Last Name              | Input      | Driver     |
	| Date of Birth          | Input      | 10/14/1994 |
	| Drivers License State  | Dropdown   | IL         |
	| Drivers License Number | Input      | Random     |
	| Expiration Date        | Input      | 10/15/2023 |
	When user clicks Save Button	
	Then user deletes entry

