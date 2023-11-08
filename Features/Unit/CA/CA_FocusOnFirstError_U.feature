Feature: CA_FocusOnFirstError_U

Verifying the focus on the first error from CA Operation Page

@Unit @CA
Scenario: Verifying the Focus on First Error from Operations Page
	Given user starts a quote with:
		| Industry          | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Hot Shot Trucking | 3         | I Work at a Job Site | Vehicles     | 95204    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA         | Policy Start Date |
		| TEST CA QUOTE    | TEST CA DBA |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1             | Address2 | City     | Select an Address |
		| 2000                  | Corporation             | 1687 N California St |          | Stockton |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 1M1AE07Y63W014598 | California      | 3000          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | Accident | DLNumber |
		| TEST FN   | TEST LN  | CA      | 08/08/1988 | Yes 3 or more years | No       | E9758462 |
	Then user clicks continue from the Drivers page
	Then user verifies the focus on the first error from the Operations Page