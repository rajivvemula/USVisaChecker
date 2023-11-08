Feature: CA_HotShotTrucking_I
Purpose: Purchase a CA policy in IN with one vehicle and no accidents/incidents.
States: IN, GA, CA
Number of Vehicles: 1
Number of Trailers: 1

@Issued @Regression @IN @CA @Transportation
Scenario: CA Hot Shot Trucking Issued In Indiana
	Given user starts a quote with:
		| Industry          | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Hot Shot Trucking | 2         | I Run My Business From Property I Own | Vehicles     | 46802    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1             | Address2 | City       | Select an Address |
		| 2012                  | Corporation             | 515 W Jefferson Blvd |          | Fort Wayne |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 5TDDK3DCXGS129517 | Indiana         | 10000         |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Trailer Address | Trailer Worth |
		| 1MT2N5220LH028352 | Indiana         | 1000          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| Donald    | Duck     | IN      | 03/13/1986 | Yes 3 or more years |       |             |             | No       |          |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                                                                              | Answer                   |
		| Does your business engage in team driving?                                                                                                            | No - one driver per haul |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                           | 51 to 100 miles          |
		| Does your business have a USDOT Number?                                                                                                               | Yes                      |
		| Enter the USDOT number                                                                                                                                | 2666377                  |
		| Do you have or plan on applying for an operating authority from the Federal Motor Carrier Safety Administration (FMCSA)?                              | Yes                      |
		| Do any of your vehicles travel to Mexico?                                                                                                             | No                       |
		| How many auto insurance claims did your business file in the last 3 years?                                                                            | 0                        |
		| I agree to submit proof of insurance claims history, also known as loss runs, for the last 3 years within 30 days of the effective date of the policy | true                     |
		| Do you haul any of these? Check all that apply:                                                                                                       |                          |
		| Do you haul intermodal containers?                                                                                                                    | No                       |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                       | No                       |
		| Do you provide residential moving services?                                                                                                           | No                       |
		| Do you haul any fine art or jewelry?                                                                                                                  | No                       |
		| Do you haul any hazardous materials?                                                                                                                  | No                       |
		| Do you rent any vehicles?                                                                                                                             | No                       |
		| Do you use any Owner-Operators?                                                                                                                       | No                       |
		| Which types of authority from FMCSA do you have or plan on having?                                                                                    | Common Carrier           |
		| Do you travel into Ohio?                                                                                                                              | Yes                      |
		| Does your business require an Ohio OS-32 Special Permit filed?                                                                                        | No                       |
		| Do the owner(s) of this business have a combined majority ownership in any other transportation business?                                             | No                       |
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
		| Want Save Money                 | Yes              |
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
		| Question           | Answer                                                      |
		| Yearly             | No                                                          |
		| Policy Coverages   | $750,000 Combined Single Limit                              |
		| Vehicle 1 Coverage | $1000 Comprehensive Deductible / $1000 Collision Deductible |
	Then user verifies the coverage details
		| Coverages Not Selected |
		| Rental                 |
	Then user clicks Get Plan from coverage details page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | The Business      |
		| Yes | Owned | The Business      |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Card Type |
		| 12 Monthly   | Visa      |
	Then user clicks purchase
	Then user verifies the Thank You Page
	And user verifies the BOP section on the Thank You page

@HotShotTrucking @Issued @Regression @GA @CA @Transportation
Scenario: CA Hot Shot Trucking Issued In Georgia
	Given user starts a quote with:
		| Industry          | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Hot Shot Trucking | 2         | I Run My Business From Property I Own | Vehicles     | 31093    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1         | Address2 | City          |
		| 2012                  | Corporation             | 1879 Watson Blvd |          | Warner Robins |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 1M1AE07Y63W014598 | Georgia         | 3200          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber  |
		| Donald    | Duck     | GA      | 03/13/1988 | Yes 3 or more years |       |             |             | No       | 453453453 |
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
		| Do you rent any vehicles?                                                                                                                             | No                       |
		| Do you use any Owner-Operators?                                                                                                                       | No                       |
		| Does your business have a USDOT Number?                                                                                                               | No                       |
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
		| Want Save Money                 | Yes                  |
		| Owner's First Name              | ZZZZLarryzz          |
		| Owner's Last Name               | ZZZBarryz            |
		| Owner's Address                 | 2112 S Spring St     |
		| Owner's Address 2               |                      |
		| Owner's Zip Code                | 62704                |
		| Owner's City                    | Springfield          |
		| Owner's State                   | IL                   |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question            | Answer                                                      |
		| Yearly              | No                                                          |
		| Policy Coverages    | $750,000 Combined Single Limit                              |
		| Vehicle 1 Coverage  | $1000 Comprehensive Deductible / $1000 Collision Deductible |
		| Medical Payments    | $500                                                        |
		| Cargo Liability     | $100,000 Limit / $1,000 Deductible                          |
		| Trailer Interchange | $50,000 Limit / $1,000 Deductible                           |
	Then user verifies the coverage details
		| Coverages Not Selected |
		| Rental                 |
	Then user clicks Get Plan from coverage details page
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

@HotShotTrucking @Issued @Regression @Cali @CA @Transportation
Scenario: CA Hot Shot Trucking Issued In California
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
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question                        | Answer                                                      |
		| Yearly                          | No                                                          |
		| Policy Coverages                | $750,000 Combined Single Limit                              |
		| Vehicle 1 Coverage              | $1000 Comprehensive Deductible / $1000 Collision Deductible |
		| Uninsured/Underinsured Motorist | Yes                                                         |
		| Medical Payments                | $500                                                        |
		| Cargo Liability                 | $100,000 Limit / $1,000 Deductible                          |
		| Rental Reimbursement            | $30 per day/30 days/$900 total                              |
		| Trailer Interchange             | $50,000 Limit / $1,000 Deductible                           |
	Then user verifies the coverage details
		| Coverages Not Selected |
	Then user clicks Get Plan from coverage details page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN               | OLF   | Who Holds Vehicle |
		| 1M1AE07Y63W014598 | Owned | The Business      |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Card Type | Autopay            |
		| 12 Monthly   | Visa      | Optional Choose On |
	Then user clicks purchase
	Then user verifies the Thank You Page
	And user verifies the WC section on the Thank You page