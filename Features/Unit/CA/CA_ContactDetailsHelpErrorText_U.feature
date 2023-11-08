Feature: CA_ContactDetailsPageHelpErrorText_U

This file validates the appearance of error text on the contact details page

@Unit @CA
Scenario: CA Contact Details Page Help Error Text Unit
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 2         | I Lease a Space From Others | Vehicles     | 65781    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		| TestBusName      |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1    | Address2 | City    | Select an Address |
		| 2012                  | Corporation             | 109 Long St |          | Willard | Suggested         |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Trim        | Parking Address | Vehicle Worth | How Used                            | Deliver Goods |
		| 3N1CB51DX3L800403 | Sedan 4D XE | Missouri        | 2000          | Errands only - no Delivery/Catering | No            |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| Aubrey    | Plaza    | OH      | 03/13/1985 |     |       |             |             | No       |          |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	Then user continues to the Contact page
	And user enters contact information:
		| Question         | Answer |
		| Business Website | abc123 |
	Then user verifies the help and error text of the contact details page