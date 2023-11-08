Feature: CA_TransportationServicesForTheElderly_D
Delined due to answering 'Yes' to 'Do you provide any emergency transportation services?' in the Operations page.

@Declined @Regression @MO @CA @Transportation
Scenario: CA Transportation Services for the Elderly gets declined in MO
	Given user starts a quote with:
		| Industry                                | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Transportation Services for the Elderly | 2         | I Run My Business From Property I Own | Vehicles     | 65109    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1           | Address2 | City           | Select an Address |
		| 2000                  | Corporation             | 1425 Missouri Blvd |          | Jefferson City |                   |
	Then user fills in the alternate mailing address with these values:
		| Address1     | Address2 | Zip   | City     | State    | Select an Address |
		| 1213 Noah Dr | APT 4    | 63052 | Imperial | Missouri | Suggested         |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 5N1AR18U65C767389 | Missouri        | 2800          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber  |
		| Daisy     | Duck     | MO      | 03/13/1986 |     |       |             |             | No       | 085671243 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                            | Answer          |
		| Do you offer "party" bus or limousine services where alcohol is provided or expressly permitted?    | No              |
		| Do you provide any school, camp, day care, or field trip transportation for children 12 or younger? | No              |
		| What is the furthest any of your vehicles travel in any one direction from their home base?         | 51 to 100 miles |
		| Do any of your vehicles travel to Mexico?                                                           | No              |
		| How many auto insurance claims did your business file in the last 3 years?                          | 0               |
		| Do you provide any emergency transportation services?                                               | Yes             |
		| Do you rent any vehicles?                                                                           | No              |
		| Do you use any Owner-Operators?                                                                     | No              |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer           |
		| First Name                      | Ariana           |
		| Last Name                       | Grande           |
		| Business Email                  | ag@gmail.com     |
		| Business Phone                  | (555) 867-5309   |
		| Business Website                |                  |
		| Business has an account manager |                  |
		| Want Save Money                 | Yes              |
		| Owner's First Name              | Larry            |
		| Owner's Last Name               | Barry            |
		| Owner's Address                 | 2112 S Spring St |
		| Owner's Address 2               |                  |
		| Owner's Zip Code                | 62704            |
		| Owner's City                    | Springfield      |
		| Owner's State                   | IL               |
	Then user verifies the appearance of the Decline page