Feature: CA_MovingCompany_I
Purpose: Verify question "What services do you provide?" appears and is functional as well as "Do you haul any of these? Check all that apply: " pops up after 

@Issued @FL @Transportation @CA @Regression @YourServices
Scenario: CA Moving Company Issued In Florida
	Given user starts a quote with:
		| Industry       | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Moving Company | 2         | I Run My Business From Property I Own | Vehicles     | 33065    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1              | Address2 | City          | Select an Address |
		| 2019                  | Corporation             | 11048 Royal Palm Blvd |          | Coral Springs |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 3A8FY48B48T179053 | Florida         | 5000          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber      |
		| Samus     | Zero     | FL      | 01/01/1988 | Yes 3 or more years |       |             |             | No       | C101010101010 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                                                                                                   | Answer                                                            |
		| Do you haul intermodal containers?                                                                                                                                         | No                                                                |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                                                | 50 miles or less                                                  |
		| Do you haul any fine art or jewelry?                                                                                                                                       | No                                                                |
		| Do you provide residential moving services?                                                                                                                                | Yes                                                               |
		| Does your business engage in team driving?                                                                                                                                 | No - one driver per haul                                          |
		| Do any of your vehicles travel to Mexico?                                                                                                                                  | No                                                                |
		| How many auto insurance claims did your business file in the last 3 years?                                                                                                 | 0                                                                 |
		| What services do you provide?                                                                                                                                              | Moving Services and other Delivery/Trucking services are provided |
		| Do you haul any of these? Check all that apply:                                                                                                                            | Livestock                                                         |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                                            | No                                                                |
		| Do you haul any hazardous materials?                                                                                                                                       | No                                                                |
		| Do you rent any vehicles?                                                                                                                                                  | No                                                                |
		| Do you use any Owner-Operators?                                                                                                                                            | No                                                                |
		| Does your business have a USDOT Number?                                                                                                                                    | No                                                                |
		| I agree to provide a claims history (also known as a "loss run") that matches the information in this application for the last 3 years within 30 days of {effective date}. | true                                                              |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer                |
		| First Name                      | Mona                  |
		| Last Name                       | Leo                   |
		| Business Email                  | test@test.com         |
		| Business Phone                  | (777) 777-7777        |
		| Business Website                |                       |
		| Business has an account manager |                       |
		| Want Save Money                 | Yes                   |
		| Owner's First Name              | Flo                   |
		| Owner's Last Name               | Mili                  |
		| Owner's Address                 | 11048 Royal Palm Blvd |
		| Owner's Address 2               |                       |
		| Owner's Zip Code                | 33065                 |
		| Owner's City                    | Coral Springs         |
		| Owner's State                   | FL                    |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question           | Answer                                                      |
		| Yearly             | No                                                          |
		| Policy Coverages   | $300,000 Combined Single Limit                              |
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