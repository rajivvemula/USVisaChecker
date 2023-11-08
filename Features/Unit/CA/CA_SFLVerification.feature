﻿Feature: CA_SFLVerification



@CA @Unit @SFL
Scenario: Verify Updated Modal Displays on each page
	Given user starts a quote with:
		| Industry          | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Hot Shot Trucking | 2         | I Run My Business From Property I Own | Vehicles     | 46802    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business          | DBA   | Policy Start Date |
		| Save For Later Modal Test | SFLMT |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	Then user verifies the regular save for later modal appears
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1             | Address2 | City       | Select an Address |
		| 2012                  | Corporation             | 515 W Jefferson Blvd |          | Fort Wayne |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	Then user verifies the regular save for later modal appears
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 1M1AE07Y63W014598 | Indiana         | 2800          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	Then user verifies the regular save for later modal appears
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| Donald    | Duck     | IN      | 03/13/1986 | Yes 3 or more years |       |             |             | No       |          |
	Then user clicks continue from the Drivers page
	Then user verifies the regular save for later modal appears
	Then user fills out the Operations page:
		| Question                                                                                                                                              | Answer                   |
		| Do you haul intermodal containers?                                                                                                                    | No                       |
		| Do you have any active Trailer Interchange Agreements?                                                                                                | No                       |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                           | 51 to 100 miles          |
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
		| Enter the USDOT number                                                                                                                                | 3523331                  |
		| Do you have or plan on applying for an operating authority from the Federal Motor Carrier Safety Administration (FMCSA)?                              | Yes                      |
		| Which types of authority from FMCSA do you have or plan on having?                                                                                    | Common Carrier           |
		| Do you travel into Ohio?                                                                                                                              | Yes                      |
		| Does your business require an Ohio OS-32 Special Permit filed?                                                                                        | No                       |
		| Do the owner(s) of this business have a combined majority ownership in any other transportation business?                                             | No                       |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	Then user verifies the regular save for later modal appears
	And user enters contact information:
		| Question                        | Answer           |
		| First Name                      | Ariana           |
		| Last Name                       | Grande           |
		| Business Email                  | a@b.co           |
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
		| Owner's State                   | Illinois         |
	Then user verifies the appearance of the Summary page
	Then user verifies the slim save for later modal appears
