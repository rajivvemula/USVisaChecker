Feature: Quote Section Contacts


Scenario: Quote Contact Add

	Given user is successfully logged into biberk
	When user clicks 'Quote' Button
	And User Navigates to Quote latest
	When user clicks 'Contacts' Sidetab
	And user clicks 'Contact' Button
	And user selects dropdown Contact Name option equaling Add Contact
	And user adds a new Contact with the following relevant values
	| First Name | Last Name | Middle Name | Suffix | Title | Primary Phone | Email           | Secondary Phone | Roles           | Notes      |
	| Automation | Contact   | Test        | Jr.    | Mr    | 2017900720    | test@biberk.com |                 | Primary Officer | some notes |
	And user selects dropdown Address option equaling Add Address
	And user enters the following address
	| Field Display Name    | Field Type | Field Value     |
	| Street Address Line 1 | Input      | 618 E Laurel st |
	| Street Address Line 2 | Input      |                 |
	| City                  | Input      | Springfield     |
	| State / Region        | Dropdown   | IL              |
	| Zip / Postal Code     | Input      | 62703           |
	| Country               | Dropdown   | United States   |
	And user saves the address
	And user waits for spinner to load
	Then Toast with a message: Contact was successfully saved. is visible
	