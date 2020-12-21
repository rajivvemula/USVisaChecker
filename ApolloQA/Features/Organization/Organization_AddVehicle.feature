Feature: Organization_AddVehicle

Scenario: Add Vehicle to existing Organization using VIN
	Given user is successfully logged into biberk
	When user enters search query: Automation Test Org 1218
	And user clicks first search result
	Then URL contains organization/
	And Business Information sidetab is active
	When user clicks Vehicles sidetab
	Then Vehicles sidetab is active
	When user clicks Vehicle Button
	Then New Vehicle modal is visible
	When user enters following values
	| Display Name | Field Type | Value  |
	| VIN          | Input      | Random |
	And user clicks Verify VIN button
	Then the following fields have values
	| Display Name | Field Type | Value |
	| Year         | Input      | Any   |
	| Make         | Input      | Any   |
	| Model        | Input      | Any   |
	When user enters following values
	| Display Name             | Field Type | Value                |
	| Vehicle Trim             | Input      | Sport                |
	| Body Category            | Dropdown   | Cars, Pickup, or SUV |
	| Body Subcategory         | Dropdown   | Random               |
	| Seating Capacity         | Dropdown   | Random               |
	| Gross Vehicle Weight     | Dropdown   | Random               |
	| Cost New                 | Input      | $ 22,000.00          |
	| Estimated Current Value  | Input      | $ 14,000.00          |
	| Additional Modifications | Input      | Test comment.        |
	| Stated Amount            | Input      | $ 12,000.00          |
	Then the following fields have values
	| Display Name             | Field Type | Value         |
	| Vehicle Trim             | Input      | Sport         |
	| Body Category            | Dropdown   | Any           |
	| Additional Modifications | Input      | Test comment. |
	| Stated Amount            | Input      | $ 12,000.00   |
	When user clicks Save Button
	Then Toast with a message: Vehicle saved is visible
	Then Vehicles sidetab is active
	And Verify grid contains entry with column equals value
	| Column | Value             |
	| VIN    | Last Random       |
	When user clicks Edit option for grid with column equals value
	| Column | Value       |
	| VIN    | Last Random |
	Then Edit Vehicle modal is visible
	And the following fields have values
	| Display Name             | Field Type | Value                |
	| Vehicle Trim             | Input      | Sport                |
	| Body Category            | Dropdown   | Cars, Pickup, or SUV |
	| Body Subcategory         | Dropdown   | Any                  |
	| Seating Capacity         | Dropdown   | Any                  |
	| Gross Vehicle Weight     | Dropdown   | Any                  |
	| Cost New                 | Input      | $ 22,000.00          |
	| Estimated Current Value  | Input      | $ 14,000.00          |
	| Additional Modifications | Input      | Test comment.        |
	| Stated Amount            | Input      | $ 12,000.00          |