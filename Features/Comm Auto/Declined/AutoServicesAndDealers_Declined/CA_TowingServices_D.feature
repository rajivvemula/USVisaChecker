Feature: CA_TowingServices_D

US 79738 - Added new CA questions

@Declined @CA @Regression @SC
Scenario: CA Towing Service Declined Snow Plowing
	Given user starts a quote with:
		| Industry        | Employees | Location                    | Own or Lease                | ZIP Code | LOB |
		| Towing Services | 0         | I Lease a Space From Others | Vehicles;Tools or Equipment | 29209    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		| test             | No  |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1         | Address2 | City     | Select an Address |
		| 2012                  | Corporation             | 806 Universal Dr |          | Columbia |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Fifth Wheel | Plowing Snow |
		| 1FTFW1E88NFA58133 | South Carolina  | No          | Yes          |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Fifth Wheel | Plowing Snow |
		| 3TMCZ5AN3KM237222 | South Carolina  | Yes         | Yes          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | Accident | DLNumber  |
		| Test      | Driver   | SC      | 03/13/1986 | Yes 3 or more years | No       | 085671243 |
	Then user continues to the Operations page
	Then user fills out the Operations page:
		| Question                                                                                                                                              | Answer                                                    |
		| Do you haul intermodal containers?                                                                                                                    | No                                                        |
		| Do you have any active Trailer Interchange Agreements?                                                                                                | No                                                        |
		| Is your business on call 24/7?                                                                                                                        | No                                                        |
		| Does your business also have a repair shop, impound lot, or salvage yard?                                                                             | No we only provide towing or roadside assistance services |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                           | 50 miles or less                                          |
		| Do you haul any fine art or jewelry?                                                                                                                  | No                                                        |
		| Do you provide residential moving services?                                                                                                           | No                                                        |
		| Does your business engage in team driving?                                                                                                            | No - one driver per haul                                  |
		| Do any of your vehicles travel to Mexico?                                                                                                             | No                                                        |
		| How many auto insurance claims did your business file in the last 3 years?                                                                            | 0                                                         |
		| I agree to submit proof of insurance claims history, also known as loss runs, for the last 3 years within 30 days of the effective date of the policy | true                                                      |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                       | No                                                        |
		| Do you haul any hazardous materials?                                                                                                                  | No                                                        |
		| Do you rent any vehicles?                                                                                                            | No                                                        |
		| Do you use any Owner-Operators?                                                                                                                       | No                                                        |
		| Does your business have a USDOT Number?                                                                                                               | No                                                        |
		| Do you have or plan on applying for an operating authority from a South Carolina state department?                                                    | Yes                                                       |
		| Do the owner(s) of this business have a combined majority ownership in any other transportation business?                                             | No                                                        |
	Then user continues to the Contact page
	And user enters contact information:
		| Question                        | Answer           |
		| First Name                      | Test             |
		| Last Name                       | Driver           |
		| Business Email                  | abc@321.com      |
		| Business Phone                  | (555) 867-5309   |
		| Business Website                |                  |
		| Business has an account manager |                  |
		| Want Save Money                 | Yes              |
		| Owner's First Name              | Test             |
		| Owner's Last Name               | Owner            |
		| Owner's Address                 | 806 Universal Dr |
		| Owner's Address 2               |                  |
		| Owner's Zip Code                | 29209            |
		| Owner's City                    | Columbia         |
		| Owner's State                   | SC               |
	Then user verifies the appearance of the Decline page
	
@Declined @CA @Regression @SC
Scenario: CA Towing Services Declined Garage Keeper’s Liability
	Given user starts a quote with:
		| Industry        | Employees | Location                    | Own or Lease                | ZIP Code | LOB |
		| Towing Services | 0         | I Lease a Space From Others | Vehicles;Tools or Equipment | 29209    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA | Policy Start Date |
		| test             | No  |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1         | Address2 | City     | Select an Address |
		| 2012                  | Corporation             | 806 Universal Dr |          | Columbia |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Fifth Wheel | Plowing Snow |
		| 1FTFW1E88NFA58133 | South Carolina  | No          | No           |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | Accident | DLNumber  |
		| Test      | Driver   | SC      | 03/13/1986 | Yes 3 or more years | No       | 085671243 |
	Then user continues to the Operations page
	Then user fills out the Operations page:
		| Question                                                                                                                                                                                                                                                                                                      | Answer                                                  |
		| Do you haul intermodal containers?                                                                                                                                                                                                                                                                            | No                                                      |
		| Is your business on call 24/7?                                                                                                                                                                                                                                                                                | No                                                      |
		| Does your business also have a repair shop, impound lot, or salvage yard?                                                                                                                                                                                                                                     | Yes we have a repair shop, impound lot, or salvage yard |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                                                                                                                                                                                   | 50 miles or less                                        |
		| Do you haul any fine art or jewelry?                                                                                                                                                                                                                                                                          | No                                                      |
		| Do you provide residential moving services?                                                                                                                                                                                                                                                                   | No                                                      |
		| Does your business engage in team driving?                                                                                                                                                                                                                                                                    | No - one driver per haul                                |
		| Do any of your vehicles travel to Mexico?                                                                                                                                                                                                                                                                     | No                                                      |
		| How many auto insurance claims did your business file in the last 3 years?                                                                                                                                                                                                                                    | 0                                                       |
		| I agree to submit proof of insurance claims history, also known as loss runs, for the last 3 years within 30 days of the effective date of the policy                                                                                                                                                         | true                                                    |
		| This policy is only for vehicles you own or lease for business purposes and also add to the policy.  It does not cover vehicles on your business premises that you are repairing, servicing, or have in an impound, or salvage yard.   Separate coverage known as garagekeeper's liability must be purchased. | I do not agree                                          |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                                                                                                                                                                               | No                                                      |
		| Do you haul any hazardous materials?                                                                                                                                                                                                                                                                          | No                                                      |
		| Do you rent any vehicles?                                                                                                                                                                                                                                                                    | No                                                      |
		| Do you use any Owner-Operators?                                                                                                                                                                                                                                                                               | No                                                      |
		| Does your business have a USDOT Number?                                                                                                                                                                                                                                                                       | No                                                      |
		| Do you have or plan on applying for an operating authority from a South Carolina state department?                                                                                                                                                                                                            | Yes                                                     |
		| Do the owner(s) of this business have a combined majority ownership in any other transportation business?                                                                                                                                                                                                     | No                                                      |
	Then user continues to the Contact page
	And user enters contact information:
		| Question                        | Answer           |
		| First Name                      | Test             |
		| Last Name                       | Driver           |
		| Business Email                  | abc@3212.com     |
		| Business Phone                  | (555) 867-5209   |
		| Business Website                |                  |
		| Business has an account manager |                  |
		| Want Save Money                 | Yes              |
		| Owner's First Name              | Test             |
		| Owner's Last Name               | Owner            |
		| Owner's Address                 | 806 Universal Dr |
		| Owner's Address 2               |                  |
		| Owner's Zip Code                | 29209            |
		| Owner's City                    | Columbia         |
		| Owner's State                   | SC               |
	Then user verifies the appearance of the Decline page

@Declined @CA @Regression @SC
Scenario: CA Towing Services Declined Loss Coverage Jewelry
	Given user starts a quote with:
		| Industry        | Employees | Location                    | Own or Lease                | ZIP Code | LOB |
		| Towing Services | 0         | I Lease a Space From Others | Vehicles;Tools or Equipment | 29209    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA | Policy Start Date |
		| test             | No  |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1         | Address2 | City     | Select an Address |
		| 2012                  | Corporation             | 806 Universal Dr |          | Columbia |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Fifth Wheel | Plowing Snow |
		| 1FTFW1E88NFA58133 | South Carolina  | No          | No           |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | Accident | DLNumber  |
		| Test      | Driver   | SC      | 03/13/1986 | Yes 3 or more years | No       | 085671243 |
	Then user continues to the Operations page
	Then user fills out the Operations page:
		| Question                                                                                                                                              | Answer                                                    |
		| Do you haul intermodal containers?                                                                                                                    | No                                                        |
		| Is your business on call 24/7?                                                                                                                        | No                                                        |
		| Does your business also have a repair shop, impound lot, or salvage yard?                                                                             | No we only provide towing or roadside assistance services |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                           | 50 miles or less                                          |
		| Do you haul any fine art or jewelry?                                                                                                                  | Yes                                                       |
		| Do you provide residential moving services?                                                                                                           | No                                                        |
		| Does your business engage in team driving?                                                                                                            | No - one driver per haul                                  |
		| Do any of your vehicles travel to Mexico?                                                                                                             | No                                                        |
		| How many auto insurance claims did your business file in the last 3 years?                                                                            | 0                                                         |
		| I agree to submit proof of insurance claims history, also known as loss runs, for the last 3 years within 30 days of the effective date of the policy | true                                                      |
		| If you choose to purchase the optional Cargo Coverage then claims for damage or loss regarding fine art or jewelry will not be covered.               | I do not agree                                            |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                       | No                                                        |
		| Do you haul any hazardous materials?                                                                                                                  | No                                                        |
		| Do you rent any vehicles?                                                                                                            | No                                                        |
		| Do you use any Owner-Operators?                                                                                                                       | No                                                        |
		| Does your business have a USDOT Number?                                                                                                               | No                                                        |
		| Do you have or plan on applying for an operating authority from a South Carolina state department?                                                    | Yes                                                       |
		| Do the owner(s) of this business have a combined majority ownership in any other transportation business?                                             | No                                                        |
	Then user continues to the Contact page
	And user enters contact information:
		| Question                        | Answer           |
		| First Name                      | Test             |
		| Last Name                       | Driver           |
		| Business Email                  | abc@3212.com     |
		| Business Phone                  | (555) 867-5209   |
		| Business Website                |                  |
		| Business has an account manager |                  |
		| Want Save Money                 | Yes              |
		| Owner's First Name              | Test             |
		| Owner's Last Name               | Owner            |
		| Owner's Address                 | 806 Universal Dr |
		| Owner's Address 2               |                  |
		| Owner's Zip Code                | 29209            |
		| Owner's City                    | Columbia         |
		| Owner's State                   | SC               |
	Then user verifies the appearance of the Decline page