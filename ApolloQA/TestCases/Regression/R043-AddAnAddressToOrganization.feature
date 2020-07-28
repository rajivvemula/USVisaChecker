@org
Feature: R043-AddAnAddressToOrganization
	


Scenario: User is able to add an address to a newly created organization
	Given User is Address Tab
	When User Clicks Add Address
	And User inputs address details
	| Address          | City         | State        | Zip |
	| 39 Public Square | Wilkes Barre | Pennsylvania | 18703 | 
	Then User Submits the address
	Then Address is added in the grid

Scenario: User is able to edit the address
	When User clicks edit on a adress in the grid
	Then Address model is shown with address filled
	When user edits Address 
	And User saves changes
	Then Edited addrress should appear in the grid