
Feature: Organization_AddAddress


Scenario: Add Address to existing Organization
	Given user is successfully logged into biberk
	When user enters search query: Automation Test Org 1223
	And user clicks first search result
	Then URL contains organization/
	And Business Information sidetab is active
	When user clicks Addresses sidetab
	Then Addresses sidetab is active
	When user clicks Add Address Button
	Then Add New Address modal is visible
	When user enters following values
	| Display Name              | Field Type | Value            |
	| Street Address Line 1     | Input      | 14210 Avalon Ave |
	| City                      | Input      | Dolton           |
	| State / Province / Region | Dropdown   | IL               |
	| Zip / Postal Code         | Input      | 60419            |
	When user clicks Save Button
	Then Verify grid contains entry with column equals value
	| Column         | Value            |
	| Street Address | 14210 Avalon Ave |
	When user clicks Edit option for grid with column equals value
	| Column         | Value            |
	| Street Address | 14210 Avalon Ave |
	Then Add New Address modal is visible
	And the following fields have values
	| Display Name              | Field Type | Value            |
	| Street Address Line 1     | Input      | 14210 Avalon Ave |
	| City                      | Input      | Dolton           |
	| State / Province / Region | Dropdown   | IL               |
	| Zip / Postal Code         | Input      | 60419            |
	When user clicks Cancel button