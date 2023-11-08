Feature: CA_FMCSAQuestionDefault_U

Verifying that the "Do you have or plan on applying for an operating authority from the Federal Motor Carrier Safety Administration (FMCSA)?" question has the yes answer set by default if either of the following statements is true:
    a.Auto Industry equals 'For-Hire Trucking' AND
    b.GVW of any vehicle (non-trailer) is 10,001 lbs OR more or there is at least one Truck Tractor body Subcategory AND 
    c.radius is either 301 to 500 miles or 501 miles OR more or "Do you participate in a delivery service on behalf of Amazon.com, Inc.?" = Yes

@CA @Unit
Scenario: CA FMCSA Question Default with furthest any vehicle travels is between 301 to 500 miles
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
		| FirstName | LastName | DLState | DOB        | CDL                 | Accident | DLNumber |
		| Donald    | Duck     | CA      | 03/13/1988 | Yes 3 or more years | No       |          |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                                                                              | Answer                                                                     |
		| Do you haul intermodal containers?                                                                                                                    | No                                                                         |
		| Do you have any active Trailer Interchange Agreements?                                                                                                | No                                                                         |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                           | 301 to 500 miles                                                           |
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
		| Do you rent any vehicles?                                                                                                                             | No                                                                         |
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

@CA @Unit
Scenario: CA FMCSA Question Default with furthest any vehicle travels is more than 501 miles
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
		| FirstName | LastName | DLState | DOB        | CDL                 | Accident | DLNumber |
		| Donald    | Duck     | CA      | 03/13/1988 | Yes 3 or more years | No       |          |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                                                                              | Answer                                                                     |
		| Do you haul intermodal containers?                                                                                                                    | No                                                                         |
		| Do you have any active Trailer Interchange Agreements?                                                                                                | No                                                                         |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                           | 501 miles or more                                                          |
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
		| Do you rent any vehicles?                                                                                                                             | No                                                                         |
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

@CA @Unit
Scenario: CA FMCSA Question Default with Amazon Delivery service question as Yes
	Given user starts a quote with:
		| Industry                                            | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Trucking: Retail to Homes; No Furniture or Mattress | 2         | I Run My Business From Property I Own | Vehicles     | 60634    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1             | Address2 | City    | Select an Address |
		| 2012                  | Corporation             | 3622 N Newcastle Ave |          | Chicago |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 1M1AE07Y63W014598 | Illinois        | 2800          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber     |
		| Sol       | Badguy   | IL      | 03/13/1988 | Yes 3 or more years |       |             |             | Yes      | A56712812351 |
	Then user clicks continue from the Drivers page
	Then user verifies the appearance of the Drivers Incidents page
	Then user adds incidents with the following values:
		| Driver     | Date       | Incident Type | At Fault |
		| Sol Badguy | 11/11/2021 | Accident      | Yes      |
	Then user continues to the Operations page
	Then user fills out the Operations page:
		| Question                                                                                                                                              | Answer                   |
		| Does your business engage in team driving?                                                                                                            | No - one driver per haul |
		| Do you participate in a delivery service on behalf of Amazon.com, Inc.?                                                                               | Yes                      |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                           | 50 miles or less         |
		| Does your business have a USDOT Number?                                                                                                               | Yes                      |
		| Enter the USDOT number                                                                                                                                | 3523332                  |
		| Do you have or plan on applying for an operating authority from the Federal Motor Carrier Safety Administration (FMCSA)?                              | Yes                      |
		| Do you haul intermodal containers?                                                                                                                    | No                       |
		| Do you have any active Trailer Interchange Agreements?                                                                                                | No                       |
		| Do you haul any fine art or jewelry?                                                                                                                  | No                       |
		| Do you provide residential moving services?                                                                                                           | No                       |
		| Do any of your vehicles travel to Mexico?                                                                                                             | No                       |
		| How many auto insurance claims did your business file in the last 3 years?                                                                            | 0                        |
		| I agree to submit proof of insurance claims history, also known as loss runs, for the last 3 years within 30 days of the effective date of the policy | true                     |
		| Do you haul any of these? Check all that apply:                                                                                                       |                          |
		| Do you haul large equipment or machinery?                                                                                                             | No                       |
		| Do you haul any hazardous materials?                                                                                                                  | No                       |
		| Do you rent any vehicles?                                                                                                                             | No                       |
		| Do you use any Owner-Operators?                                                                                                                       | No                       |
		| Do you have or plan on applying for an operating authority from the Illinois Commerce Commission?                                                     | No                       |
		| Do the owner(s) of this business have a combined majority ownership in any other transportation business?                                             | No                       |