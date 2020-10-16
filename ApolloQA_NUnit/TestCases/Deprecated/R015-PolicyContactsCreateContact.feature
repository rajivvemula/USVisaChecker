@reg @pol
Feature: R015-PolicyContactsCreateContact
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario: 1 User Can Click Add New Contact Button
	When User Click Add New Contact Button
	Then User is shown the Contact Insert Screen

Scenario: 2 User enters a new contact to be verified
	When User enters all inputs in insert contact screen
	| Role                            | First | Middle | Last  | Suffix | Email            | Job       | Company | Internet   | Remarks  | PhoneType | PhoneNumber   |
	| Customer Service Representative | John  | J      | Smith | Mr     | JSmith@Gmail.com | Developer | Biberk  | Biberk.com | Internal | Mobile    | 3469994485 |
	When User clicks the save button in insert contact screen
	Then User is shown a toast saying Contact Saved Succesfully