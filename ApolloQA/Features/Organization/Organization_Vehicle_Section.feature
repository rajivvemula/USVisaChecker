Feature: Organization Vehicle Section


# Broken - Defect 24781
@bugReported
Scenario: Organization Vehicle add new
	Given user is successfully logged into biberk
	When user navigates to latest organization
	And user clicks 'Vehicles' Sidetab
	And user clicks 'Vehicle' Button
	Then New Vehicle modal is visible
	When user enters following values
	| Display Name | Field Type | Value  |
	| VIN          | Input      | Random |
	And user clicks 'Verify VIN' Button
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
	When user clicks 'Save' Button
	Then Toast appears containing text: Vehicle saved
	Then Vehicles sidetab is active
	And Verify grid contains entry with column equals value
	| Column | Value           |
	| VIN    | Last Random VIN |
	When user clicks Edit option for grid with column equals value
	| Column | Value           |
	| VIN    | Last Random VIN |
	Then Edit Vehicle modal is visible
	And the following fields have values
	| Display Name             | Field Type | Value                |
	| Vehicle Trim             | Input      | Sport                |
	| Body Category            | Dropdown   | Cars, Pickup, or SUV |
	| Body Subcategory         | Dropdown   | Any                  |
	| Seating Capacity         | Dropdown   | Any                  |
	| Gross Vehicle Weight     | Dropdown   | Any                  |
	| Cost New                 | Input      | 22000                |
	| Estimated Current Value  | Input      | 14000                |
	| Additional Modifications | Input      | Test comment.        |
	| Stated Amount            | Input      | 12000                |
	When user clicks 'Cancel' Button

	# Broken - Defect 32287
	@bugReported
Scenario: Organization Vehicle Delete
	Given user is successfully logged into biberk
	When user navigates to latest organization
	And user clicks 'Vehicles' Sidetab
	And user clicks 'Vehicle' Button
	Then New Vehicle modal is visible
	When user enters following values
	| Display Name | Field Type | Value  |
	| VIN          | Input      | Random |
	And user clicks 'Verify VIN' Button
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
	When user clicks 'Save' Button
	Then Toast appears containing text: Vehicle saved
	Then user deletes entry