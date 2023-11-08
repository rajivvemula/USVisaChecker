Feature: CA_AutomobileDriveawayService_I

Issuing a Automobile Driveway Service (Originally added to verify the Phone Extension changes)

@Regression @Issued @Transportation @CA @AZ
Scenario: CA Automobile Driveway Service Issued In Arizona
	Given user starts a quote with:
		| Industry                     | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Automobile Driveaway Service | 3         | I Own a Property & Lease to Others | Vehicles     | 86506    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1          | Address2 | City  | Select an Address |
		| 2020                  | Corporation             | 147 S Frontage Rd | B        | Houck | Original          |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address |
		| ZHWUS4ZF6KLA11669 | Arizona         |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | Accident | DLNumber  |
		| Speed     | Racer    | AZ      | 09/23/1967 | Yes 3 or more years | No       | S14265987 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                                                                              | Answer                   |
		| Do you haul intermodal containers?                                                                                                                    | No                       |
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
		| Does your business have a USDOT Number?                                                                                                               | No                       |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer             |
		| First Name                      | Speed              |
		| Last Name                       | Racer              |
		| Business has an account manager | Yes                |
		| Business Email                  | Speed@Racer.com    |
		| Business Phone                  | (555) 777-5309     |
		| Business Ext                    | 7777               |
		| Business Website                | SpeedRacer.com     |
		| Manager's First Name            | Chim               |
		| Manager's Last Name             | Chim               |
		| Manager's Email                 | ChimChim@Racer.com |
		| Manager's Phone                 | (555) 777-7412     |
		| Manager's Ext                   | 3071               |
		| Want Save Money                 | Yes                |
		| Owner's First Name              | Pops               |
		| Owner's Last Name               | Racer              |
		| Owner's Address                 | 147 S Frontage Rd  |
		| Owner's Address 2               | B                  |
		| Owner's Zip Code                | 86506              |
		| Owner's City                    | Houck              |
		| Owner's State                   | Arizona            |
		| Select an Address               | Original           |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	And user completes their Quote
		| Question           | Answer                                                      |
		| Yearly             | No                                                          |
		| Policy Coverages   | $100,000 Combined Single Limit                              |
		| Vehicle 1 Coverage | $1000 Comprehensive Deductible / $1000 Collision Deductible |
	Then user clicks continue from the Quote page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | The Business      |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Card Type |
		| 12 Monthly   | Visa      |
	Then user clicks purchase
	Then user verifies the Thank You Page
	And user verifies the WC section on the Thank You page