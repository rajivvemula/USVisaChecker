Feature: Partners

Verifying the elements on Partners page

@Partners @Regression @Unit @Static 
Scenario: Partner Page Verification
	Given user has navigated to the following URL within the host environment: become-a-biberk-partner
	Then user verifies the Partners page
	Then user fills out the Patrners Contact form with the following values:
	| Question   | Answer          |
	| First Name | First           |
	| Last Name  | Last            |
	| Company    | Company         |
	| Email      | email@email.com |
	| Phone      | 1111111111      |
	