Feature: Organization_AddVehicle

Scenario: Add Vehicle to existing Organization using VIN
	Given user is successfully logged into biberk
	When user navigates to latest organization
	Then URL contains organization/
	And Business Information sidetab is active
	When user clicks Vehicles sidetab
	Then Vehicles sidetab is active
	When user clicks Vehicle button
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
	| Cost New                 | Input      | 22000                |
	| Estimated Current Value  | Input      | 14000                |
	| Additional Modifications | Input      | Test comment.        |
	| Stated Amount            | Input      | 12000                |
	Then the following fields have values
	| Display Name             | Field Type | Value         |
	| Vehicle Trim             | Input      | Sport         |
	| Body Category            | Dropdown   | Any           |
	| Additional Modifications | Input      | Test comment. |
	| Stated Amount            | Input      | 12000         |
	When user clicks Save button
	Then Toast appears containing text: Vehicle saved
	When user navigates to latest organization
	Then URL contains organization/
	And Business Information sidetab is active
	When user clicks Vehicles sidetab
	Then Vehicles sidetab is active
	Then user deletes entry