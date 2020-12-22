@demo
Feature: US-13121-Add vehicle screen to Organization
	As an underwriter, 
	I want to be able to add vehicles to an organization 
	and show them in a grid, so that I can associate them in a policy coverage.


Scenario: TC01 Verify Grid Titles in Vehicle Organization
	Given user is successfully logged into biberk
	When user clicks Organization Button
	When user clicks  New  Button
	And user waits for spinner to load
	When user enters business information
	| BusinessName | DBA | TaxIdType | TaxIdNumber | DescriptionOfOperations | BusinessPhoneNumber | BusinessEamil  | BusinessWebsite | Keyword	| YearStarted | YearOwned |
	| TheTestOrg   | dba | FEIN      | 81-6541000  | DescriptionofOps        | 8021585010          | testorg@me.com | testorg.com     | S       | 2000        | 2005      |
	And user clicks  Save  Button
	And user waits for spinner to load
	When user clicks Vehicles Sidetab
	Then Grid column label is displayed
	| Key | Value         |
	| a   | Veh #         |
	| b   | Year          |
	| c   | Make & Model  |
	| d   | VIN           |
	| e   | GVW           |
	| f   | Cost New      |
	| g   | Stated Amount |

#scenario not mutually exclusive
	#TC02 and TC03 Combined, the last statement is TC03 and shared scenario context 
@broken
Scenario: TC02 Add a vehicle to Organization
	When user clicks Vehicle Button
	When user enters following values
	| Display Name             | Field Type | Value                |
	| VIN                      | Input      | 1FDWR80U5HVB06629    |
	| Year                     | Input      | 1999                 |
	| Make                     | Input      | Ford                 |
	| Model                    | Input      | Fire                 |
	| Vehicle Trim             | Input      | Sport                |
	| Body Category            | Dropdown   | Cars, Pickup, or SUV |
	| Body Subcategory         | Dropdown   | Random               |
	| Seating Capacity         | Dropdown   | Random               |
	| Gross Vehicle Weight     | Dropdown   | Random               |
	| Cost New                 | Input      | $ 22,000.00          |
	| Estimated Current Value  | Input      | $ 14,000.00          |
	| Additional Modifications | Input      | Test comment.        |
	| Stated Amount            | Input      | $ 12,000.00          |
	When user clicks Save Button
	Then Toast with a message: Vehicle saved is visible 

#scenario not mutually exclusive
@broken 
Scenario: TC03 
	Then Grid contains: 1FDWR80U5HVB06629



