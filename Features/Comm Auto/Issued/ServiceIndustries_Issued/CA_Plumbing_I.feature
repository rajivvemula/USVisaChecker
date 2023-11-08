Feature: CA_Plumbing_I
Purpose: Purchase a CA policy in IL with two vehicles and no accidents/incidents.
State: IL
Number of Vehicles: 2
Number of Trailers: 0

@Issued @Regression @IL @CA @Service
Scenario: CA Plumbing Issued In Illinois
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
		| 5TDDK3DCXGS129517 | South Carolina  | 10000         |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Trailer Address | Trailer Worth |
		| 1MT2N5220LH028352 | South Carolina  | 1000          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber  |
		| Aubrey    | Plaza    | SC      | 03/13/1985 | Yes 3 or more years |       |             |             | No       | 098657477 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                                                                                                   | Answer                      |
		| Do you haul intermodal containers?                                                                                                                                         | No                          |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                                                | 50 miles or less            |
		| Do you haul any fine art or jewelry?                                                                                                                                       | No                          |
		| Do you provide residential moving services?                                                                                                                                | No                          |
		| Does your business engage in team driving?                                                                                                                                 | Yes we do some team driving |
		| Do any of your vehicles travel to Mexico?                                                                                                                                  | No                          |
		| How many auto insurance claims did your business file in the last 3 years?                                                                                                 | 0                           |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                                            | No                          |
		| Do you haul any hazardous materials?                                                                                                                                       | No                          |
		| Do you rent any vehicles?                                                                                                                                                  | No                          |
		| Do you use any Owner-Operators?                                                                                                                                            | No                          |
		| Does your business have a USDOT Number?                                                                                                                                    | No                          |
		| I agree to provide a claims history (also known as a "loss run") that matches the information in this application for the last 3 years within 30 days of {effective date}. | true                        |
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
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question             | Answer                                                      |
		| Yearly               |                                                             |
		| Policy Coverages     | $300,000 Combined Single Limit                              |
		| Vehicle 1 Coverage   |                                                             |
		| Vehicle 2 Coverage   | $2500 Comprehensive Deductible / $2500 Collision Deductible |
		| Vehicle 3 Coverage   |                                                             |
		| Medical Payments     | $2,000                                                      |
		| Cargo Liability      | $250,000 Limit / $500 Deductible                            |
		| Trailer Interchange  |                                                             |
		| Rental Reimbursement | $50 per day/30 days/$1500 total                             |
	Then user clicks continue from the Quote page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | Someone else      |
		| Yes | Owned | Someone else      |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Card Type |
		| 12 Monthly   | Visa      |
	Then user clicks purchase
	Then user verifies the Thank You Page