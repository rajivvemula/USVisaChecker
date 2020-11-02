Feature: US-13749 - Adding a vehicle - verifying accuracy via VinTelligence

#13749 - TC01 - Verify the ability to submit a VIN
#13749 - TC02 - Submit VALID VIN and verify fields are populated on the vehicle form
#13749 - TC03 - Submit INVALID VIN-Verify error message returned clearly states invalid VIN
#13749 - TC04 - Verify ability to 'reset' fields after VIN results are returned or error is received
#13749 - TC05 - Verify the ability to save results after VIN passes validation
#13749 - TC06 - Verify added vehicle appears in Vehicle list

#Note: TC04 is no longer applicable as the reset button isn't available. Users can click cancel and then click +Vehicle button again. 


Scenario: 1 Navigate to existing Organization
	Given User is on Apollo Homepage
	When I enter organization name Casey IL Test Org 1023 in the search field
	And I click the first search result
	Then I should be directed to organization Casey IL Test Org 1023

Scenario: 2 Add a vehicle using a valid VIN
	When User navigates to Vehicles SideTab
	And User clicks orgVehicleAdd button
	Then New Vehicle modal is visible
	When User enters following values
	| Field Name               | Field Type | Value                |
	| VIN                      | Input      | Random               |
	And User clicks orgVehicleVerifyVIN button
	Then the following fields have values
	| Field Name | Field Type | Value |
	| Year       | Input      | Any   |
	| Make       | Input      | Any   |
	| Model      | Input      | Any   |
	When User enters following values
	| Field Name               | Field Type | Value                |
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
	| Field Name               | Field Type | Value         |
	| Vehicle Trim             | Input      | Sport         |
	| Body Category            | Dropdown   | Any           |
	| Additional Modifications | Input      | Test comment. |
	| Stated Amount            | Input      | $ 12,000.00   |
	When User clicks orgVehicleSave button
	Then Verify correct toast Vehicle saved is displayed

Scenario: 3 Verify vehicle was added to Vehicle grid
	Then Verify Grid contains entry with column equals value
	| Column | Value             |
	| VIN    | Last Random       |
	| VIN    | 1C6RR6FPXDS586955 |
	| VIN    | WMWSV3C56BTY10265 |
	When User clicks Grid ellipsis option for entry with column equals value
	| Column | Value       | Option |
	| VIN    | Last Random | View   |
	Then View Vehicle modal is visible
	And the following fields have values
	| Field Name               | Field Type | Value                |
	| VIN                      | Input      | Last Random          |
	| Vehicle Trim             | Input      | Sport                |
	| Body Category            | Dropdown   | Cars, Pickup, or SUV |
	| Body Subcategory         | Dropdown   | Any                  |
	| Seating Capacity         | Dropdown   | Any                  |
	| Gross Vehicle Weight     | Dropdown   | Any                  |
	| Cost New                 | Input      | $ 22,000.00          |
	| Estimated Current Value  | Input      | $ 14,000.00          |
	| Additional Modifications | Input      | Test comment.        |
	When User clicks buttonCancel button

Scenario: 4 Add a vehicle using an invalid VIN
	When User navigates to Vehicles SideTab
	And User clicks orgVehicleAdd button
	Then New Vehicle modal is visible
	When User enters following values
	| Field Name | Field Type | Value        |
	| VIN        | Input      | VIN123458686 |
	And User clicks orgVehicleVerifyVIN button
	Then Verify correct toast Invalid VIN number is displayed
	When User clicks buttonCancel button 