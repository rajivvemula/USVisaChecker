Feature: CA_LimoDriver_I
Purpose: Purchase a CA policy in CA with one vehicle and no accidents/incidents.
State: CA
Number of Vehicles: 1
Number of Trailers: 0

@Issued @Regression @Cali @CA @Transportation
Scenario: CA Limo Driver Issued In California
	Given user starts a quote with:
		| Industry    | Employees | Location                    | Own or Lease                | ZIP Code | LOB |
		| Limo Driver | 0         | I Lease a Space From Others | Vehicles;Tools or Equipment | 93644    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1         | Address2 | City     | Select an Address |
		| 2012                  | Corporation             | 40112 Highway 41 |          | Oakhurst |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address |
		| 1J4AA2D14AL151630 | California      |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| No VIN            | Type Insure                | Year | Make                   | Enter Year Make Model | Trailer Address | Trailer Worth |
		| 16VDX1024L5068821 | Service or Utility Trailer | 2020 | BIG TEX TRAILER CO INC |                       | California      | 2800          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| Donald    | Duck     | CA      | 03/13/1986 |     |       |             |             | No       |          |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                                          | Answer                          |
		| Do you offer "party" bus or limousine services where alcohol is provided or expressly permitted?                  | No                              |
		| Do you provide any school, camp, day care, or field trip transportation for children 12 or younger?               | No                              |
		| How do your passengers access your services?                                                                      | Both on demand and pre-arranged |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                       | 50 miles or less                |
		| Do any of your vehicles travel to Mexico?                                                                         | No                              |
		| How many auto insurance claims did your business file in the last 3 years?                                        | 0                               |
		| Do you rent any vehicles?                                                                                         | No                              |
		| Do you use any Owner-Operators?                                                                                   | No                              |
		| Do you have or plan on applying for an operating authority from the California Public Utilities Commission (PUC)? | Yes                             |
		| Enter your California Carrier ID (TCP, PSG, VCC, or MTR):                                                         | 059785                          |
		| Do the owner(s) of this business have a combined majority ownership in any other transportation business?         | No                              |
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
		| Owner's First Name              | Larry            |
		| Owner's Last Name               | Barry            |
		| Owner's Address                 | 2112 S Spring St |
		| Owner's Address 2               |                  |
		| Owner's Zip Code                | 62704            |
		| Owner's City                    | Springfield      |
		| Owner's State                   | IL               |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question             | Answer                                                    |
		| Yearly               | Yes                                                       |
		| Policy Coverages     | $100,000 Combined Single Limit                            |
		| Vehicle 1 Coverage   | $500 Comprehensive Deductible / $500 Collision Deductible |
		| Medical Payments     | $500                                                      |
		| Rental Reimbursement | $30 per day/30 days/$900 total                            |
	Then user verifies the coverage details
		| Coverages Not Selected |
	Then user clicks Get Plan from coverage details page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN               | OLF      | Who Holds Vehicle |
		| Yes               | Owned    | The Business      |
		| 16VDX1024L5068821 | Financed |                   |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Card Type |
		| 12 Monthly   | Visa      |
	Then user clicks purchase
	Then user verifies the Thank You Page
	And user verifies the WC section on the Thank You page