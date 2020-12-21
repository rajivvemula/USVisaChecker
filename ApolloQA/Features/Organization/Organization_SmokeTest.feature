Feature: Organization_SmokeTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: 1 Test Create Org
	Given user is successfully logged into biberk
	When user clicks Organization tab
	When user clicks New button
	Then URL contains organization/insert
	When user enters following values
	| Display Name              | Field Type   | Value                                                  |
	| Business Name             | Input        | Automation Test Org 1218                               |
	| Organization Type         | Dropdown     | Corporation                                            |
	| Tax ID Type               | Dropdown     | FEIN                                                   |
	| Tax ID No                 | Input        | 12-3123111                                             |
	| Description Of Operations | Input        | Sample text.                                           |
	| Business Phone No.        | Input        | 249-213-1518                                           |
	| Business Email Address    | Input        | business@email.com                                     |
	| Business Website          | Input        | business.com                                           |
	| Keyword                   | Autocomplete | Pizza - Restaurant - no deep frying - no table service |
	| Year Business Started     | Input        | 2017                                                   |
	| Year Ownership Started    | Input        | 2018                                                   |
	Then the following fields have values
	| Display Name   | Field Type | Value |
	| Class Taxonomy | Input      | Any   |
	And Save button is enabled
	When user clicks Save button
	Then URL contains /organization/
	And Business Information sidetab is active
	And the following fields have values
	| Display Name              | Field Type   | Value                                                  |
	| Business Name             | Input        | Automation Test Org 1218                               |
	| Organization Type         | Dropdown     | Corporation                                            |
	| Tax ID Type               | Dropdown     | FEIN                                                   |
	| Tax ID No                 | Input        | 12-3123111                                             |
	| Description Of Operations | Input        | Sample text.                                           |
	| Business Phone No.        | Input        | 249-213-1518                                           |
	| Business Email Address    | Input        | business@email.com                                     |
	| Business Website          | Input        | business.com                                           |
	| Keyword                   | Autocomplete | Pizza - Restaurant - no deep frying - no table service |
	| Class Taxonomy            | Input        | Hospitality\Restaurants\All Other                      |
	| Year Business Started     | Input        | 2017                                                   |
	| Year Ownership Started    | Input        | 2018                                                   |

Scenario: 2 Add Vehicle to Organization
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