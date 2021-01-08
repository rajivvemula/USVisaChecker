@demo @broken
Feature: US-17639-Org Mgt Driver
	As an underwriter, 
	I want to update the Driver functionality at the Organization Level, 
	so that I can pull it in as necessary at the Application Quote level.

Scenario: TC01 Verify Grid Titles in Driver
	Given user is successfully logged into biberk
	When user clicks Organization Button
	And user selects Organization
	And user waits for spinner to load
	When user clicks Drivers Sidetab
	And user waits for spinner to load
	Then Grid column label is displayed
	| Key | Value        |
	| a   | Driver #     |
	| b   | License #    |
	| c   | State        |
	| d   | First Name   |
	| e   | Last Name    |
	| f   | Status       |
	#| g   | Excluded     |
	#| h   | Driver Added |
	#| i   | Accidents    |
	#| j   | Violations   |
	#| k   | Convictions  |
	#| l   | DL Status    |


#scenario not mutually exclusive, failing on pipeline
@broken
Scenario: TC02 Add a Driver to Organization
	When user clicks  Driver Button
	When user enters following values
	| Display Name           | Field Type | Value     |
	| First Name             | Input      | Jacob     |
	| Last Name              | Input      | Sample    |
	| Middle Name            | Input      | J         |
	| Suffix                 | Input      | Mr        |
	| Date of Birth          | Input      | 3/2/1983  |
	| Drivers License State  | Dropdown   | AZ        |
	| Drivers License Number | Input      | AZ27235   |
	| Expiration Date        | Input      | 10/4/2024 |
	| CDL                    | Dropdown   | No        |
	When user clicks Save Button
	Then Toast with a message: Driver saved is visible 

#scenario not mutually exclusive, failing on pipeline
@broken
Scenario: TC04 Verify left navigation bar sections
	Then Verify sidetab is present
	| Key | Value                |
	| a   | Business Information |
	| b   | Addresses            |
	| d   | Drivers              |
	| e   | Vehicles             |
	| f   | Trailers             |