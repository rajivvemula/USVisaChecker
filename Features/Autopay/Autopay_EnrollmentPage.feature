Feature: Autopay_EnrollmentPage

User navigates to the Autopay Enrollment page and sets up either a Credit card or a Bank account autopay

@Ignore @Autopay @Regression 
#This FF is ignored for now until access to the database is implemented so we can pull new policy numbers and related phone numbers, per Laura 
Scenario: Autopay enrollment with Credit Card payment
	Given user has navigated to the following URL within the host environment: /policyholders/autopay-enrollment
	Then user fills in the Autopay Login Page with these values:
		| Policy Number | Phone      |
		| N9PL056656    | 9512838982 |
	Then user verifies the appearance of the Enrollment page
	Then user selects a Credit Card payment plan
	And verifies the appearance of the Credit Card Autopay Enrollment
	Then user fills out the payment information with these values:
		| Field              | Value            |
		| CC Name            | NameF NameL      |
		| CC Number          | 4111111111111111 |
		| CC Expiration Date | 10/25            |
	Then user verifies the Autopay Payment Completed page

Scenario: Autopay enrollment with Checking Account payment
	Given user has navigated to the following URL within the host environment: /policyholders/autopay-enrollment
	Then user fills in the Autopay Login Page with these values:
		| Policy Number | Phone      |
		| N9PL056696    | 9083001040 |
	Then user verifies the appearance of the Enrollment page
	Then user selects a Direct Draft payment plan
	And user selects the Checking account option
	And verifies the appearance of the Direct Draft Autopay Enrollment
	Then user fills out the payment information with these values:
		| Field          | Value             |
		| Account Number | 90001111222233333 |
		| Routing Number | 031300012         |
	Then user verifies the Autopay Payment Completed page

Scenario: Autopay enrollment with Savings Account payment
	Given user has navigated to the following URL within the host environment: /policyholders/autopay-enrollment
	Then user fills in the Autopay Login Page with these values:
		| Policy Number | Phone      |
		| N9PL057734    | 6122701705 |
	Then user verifies the appearance of the Enrollment page
	Then user selects a Direct Draft payment plan
	And verifies the appearance of the Direct Draft Autopay Enrollment
	And user selects the Savings account option
	Then user fills out the payment information with these values:
		| Field          | Value             |
		| Account Number | 90001111222233333 |
		| Routing Number | 031300012         |
	Then user verifies the Autopay Payment Completed page