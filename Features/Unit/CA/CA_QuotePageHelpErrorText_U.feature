Feature: CA_QuotePageHelpErrorText_U

Testing the Save for Later modal as well as completing a Illinois run and validates the CA Quote Page Help Error Text help on the Quote page

@CA @Unit
Scenario Outline: CA Quote Page Help Error Text Unit
	Given Question <QuestionShouldBeSkipped> skipped
	And user starts a quote with:
		| Industry   | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| <Industry> | 0         | I Lease a Space From Others | Vehicles     | 65781    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business   | DBA | Policy Start Date |
		| TEST CA AUTH QUOTE |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured    | Address1    | Address2 | City    | Select an Address |
		| 2005                  | Individual/Sole Proprietor | 109 Long Dr |          | Willard |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Plowing Snow |
		| 3FRXF7FE0FV662379 | Missouri        | No           |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Plowing Snow |
		| 1M1AW01X4BM052306 | Missouri        | No           |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | Accident | DLNumber   |
		| TEST FN   | TEST LN  | MO      | 04/11/1981 | Yes 3 or more years | No       | B108210006 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer                                                    |
		| Do you haul intermodal containers?                                                          | No                                                        |
		| Do you have any active Trailer Interchange Agreements?                                      | Yes                                                       |
		| Is your business on call 24/7?                                                              | No                                                        |
		| Does your business also have a repair shop, impound lot, or salvage yard?                   | No we only provide towing or roadside assistance services |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 301 to 500 miles                                          |
		| Do you haul any fine art or jewelry?                                                        | No                                                        |
		| Do you provide residential moving services?                                                 | No                                                        |
		| Does your business engage in team driving?                                                  | No - one driver per haul                                  |
		| Do any of your vehicles travel to Mexico?                                                   | No                                                        |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                                                         |
		| Do you haul any of these? Check all that apply:                                             | General Freight                                           |
		| Do you haul large equipment or machinery requiring chains to secure in transit?             | No                                                        |
		| Do you haul any hazardous materials?                                                        | No                                                        |
		| Do you rent any vehicles?                                                                   | No                                                        |
		| Do you use any Owner-Operators?                                                             | No                                                        |
		| Does your business have a USDOT Number?                                                     | No                                                        |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer                  |
		| First Name                      | TEST FN                 |
		| Last Name                       | TEST LN                 |
		| Business Email                  | QAAutomation@biberk.com |
		| Business Phone                  | (657) 478-4378          |
		| Business Website                |                         |
		| Business has an account manager |                         |
		| Want Save Money                 | Yes                     |
		| Owner's First Name              | TEST FN                 |
		| Owner's Last Name               | TEST LN                 |
		| Owner's Address                 | 109 Long Dr             |
		| Owner's Address 2               |                         |
		| Owner's Zip Code                | 65781                   |
		| Owner's City                    | Willard                 |
		| Owner's State                   | MO                      |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	Then user verifies the appearance of the help text on the Quote Page

Examples:
	| Industry                                     | QuestionShouldBeSkipped |
	| Towing Services                              | Should Not Be           |
	| Trucking: Local Hauling: less than 300 miles | Should Be               |