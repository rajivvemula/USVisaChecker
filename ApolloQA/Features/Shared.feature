Feature: Shared
	As a user I want to keep a collection of shared steps

@ignore
Scenario: Shared Given
	
@ignore
Scenario: Shared When
	When user clicks <DisplayName> Button
	When user clicks <DisplayName> Dropdown
	When user clicks <DisplayName> Sidetab
	When user selects dropdown <DropdownDisplayText> option equaling <OptionDisplayText>
	When user selects dropdown <DropdownDisplayText> option containing <OptionDisplayName>
	When user selects dropdown <DropdownDisplayText> option at index <Optionindex>

	When user waits 1 seconds

	When user enters the following address
	| Field Display Name        | Field Type | Field Value     |
	| Street Address Line 1     | Input      | 618 E Laurel st |
	| Street Address Line 2     | Input      |                 |
	| City                      | Input      | Springfield     |
	| State / Province / Region | Dropdown   | IL              |
	| Zip / Postal Code         | Input      | 62703           |
	| Country                   | Dropdown   | United States   |
	And user saves the address


	When user selects answer to <Question display text> as <Answer display text>



@ignore
Scenario: Shared Then

	Then Grid column label is displayed
	| Key | Value |
	| a   | label |
	Then Grid contains: <Value>
	
	Then Toast with a message: <Message> is visible 

	Then Verify sidetab is present
	| Key | Value                |
	| a   | Business Information |

