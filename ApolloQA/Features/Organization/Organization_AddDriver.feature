
Feature: Organization_AddDriver

Scenario: Add Driver to existing Organization
	Given user is successfully logged into biberk
	When user enters search query: Automation Test Org 1223
	And user clicks first search result
	Then URL contains organization/
	And Business Information sidetab is active
	When user clicks Drivers sidetab
	Then Drivers sidetab is active
	When user clicks Driver Button
	Then Add Driver modal is visible
	When user enters following values
	| Display Name           | Field Type | Value          |
	| First Name             | Input      | Joseph         |
	| Last Name              | Input      | Driver         |
	| Date of Birth          | Input      | 10/14/1994     |
	| Drivers License State  | Dropdown   | IL             |
	| Drivers License Number | Input      | F255-9215-0094 |
	| Expiration Date        | Input      | 10/15/2023     |
	| CDL                    | Dropdown   | Yes            |
	When user clicks Save Button
	Then Verify grid contains entry with column equals value
	| Column    | Value          |
	| License # | F255-9215-0094 |
	When user clicks Edit option for grid with column equals value
	| Column    | Value          |
	| License # | F255-9215-0094 |
	Then Add Driver modal is visible
	And the following fields have values
	| Display Name           | Field Type | Value          |
	| First Name             | Input      | Joseph         |
	| Last Name              | Input      | Driver         |
	| Date of Birth          | Input      | 10/14/1994     |
	| Drivers License State  | Dropdown   | IL             |
	| Drivers License Number | Input      | F255-9215-0094 |
	| Expiration Date        | Input      | 10/15/2023     |
	| CDL                    | Dropdown   | Yes            |
	When user clicks Cancel button