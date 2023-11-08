Feature: CA_TruckingHaulingUnder300Miles_R
CA Trucking Hauling Under 300 Miles Referred In Missouri

@CA @Regression @Transportation @Referred @MO
Scenario: CA Trucking Hauling Under 300 Miles Referred
	Given user starts a quote with:
		| Industry                                     | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Trucking: Local Hauling: less than 300 miles | 2         | I Lease a Space From Others | Vehicles     | 65802    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business    | DBA | Policy Start Date |
		| Local Hauling Refer |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured     | Address1        | Address2 | City        |
		| 2005                  | Limited Liability Co. (LLC) | 7424 W Flint St |          | Springfield |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Trailer Address | Trailer Worth |
		| 13N14830731017973 | Missouri        | 2000          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber   |
		| TEST FN   | TEST LN  | MO      | 09/03/1989 | No  |       |             |             | No       | D123456789 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer                   |
		| Do you haul intermodal containers?                                                          | No                       |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 51 to 100 miles          |
		| Do you haul any fine art or jewelry?                                                        | No                       |
		| Do you provide residential moving services?                                                 | No                       |
		| Does your business engage in team driving?                                                  | No - one driver per haul |
		| Do any of your vehicles travel to Mexico?                                                   | No                       |
		| How many auto insurance claims did your business file in the last 3 years?                  | 5                        |
		| Do you haul any of these? Check all that apply:                                             |                          |
		| Do you haul large equipment or machinery requiring chains to secure in transit?             | No                       |
		| Do you haul any hazardous materials?                                                        | No                       |
		| Do you rent any vehicles?                                                                   | No                       |
		| Do you use any Owner-Operators?                                                             | No                       |
		| Does your business have a USDOT Number?                                                     | No                       |
	Then user continues to the Contact page
	And user enters contact information:
		| Question                        | Answer                |
		| First Name                      | TEST CFN              |
		| Last Name                       | TEST CLN              |
		| Business Email                  | ydwsaiq6wtn@vddaz.com |
		| Business Phone                  | (123) 555-5678        |
		| Business Website                |                       |
		| Business has an account manager |                       |
		| Want Save Money                 | Yes                   |
		| Owner's First Name              | TEST FN               |
		| Owner's Last Name               | TEST LN               |
		| Owner's Address                 | 7424 W Flint St       |
		| Owner's Address 2               |                       |
		| Owner's Zip Code                | 65802                 |
		| Owner's City                    | Springfield           |
		| Owner's State                   | Missouri              |
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | The Business      |
	Then user clicks continue from Additional Information
	And user verifies the CA refer confirmation appearance