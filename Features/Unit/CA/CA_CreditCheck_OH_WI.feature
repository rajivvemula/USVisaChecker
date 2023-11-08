Feature: CA_CreditCheck_OH_WI
Performs a Soft Credit check for the state of Ohio. When clicking yes on the soft credit check, the owner information should already be pre-filled for the state of OH. 
This also applies to wisconson as well

@CA @Unit @OH
Scenario: CA Prefilled Contact page owner's address for state of Ohio
	Given user starts a quote with:
		| Industry          | Employees | Location                         | Own or Lease | ZIP Code | LOB |
		| Hot Shot Trucking |           | I Run My Business Out Of My Home | Vehicles     | 45011    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		| Teddy Treebark   |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured    | Address1       | Address2 | City      | Select an Address |
		| 2012                  | Individual/Sole Proprietor | 7373 Nickey Ct |          | Fairfield |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 1M1AE07Y63W014598 | Ohio            | 2800          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| Donald    | Duck     | OH      | 03/13/1986 | Yes 3 or more years |       |             |             | No       |          |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                                                                              | Answer                          |
		| Does your business engage in team driving?                                                                                                            | No - one driver per haul        |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                           | 51 to 100 miles                 |
		| Does your business have a USDOT Number?                                                                                                               | Yes                             |
		| Enter the USDOT number                                                                                                                                | 2666377                         |
		| Do you have or plan on applying for an operating authority from the Federal Motor Carrier Safety Administration (FMCSA)?                              | Yes                             |
		| Which types of authority from FMCSA do you have or plan on having?                                                                                    | Contract Carrier;Common Carrier |
		| Do the owner(s) of this business have a combined majority ownership in any other transportation business?                                             | No                              |
		| Do you haul any fine art or jewelry?                                                                                                                  | No                              |
		| Do you haul any of these? Check all that apply:                                                                                                       |                                 |
		| Do you haul intermodal containers?                                                                                                                    | No                              |
		| Do you haul large equipment or machinery?                                                                                                             | No                              |
		| Do you provide residential moving services?                                                                                                           | No                              |
		| Do you haul any hazardous materials?                                                                                                                  | No                              |
		| Do you have any active Trailer Interchange Agreements?                                                                                                | No                              |
		| Do any of your vehicles travel to Mexico?                                                                                                             | No                              |
		| How many auto insurance claims did your business file in the last 3 years?                                                                            | 0                               |
		| I agree to submit proof of insurance claims history, also known as loss runs, for the last 3 years within 30 days of the effective date of the policy | true                            |
		| Do you rent any vehicles?                                                                                                                             | No                              |
		| Do you use any Owner-Operators?                                                                                                                       | No                              |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question         | Answer         |
		| First Name       | Ariana         |
		| Last Name        | Grande         |
		| Business Email   | a@b.co         |
		| Business Phone   | (555) 867-5309 |
		| Business Website |                |
		| Want Save Money  | Yes            |
	Then user verifies whether the Owner's name is prefilled
	Then user verifies the owner's address prefilled