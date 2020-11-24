Feature: Shared
	As a user I want to keep a collection of shared steps

@ignore
Scenario: Shared Given
	
@ignore
Scenario: Shared When
	When user clicks <DisplayName> Button
	When user clicks <DisplayName> Dropdown



	When user enters the following address
	| Field Display Name        | Field Type | Field Value     |
	| Street Address Line 1     | Input      | 618 E Laurel st |
	| Street Address Line 2     | Input      |                 |
	| City                      | Input      | Springfield     |
	| State / Province / Region | Dropdown   | IL              |
	| Zip / Postal Code         | Input      | 62703           |
	| Country                   | Dropdown   | United States   |
	And user saves the address

@ignore
Scenario: Shared Then
	
	
