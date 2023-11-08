Feature: CA_SaveForLaterModalErrorText_U

Verifies that the appropriate error message appears within the save quote for later modal window in regular and slim modal.

@Unit @CA @SFL @testSfl
Scenario: CA Save For Later Modal Error Text Unit
	Given user starts a quote with:
		| Industry      | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Art Therapist | 2         | I Run My Business From Property I Own | Vehicles     | 60606    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user verifies the CA save for later regular modal error message appears
	Then user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1       | Address2 | City    | Select an Address |
		| 2010                  | Corporation             | 225 S Canal St |          | Chicago |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user verifies the CA save for later regular modal error message appears
	Then user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth | Client Locations |
		| 1D4GP24E17B260680 | Illinois        | 12000         | No               |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user verifies the CA save for later regular modal error message appears
	Then user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber     |
		| Mickey    | Mouse    | IL      | 03/13/1985 |     |       |             |             | No       | c01234567890 |
	Then user clicks Let's Continue
	And user verifies the CA save for later regular modal error message appears
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| Do you provide emergency response services?                                                 | No               |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user verifies the CA save for later regular modal error message appears
	Then user enters contact information:
		| Question                        | Answer                 |
		| First Name                      | Ariana                 |
		| Last Name                       | Grande                 |
		| Business Email                  | chauffeur@yopmail.com  |
		| Business Phone                  | (555) 867-5309         |
		| Business Website                |                        |
		| Business has an account manager |                        |
		| Want Save Money                 | Yes                    |
		| Owner's First Name              | AutoLarryzzzzzzzzzzz   |
		| Owner's Last Name               | AutoBarryzzzzzzzzzzzzz |
		| Owner's Address                 | 1879 Watson Blvd Apt 1 |
		| Owner's Address 2               |                        |
		| Owner's Zip Code                | 31093                  |
		| Owner's City                    | warner robins          |
		| Owner's State                   | Georgia                |
		| Select an Address               | Suggested              |
	Then user verifies the appearance of the Summary page
	Then user verifies the CA save for later slim modal error message appears