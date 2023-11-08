Feature: CA_NoPP_U
Purpose: Verify the apperance and function of the No PP page.
State: SC
Number of Vehicles: 1
Number of Trailers: 0

@Regression @CA @Auto @Unit
Scenario: CA No PP Page Unit
	Given user starts a quote with:
		| Industry                                             | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Trucking: Long Distance Hauling: more than 300 miles | 2         | I Run My Business From Property I Own | Vehicles     | 29209    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1              | Address2 | City     | Select an Address |
		| 2012                  | Corporation             | 7501 Garners Ferry Rd |          | Columbia |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 5TDDK3DCXGS129517 | South Carolina  | 2800          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber  |
		| Aubrey    | Plaza    | SC      | 03/13/1985 | Yes 3 or more years |       |             |             | No       | 098657477 |
		| Anna      | Kendrick | SC      | 01/30/2000 | Yes 3 or more years |       |             |             | No       | 123574987 |
		| Emma      | Stone    | SC      | 08/11/1993 | Yes 3 or more years |       |             |             | No       | 048798455 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                                                                              | Answer                      |
		| Do you haul intermodal containers?                                                                                                                    | No                          |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                           | 50 miles or less            |
		| Do you haul any fine art or jewelry?                                                                                                                  | No                          |
		| Do you provide residential moving services?                                                                                                           | No                          |
		| Does your business engage in team driving?                                                                                                            | Yes we do some team driving |
		| Do any of your vehicles travel to Mexico?                                                                                                             | No                          |
		| How many auto insurance claims did your business file in the last 3 years?                                                                            | 0                           |
		| I agree to submit proof of insurance claims history, also known as loss runs, for the last 3 years within 30 days of the effective date of the policy | true                        |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                       | No                          |
		| Do you haul any hazardous materials?                                                                                                                  | No                          |
		| Do you rent any vehicles?                                                                                                                             | No                          |
		| Do you use any Owner-Operators?                                                                                                                       | No                          |
		| Does your business have a USDOT Number?                                                                                                               | No                          |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer           |
		| First Name                      | Ariana           |
		| Last Name                       | Grande           |
		| Business Email                  | a@b.co           |
		| Business Phone                  | (555) 867-5309   |
		| Business Website                |                  |
		| Business has an account manager |                  |
		| Manager's First Name            |                  |
		| Manager's Last Name             |                  |
		| Manager's Email                 |                  |
		| Manager's Phone                 |                  |
		| Want Save Money                 | Yes              |
		| Owner's First Name              | Larry            |
		| Owner's Last Name               | Barry            |
		| Owner's Address                 | 2112 S Spring St |
		| Owner's Address 2               |                  |
		| Owner's Zip Code                | 62704            |
		| Owner's City                    | Springfield      |
		| Owner's State                   | Illinois         |
	Then user verifies the appearance of the Additional Information page
	Then user forces No PP Page
	Then user verifies No PP page