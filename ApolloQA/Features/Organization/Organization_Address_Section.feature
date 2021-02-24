Feature: Organization Address Section


Scenario: Organization Address Add New
	Given user is successfully logged into biberk
	When user navigates to latest organization
	When user clicks 'Addresses' Sidetab
	When user clicks 'Add Address' Button
	When user enters the following address
	| Field Display Name        | Field Type | Field Value      |
	| Street Address Line 1     | Input      | 14210 Avalon Ave |
	| Street Address Line 2     | Input      |                  |
	| City                      | Input      | Dolton           |
	| State / Province / Region | Dropdown   | IL               |
	| Zip / Postal Code         | Input      | 60419            |
	| Country                   | Dropdown   | United States    |
	And user saves the address
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
	When user clicks 'Cancel' Button