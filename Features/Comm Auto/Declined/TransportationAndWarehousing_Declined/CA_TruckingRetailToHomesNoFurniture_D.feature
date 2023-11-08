Feature: CA_TruckingRetailToHomesNoFurniture_D

A short summary of the feature

@Transportation @Declined @Regression @IL @CA
Scenario: CA Trucking Retail To Homes No Furniture Declined Too Many Accidents
	Given user starts a quote with:
		| Industry                                            | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Trucking: Retail to Homes; No Furniture or Mattress | 2         | I Run My Business From Property I Own | Vehicles     | 60634    | CA  |
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
		| Sol Badguy | 11/12/2021 | Accident      | No       |
		| Sol Badguy | 11/13/2021 | Accident      | Yes      |
	Then user continues to the Operations page
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
		| Do you participate in a delivery service on behalf of Amazon.com, Inc.?                                                                               | No                       |
		| Do you rent any vehicles?                                                                                                                             | No                       |
		| Do you use any Owner-Operators?                                                                                                                       | No                       |
		| Does your business have a USDOT Number?                                                                                                               | No                       |
		| Do you have or plan on applying for an operating authority from the Illinois Commerce Commission?                                                     | No                       |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer               |
		| First Name                      | Sol                  |
		| Last Name                       | Badguy               |
		| Business Email                  | a@b.co               |
		| Business Phone                  | (555) 867-5309       |
		| Business Website                |                      |
		| Business has an account manager |                      |
		| Want Save Money                 | Yes                  |
		| Owner's First Name              | Larry                |
		| Owner's Last Name               | Barry                |
		| Owner's Address                 | 3622 N Newcastle Ave |
		| Owner's Address 2               |                      |
		| Owner's Zip Code                | 60634                |
		| Owner's City                    | Chicago              |
		| Owner's State                   | IL                   |
	Then user verifies the appearance of the Decline page



@Transportation @Declined @Regression @IL @CA
Scenario: CA Trucking Retail To Homes No Furniture Declined Two Or More Convictions
	Given user starts a quote with:
		| Industry                                            | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Trucking: Retail to Homes; No Furniture or Mattress | 2         | I Run My Business From Property I Own | Vehicles     | 60634    | CA  |
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
	Then user adds an incident with variable values:
		| Driver     | Date       | Incident Type        | Violation/Conviction | Another V/C | Violation/Conviction      | Another V/C |
		| Sol Badguy | 11/11/2021 | Violation/Conviction | Hit and Run          | Yes         | Reckless/Careless driving | No          |
	Then user continues to the Operations page
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
		| Do you participate in a delivery service on behalf of Amazon.com, Inc.?                                                                               | No                       |
		| Do you haul any hazardous materials?                                                                                                                  | No                       |
		| Do you rent any vehicles?                                                                                                                             | No                       |
		| Do you use any Owner-Operators?                                                                                                                       | No                       |
		| Does your business have a USDOT Number?                                                                                                               | No                       |
		| Do you have or plan on applying for an operating authority from the Illinois Commerce Commission?                                                     | No                       |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer               |
		| First Name                      | Sol                  |
		| Last Name                       | Badguy               |
		| Business Email                  | a@b.co               |
		| Business Phone                  | (555) 867-5309       |
		| Business Website                |                      |
		| Business has an account manager |                      |
		| Want Save Money                 | Yes                  |
		| Owner's First Name              | Larry                |
		| Owner's Last Name               | Barry                |
		| Owner's Address                 | 3622 N Newcastle Ave |
		| Owner's Address 2               |                      |
		| Owner's Zip Code                | 60634                |
		| Owner's City                    | Chicago              |
		| Owner's State                   | IL                   |
	Then user verifies the appearance of the Decline page


	
@Transportation @Declined @Regression @IL @CA
Scenario: CA Trucking Retail To Homes No Furniture Declined 5 or More Violations
	Given user starts a quote with:
		| Industry                                            | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Trucking: Retail to Homes; No Furniture or Mattress | 2         | I Run My Business From Property I Own | Vehicles     | 60634    | CA  |
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
	Then user adds an incident with variable values:
		| Driver     | Date       | Incident Type        | Violation/Conviction       | Another V/C |
		| Sol Badguy | 11/11/2021 | Violation/Conviction | Equipment/Safety Violation | No          |
	Then user will add another incident
	Then user adds an incident with variable values:
		| Driver     | Date       | Incident Type        | Violation/Conviction                         | Reckless | Another V/C |
		| Sol Badguy | 11/12/2021 | Violation/Conviction | Speeding 16 MPH or more over the Speed Limit | No       | No          |
	Then user will add another incident
	Then user adds an incident with variable values:
		| Driver     | Date       | Incident Type        | Violation/Conviction         | Another V/C |
		| Sol Badguy | 11/13/2021 | Violation/Conviction | Other Minor Moving Violation | No          |
	Then user will add another incident
	Then user adds an incident with variable values:
		| Driver     | Date       | Incident Type        | Violation/Conviction          | Another V/C |
		| Sol Badguy | 11/14/2021 | Violation/Conviction | Red Light/Stop Sign violation | No          |
	Then user will add another incident
	Then user adds an incident with variable values:
		| Driver     | Date       | Incident Type        | Violation/Conviction       | Another V/C |
		| Sol Badguy | 11/15/2021 | Violation/Conviction | Other Non-Moving Violation | No          |
	Then user continues to the Operations page
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
		| Do you participate in a delivery service on behalf of Amazon.com, Inc.?                                                                               | No                       |
		| Do you rent any vehicles?                                                                                                                             | No                       |
		| Do you use any Owner-Operators?                                                                                                                       | No                       |
		| Does your business have a USDOT Number?                                                                                                               | No                       |
		| Do you have or plan on applying for an operating authority from the Illinois Commerce Commission?                                                     | No                       |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer               |
		| First Name                      | Sol                  |
		| Last Name                       | Badguy               |
		| Business Email                  | a@b.co               |
		| Business Phone                  | (555) 867-5309       |
		| Business Website                |                      |
		| Business has an account manager |                      |
		| Want Save Money                 | Yes                  |
		| Owner's First Name              | Larry                |
		| Owner's Last Name               | Barry                |
		| Owner's Address                 | 3622 N Newcastle Ave |
		| Owner's Address 2               |                      |
		| Owner's Zip Code                | 60634                |
		| Owner's City                    | Chicago              |
		| Owner's State                   | IL                   |
	Then user verifies the appearance of the Decline page