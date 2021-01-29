
Feature: Organization_AddDriver

Scenario: Add Driver to existing Organization
	Given user is successfully logged into biberk
	When user navigates to latest organization
	Then URL contains organization/
	And Business Information sidetab is active
	When user clicks Drivers sidetab
	Then Drivers sidetab is active
	When user clicks Driver button
	Then Add Driver modal is visible
	When user enters following values
	| Display Name           | Field Type | Value      |
	| First Name             | Input      | Joseph     |
	| Last Name              | Input      | Driver     |
	| Date of Birth          | Input      | 10/14/1994 |
	| Drivers License State  | Dropdown   | IL         |
	| Drivers License Number | Input      | Random     |
	| Expiration Date        | Input      | 10/15/2023 |
	| CDL                    | Dropdown   | Yes        |
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
	| CDL                    | Dropdown   | Yes         |
	When user clicks Cancel button

Scenario: Delete Driver from existing Organization
	Given user is successfully logged into biberk
	When user navigates to latest organization
	Then URL contains organization/
	And Business Information sidetab is active
	When user clicks Drivers sidetab
	Then Drivers sidetab is active
	When user clicks Driver button
	Then Add Driver modal is visible
	When user enters following values
	| Display Name           | Field Type | Value      |
	| First Name             | Input      | Joseph     |
	| Last Name              | Input      | Driver     |
	| Date of Birth          | Input      | 10/14/1994 |
	| Drivers License State  | Dropdown   | IL         |
	| Drivers License Number | Input      | Random     |
	| Expiration Date        | Input      | 10/15/2023 |
	| CDL                    | Dropdown   | No         |
	When user clicks Save button
	Then Toast appears containing text: Driver saved
	When user navigates to latest organization
	Then URL contains organization/
	And Business Information sidetab is active
	When user clicks Drivers sidetab
	Then Drivers sidetab is active
	Then user deletes entry
