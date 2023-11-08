Feature: CA_SaveYourProgress_U

Verifying CA Save Your Progresss is pre-populated with info entered by the user

@Unit @Cali @CA @Transportation
Scenario: CA Save Your Progress is pre-populated with info
	Given user starts a quote with:
		| Industry          | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Hot Shot Trucking | 2         | I Run My Business From Property I Own | Vehicles     | 95204    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1             | Address2 | City     |
		| 2012                  | Corporation             | 1687 N California St |          | Stockton |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| No VIN            | Type Insure   | Year | Make | Enter Year Make Model | Model | Parking Address | Vehicle Worth |
		| 1M1AE07Y63W014598 | Truck Tractor | 2003 | MACK |                       | 600   | California      | 7800          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| Donald    | Duck     | CA      | 03/13/1988 | Yes 3 or more years |       |             |             | No       |          |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                                                                              | Answer                                                                     |
		| Do you haul intermodal containers?                                                                                                                    | No                                                                         |
		| Do you have any active Trailer Interchange Agreements?                                                                                                | No                                                                         |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                           | 101 to 300 miles                                                           |
		| Do you haul any fine art or jewelry?                                                                                                                  | No                                                                         |
		| Do you provide residential moving services?                                                                                                           | No                                                                         |
		| Does your business engage in team driving?                                                                                                            | No - one driver per haul                                                   |
		| Do any of your vehicles travel to Mexico?                                                                                                             | No                                                                         |
		| How many auto insurance claims did your business file in the last 3 years?                                                                            | 0                                                                          |
		| I agree to submit proof of insurance claims history, also known as loss runs, for the last 3 years within 30 days of the effective date of the policy | true                                                                       |
		| Do you haul any of these? Check all that apply:                                                                                                       | Building Materials;Logs (Forestry);Mobile/Manufactured Homes;Sand & Gravel |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                       | No                                                                         |
		| Do you haul any hazardous materials?                                                                                                                  | No                                                                         |
		| Do you rent any vehicles?                                                                                                                             | No                                                                         |
		| Do you use any Owner-Operators?                                                                                                                       | Yes                                                                        |
		| Have you added all Owner-Operator vehicles to this quote?                                                                                             | Yes                                                                        |
		| What is the annual cost for vehicles that you rent, hire, or borrow?                                                                                  | 2800                                                                       |
		| Does your business have a USDOT Number?                                                                                                               | Yes                                                                        |
		| Enter the USDOT number                                                                                                                                | 2676783                                                                    |
		| Do you have or plan on applying for an operating authority from the Federal Motor Carrier Safety Administration (FMCSA)?                              | Yes                                                                        |
		| Which types of authority from FMCSA do you have or plan on having?                                                                                    | Contract Carrier;Common Carrier                                            |
		| Do you have or plan on applying for an operating authority from the California Department of Motor Vehicles?                                          | Yes                                                                        |
		| Enter your California Motor Carrier #:                                                                                                                | BPYCKN                                                                     |
		| Do the owner(s) of this business have a combined majority ownership in any other transportation business?                                             | No                                                                         |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer               |
		| First Name                      | ZZZZZLarryzzz        |
		| Last Name                       | ZZZZBarryzz          |
		| Business Email                  | larryzbarryzzz@b.com |
		| Business Phone                  | (555) 867-5309       |
		| Business Website                |                      |
		| Business has an account manager |                      |
		| Owner's First Name              | ZZZZLarryzz          |
		| Owner's Last Name               | ZZZBarryz            |
		| Owner's Address                 | 2112 S Spring St     |
		| Owner's Address 2               |                      |
		| Owner's Zip Code                | 62704                |
		| Owner's City                    | Springfield          |
		| Owner's State                   | IL                   |
	Then user verifies the appearance of the Summary page
	Then user verifies Save Your Progresss is pre-populated with info entered by the user