Feature: CA_HotShotTrucking_D

@Transportation @Declined @Regression @Cali @CA
Scenario: CA Hot Shot Trucking Declined Making Policy California
	Given user starts a quote with:
		| Industry          | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Hot Shot Trucking | 2         | I Run My Business From Property I Own | Vehicles     | 95204    | CA  |
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
		| Year Business Started | How Business Structured | Address1             | Address2 | City     | Select an Address |
		| 2012                  | Corporation             | 1687 N California St |          | Stockton |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 1M1AE07Y63W014598 | California      | 2800          |
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
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                           | 50 miles or less                                                           |
		| Do you haul any fine art or jewelry?                                                                                                                  | No                                                                         |
		| Do you provide residential moving services?                                                                                                           | No                                                                         |
		| Does your business engage in team driving?                                                                                                            | No - one driver per haul                                                   |
		| Do any of your vehicles travel to Mexico?                                                                                                             | No                                                                         |
		| How many auto insurance claims did your business file in the last 3 years?                                                                            | 0                                                                          |
		| I agree to submit proof of insurance claims history, also known as loss runs, for the last 3 years within 30 days of the effective date of the policy | true                                                                       |
		| Do you haul any of these? Check all that apply:                                                                                                       | Building Materials;Logs (Forestry);Mobile/Manufactured Homes;Sand & Gravel |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                       | No                                                                         |
		| Do you haul any hazardous materials?                                                                                                                  | Yes                                                                        |
		| Do you haul any anhydrous ammonia or ammonium nitrate?                                                                                                | No                                                                         |
		| Do you haul any poisonous, toxic, or infectious substances?                                                                                           | No                                                                         |
		| Do you haul any radioactive materials?                                                                                                                | No                                                                         |
		| Do you rent any vehicles?                                                                                                            | No                                                                         |
		| Do you use any Owner-Operators?                                                                                                                       | Yes                                                                        |
		| Have you added all Owner-Operator vehicles to this quote?                                                                                             | Yes                                                                        |
		| What is the annual cost for vehicles that you rent, hire, or borrow?                                                                                  | 2800                                                                       |
		| Does your business have a USDOT Number?                                                                                                               | Yes                                                                        |
		| Enter the USDOT number                                                                                                                                | 3523332                                                                    |
		| Do you have or plan on applying for an operating authority from the Federal Motor Carrier Safety Administration (FMCSA)?                              | Yes                                                                        |
		| Which types of authority from FMCSA do you have or plan on having?                                                                                    | Broker;Contract Carrier                                                    |
		| Do you have or plan on applying for an operating authority from the California Department of Motor Vehicles?                                          | Yes                                                                        |
		| Enter your California Motor Carrier #:                                                                                                                | BPYCKN                                                                     |
		| Do the owner(s) of this business have a combined majority ownership in any other transportation business?                                             | No                                                                         |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer           |
		| First Name                      | Larry            |
		| Last Name                       | Barry            |
		| Business Email                  | a@b.com          |
		| Business Phone                  | 5558675309       |
		| Business Website                |                  |
		| Business has an account manager |                  |
		| Owner's First Name              | Larry            |
		| Owner's Last Name               | Barry            |
		| Owner's Address                 | 2112 S Spring St |
		| Owner's Address 2               |                  |
		| Owner's Zip Code                | 62704            |
		| Owner's City                    | Springfield      |
		| Owner's State                   | IL               |
	Then user verifies the appearance of the Decline page

@Transportation @Declined @Regression @IL @CA
Scenario: CA Hot Shot Trucking Declined DOB Under 18
	Given user starts a quote with:
		| Industry          | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Hot Shot Trucking | 2         | I Run My Business From Property I Own | Vehicles     | 60606    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		| Too Young Driver |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1       | Address2 | City    | Select an Address |
		| 2012                  | Corporation             | 225 S Canal St |          | Chicago |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 1M1AE07Y63W014598 | Illinois        | 2800          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber     |
		| Donald    | Duck     | IL      | 04/29/2007 | Yes 3 or more years |       |             |             | No       | T12312312385 |
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
		| Do you rent any vehicles?                                                                                                            | No                       |
		| Do you use any Owner-Operators?                                                                                                                       | Yes                      |
		| Have you added all Owner-Operator vehicles to this quote?                                                                                             | Yes                      |
		| What is the annual cost for vehicles that you rent, hire, or borrow?                                                                                  | 2800                     |
		| Does your business have a USDOT Number?                                                                                                               | No                       |
		| Do you have or plan on applying for an operating authority from the Illinois Commerce Commission?                                                     | No                       |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer           |
		| First Name                      | Larryzzzz        |
		| Last Name                       | Barryzzzz        |
		| Business Email                  | a@b.com          |
		| Business Phone                  | 5558675309       |
		| Business Website                |                  |
		| Business has an account manager |                  |
		| Owner's First Name              | Larry            |
		| Owner's Last Name               | Barry            |
		| Owner's Address                 | 2112 S Spring St |
		| Owner's Address 2               |                  |
		| Owner's Zip Code                | 62704            |
		| Owner's City                    | Springfield      |
		| Owner's State                   | IL               |
	Then user verifies the appearance of the Decline page

@Transportation @Declined @Regression @Cali @CA
Scenario: CA Hot Shot Trucking Declined Making Policy California Due To Answering No To Owner Operator Vehicles and Yes To FMCSA
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
		| Year Business Started | How Business Structured | Address1             | Address2 | City     | Select an Address |
		| 2012                  | Corporation             | 1687 N California St |          | Stockton |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 1M1AE07Y63W014598 | California      | 2800          |
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
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                           | 50 miles or less                                                           |
		| Do you haul any fine art or jewelry?                                                                                                                  | No                                                                         |
		| Do you provide residential moving services?                                                                                                           | No                                                                         |
		| Does your business engage in team driving?                                                                                                            | No - one driver per haul                                                   |
		| Do any of your vehicles travel to Mexico?                                                                                                             | No                                                                         |
		| How many auto insurance claims did your business file in the last 3 years?                                                                            | 0                                                                          |
		| I agree to submit proof of insurance claims history, also known as loss runs, for the last 3 years within 30 days of the effective date of the policy | true                                                                       |
		| Do you haul any of these? Check all that apply:                                                                                                       | Building Materials;Logs (Forestry);Mobile/Manufactured Homes;Sand & Gravel |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                       | No                                                                         |
		| Do you haul any hazardous materials?                                                                                                                  | Yes                                                                        |
		| Do you haul any anhydrous ammonia or ammonium nitrate?                                                                                                | No                                                                         |
		| Do you haul any poisonous, toxic, or infectious substances?                                                                                           | No                                                                         |
		| Do you haul any radioactive materials?                                                                                                                | No                                                                         |
		| Do you rent any vehicles?                                                                                                            | No                                                                         |
		| Do you use any Owner-Operators?                                                                                                                       | Yes                                                                        |
		| Have you added all Owner-Operator vehicles to this quote?                                                                                             | No                                                                         |
		| Does your business have a USDOT Number?                                                                                                               | Yes                                                                        |
		| Enter the USDOT number                                                                                                                                | 3523332                                                                    |
		| Do you have or plan on applying for an operating authority from the Federal Motor Carrier Safety Administration (FMCSA)?                              | Yes                                                                        |
		| Which types of authority from FMCSA do you have or plan on having?                                                                                    | Broker;Contract Carrier                                                    |
		| Do you have or plan on applying for an operating authority from the California Department of Motor Vehicles?                                          | Yes                                                                        |
		| Enter your California Motor Carrier #:                                                                                                                | BPYCKN                                                                     |
		| Do the owner(s) of this business have a combined majority ownership in any other transportation business?                                             | No                                                                         |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer           |
		| First Name                      | Larry            |
		| Last Name                       | Barry            |
		| Business Email                  | a@b.com          |
		| Business Phone                  | 5558675309       |
		| Business Website                |                  |
		| Business has an account manager |                  |
		| Want Save Money                 | Yes              |
		| Owner's First Name              | Larry            |
		| Owner's Last Name               | Barry            |
		| Owner's Address                 | 2112 S Spring St |
		| Owner's Address 2               |                  |
		| Owner's Zip Code                | 62704            |
		| Owner's City                    | Springfield      |
		| Owner's State                   | IL               |
	Then user verifies the appearance of the Decline page