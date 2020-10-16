
Feature: C004-Add An Address To Organization
Create an organization with given parameters


Scenario: Add an address to Organization
	When User adds address to Organization 
	| Line1        | City         | State | Zip   |
	| 39 Public Sq | Wilkes Barre | PA    | 18701 |
	Then Verify address is added to Organization