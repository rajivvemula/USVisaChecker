Feature: CA_MarylandDriverLicenseValidation_U

Validating old (1 Alphabetic, 12 Numeric) and new ("MD" then 11 Numeric) MD driver license options

@Unit @Regression @CA
Scenario: Validating Maryland Driver License Options
	Given user starts a quote with:
		| Industry                | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Amazon Delivery Service | 3         | I Lease a Space From Others | Vehicles     | 21701    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business   | DBA | Policy Start Date |
		| TEST CA AUTH QUOTE |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1     | Address2 | City      | Select an Address |
		| 2020                  | Corporation             | 247 Dill Ave |          | Frederick |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 4T1BK46K57U514394 | Maryland        | 5000          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | Accident | DLNumber      |
		| John      | Legend   | MD      | 10/10/1990 | No  | Yes      | A123456789123 |
		| Kelly     | Clarkson | MD      | 10/01/1990 | No  | Yes      | MD12345678910 |
	Then user clicks continue from the Drivers page
	Then user verifies the appearance of the Drivers Incidents page