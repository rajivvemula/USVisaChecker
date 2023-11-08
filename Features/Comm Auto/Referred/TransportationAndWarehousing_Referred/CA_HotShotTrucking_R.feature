Feature: CA_HotShotTrucking_R
CA Hot Shot Trucking Referred In Texas

@CA @Regression @Transportation @Referred @TX
Scenario: CA Hot Shot Trucking Referred
	Given user starts a quote with:
		| Industry          | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Hot Shot Trucking | 2         | I Lease a Space From Others | Vehicles     | 77356    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business  | DBA | Policy Start Date |
		| Hot Shot Trucking |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1              | Address2 | City       |
		| 2002                  | Corporation             | 16857 Falcon Sound Dr |          | Montgomery |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 1XKDDB9X2SR644295 | Texas           | 25000         |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| Mike      | Jackson  | TX      | 09/03/1989 | Yes 3 or more years |       |             |             | No       | 17613485 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                                                                              | Answer                   |
		| Do you haul intermodal containers?                                                                                                                    | No                       |
		| Do you have any active Trailer Interchange Agreements?                                                                                                | No                       |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                           | 50 miles or less         |
		| Do you haul any fine art or jewelry?                                                                                                                  | No                       |
		| Do you provide residential moving services?                                                                                                           | No                       |
		| Does your business engage in team driving?                                                                                                            | No - one driver per haul |
		| Do any of your vehicles travel to Mexico?                                                                                                             | No                       |
		| How many auto insurance claims did your business file in the last 3 years?                                                                            | 0                        |
		| I agree to submit proof of insurance claims history, also known as loss runs, for the last 3 years within 30 days of the effective date of the policy | true                     |
		| Do you haul any of these? Check all that apply:                                                                                                       |                          |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                       | No                       |
		| Do you haul any hazardous materials?                                                                                                                  | No                       |
		| Do you rent any vehicles?                                                                                                                             | No                       |
		| Do you use any Owner-Operators?                                                                                                                       | No                       |
		| Does your business have a USDOT Number?                                                                                                               | Yes                      |
		| Enter the USDOT number                                                                                                                                | 355352                   |
		| Do you have or plan on applying for an operating authority from the Federal Motor Carrier Safety Administration (FMCSA)?                              | No                       |
		| Do you have or plan on applying for an operating authority from the Texas Department of Motor Vehicles?                                               | No                       |
	Then user continues to the Contact page
	And user enters contact information:
		| Question                        | Answer              |
		| First Name                      | Mike                |
		| Last Name                       | Jackson             |
		| Business Email                  | wvhdhpghd@oosln.com |
		| Business Phone                  | (248) 564-1978      |
		| Business Website                |                     |
		| Business has an account manager |                     |
		| Want Save Money                 | Yes                 |
		| Owner's First Name              | TEST FN             |
		| Owner's Last Name               | TEST LN             |
		| Owner's Address                 | 100 Main St         |
		| Owner's Address 2               |                     |
		| Owner's Zip Code                | 60185               |
		| Owner's City                    | West Chicago        |
		| Owner's State                   | Illinois            |
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | The Business      |
	Then user clicks continue from Additional Information
	And user verifies the CA refer confirmation appearance