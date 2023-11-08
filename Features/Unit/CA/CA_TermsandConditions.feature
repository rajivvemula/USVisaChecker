Feature: CA_TermsandConditions

Verify the Terms and Conditions window

@Unit @Cali @CA @Construction
Scenario: CA verify the terms and conditions window
	Given user starts a quote with:
		| Industry            | Employees | Location                              | Own or Lease                | ZIP Code | LOB |
		| Roadside Assistance | 2         | I Run My Business From Property I Own | Vehicles;Inventory or Stock | 75662    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1             | Address2 | City    | Select an Address |
		| 2012                  | Corporation             | 906 US Highway 259 N |          | Kilgore |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth | Plowing Snow |
		| 1M1AE07Y63W014598 | Texas           | 2800          | No           |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| Mickey    | Mouse    | TX      | 03/13/1985 | Yes 3 or more years |       |             |             | No       | 12345678 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                                                                                                                                                                                                                                      | Answer                                                  |
		| Do you haul intermodal containers?                                                                                                                                                                                                                                                                            | No                                                      |
		| Do you have any active Trailer Interchange Agreements?                                                                                                                                                                                                                                                        | No                                                      |
		| Is your business on call 24/7?                                                                                                                                                                                                                                                                                | No                                                      |
		| Does your business also have a repair shop, impound lot, or salvage yard?                                                                                                                                                                                                                                     | Yes we have a repair shop, impound lot, or salvage yard |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                                                                                                                                                                                   | 50 miles or less                                        |
		| Do you haul any fine art or jewelry?                                                                                                                                                                                                                                                                          | No                                                      |
		| Do you provide residential moving services?                                                                                                                                                                                                                                                                   | No                                                      |
		| Does your business engage in team driving?                                                                                                                                                                                                                                                                    | No - one driver per haul                                |
		| Do any of your vehicles travel to Mexico?                                                                                                                                                                                                                                                                     | No                                                      |
		| This policy is only for vehicles you own or lease for business purposes and also add to the policy.  It does not cover vehicles on your business premises that you are repairing, servicing, or have in an impound, or salvage yard.   Separate coverage known as garagekeeper's liability must be purchased. | I understand                                            |
		| How many auto insurance claims did your business file in the last 3 years?                                                                                                                                                                                                                                    | 0                                                       |
		| I agree to provide a claims history (also known as a "loss run") that matches the information in this application for the last 3 years within 30 days of {effective date}.                                                                                                                                    | true                                                    |
		| Do you haul any of these? Check all that apply:                                                                                                                                                                                                                                                               | Motor Vehicles (Cars)                                   |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                                                                                                                                                                               | No                                                      |
		| Do you haul any hazardous materials?                                                                                                                                                                                                                                                                          | No                                                      |
		| Do you rent any vehicles?                                                                                                                                                                                                                                                                                     | No                                                      |
		| Do you use any Owner-Operators?                                                                                                                                                                                                                                                                               | No                                                      |
		| Does your business have a USDOT Number?                                                                                                                                                                                                                                                                       | No                                                      |
		| Do you have or plan on applying for an operating authority from the Texas Department of Motor Vehicles?                                                                                                                                                                                                       | No                                                      |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer                 |
		| First Name                      | Ariana                 |
		| Last Name                       | Grande                 |
		| Business Email                  | chauffeur@yopmail.com  |
		| Business Phone                  | (555) 867-5309         |
		| Business Website                |                        |
		| Business has an account manager |                        |
		| Owner's First Name              | AutoLarryzzzzzzzzzzz   |
		| Owner's Last Name               | AutoBarryzzzzzzzzzzzzz |
		| Owner's Address                 | 1879 Watson Blvd Apt 1 |
		| Owner's Address 2               |                        |
		| Owner's Zip Code                | 31093                  |
		| Owner's City                    | warner robins          |
		| Owner's State                   | Georgia                |
		| Select an Address               | Suggested              |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question           | Answer                                                      |
		| Yearly             | No                                                          |
		| Policy Coverages   | $750,000 Combined Single Limit                              |
		| Vehicle 1 Coverage | $1000 Comprehensive Deductible / $1000 Collision Deductible |
	Then user clicks continue from the Quote page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | The Business      |
	Then user clicks continue from Additional Information
	Then user verifies the Terms and Conditions window