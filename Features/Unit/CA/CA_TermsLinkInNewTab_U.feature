Feature: CA_TermsLinkInNewTab_U

Verifying that the terms link of the quote details page opens a new tab in the browser

@Unit @CA @Staging @Regression @WI
Scenario: CA Terms Link In New Tab Unit View Coverage Details
	Given user starts a quote with:
		| Industry             | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Actuarial Consulting | 0         | I Lease a Space From Others | Vehicles     | 54311    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA      | Policy Start Date |
		| Test wisconsin   | TEST DBA |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured     | Address1            | Address2 | City      | Select an Address |
		| 2015                  | Limited Liability Co. (LLC) | 2535 Wildflower Row |          | Green Bay |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 2HGCA5534HH007097 | Wisconsin       | 1000          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber       |
		| TestF     | TestL    | WI      | 09/01/1991 |     |       |             |             | No       | W1234567890123 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question         | Answer                  |
		| First Name       | TestF                   |
		| Last Name        | TestL                   |
		| Business Email   | QAAutomation@biberk.com |
		| Business Phone   | (123) 123-1321          |
		| Business Website | test.com                |
		| Want Save Money  | No                      |
	Then user verifies landing on Summary page
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	When user opens the Quote Details Page
	Then user verifies that the terms link displays the terms in a new tab when selected