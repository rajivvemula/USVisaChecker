Feature: CA_PostalService_D

A short summary of the feature


Background:
	Given user starts a quote with:
		| Industry       | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Postal Service | 2         | I Run My Business From Property I Own | Vehicles     | 77449    | CA  |
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
		| Year Business Started | How Business Structured | Address1            | Address2 | City | Select an Address |
		| 2012                  | Corporation             | 18942 Sandelford Dr |          | Katy |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 4S7PT9J18RC013879 | Texas           | 2800          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| Chuck     | Norris   | TX      | 03/13/1988 | Yes 3 or more years |       |             |             | No       | 02938544 |
	Then user clicks continue from the Drivers page

@Transportation @Declined @Regression @TX @CA
Scenario: CA Postal Service Declined Hauling Coal
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
		| Do you haul any of these? Check all that apply:                                                                                                       | Coal                     |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                       | No                       |
		| Do you haul any hazardous materials?                                                                                                                  | No                       |
		| Do you participate in a delivery service on behalf of Amazon.com, Inc.?                                                                               | No                       |
		| Do you rent any vehicles?                                                                                                                             | No                       |
		| Do you use any Owner-Operators?                                                                                                                       | No                       |
		| Does your business have a USDOT Number?                                                                                                               | No                       |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer              |
		| First Name                      | Larry               |
		| Last Name                       | Barry               |
		| Business Email                  | a@b.com             |
		| Business Phone                  | 5558675309          |
		| Business Website                |                     |
		| Business has an account manager |                     |
		| Want Save Money                 | Yes                 |
		| Owner's First Name              | Larry               |
		| Owner's Last Name               | Barry               |
		| Owner's Address                 | 18942 Sandelford Dr |
		| Owner's Address 2               |                     |
		| Owner's Zip Code                | 77449               |
		| Owner's City                    | Katy                |
		| Owner's State                   | Texas               |
	Then user verifies the appearance of the Decline page

@Transportation @Declined @Regression @TX @CA
Scenario: CA Postal Service Declined Hauling Livestock
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
		| Do you haul any of these? Check all that apply:                                                                                                       | Livestock                |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                       | No                       |
		| Do you haul any hazardous materials?                                                                                                                  | No                       |
		| Do you participate in a delivery service on behalf of Amazon.com, Inc.?                                                                               | No                       |
		| Do you rent any vehicles?                                                                                                                             | No                       |
		| Do you use any Owner-Operators?                                                                                                                       | No                       |
		| Does your business have a USDOT Number?                                                                                                               | No                       |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer              |
		| First Name                      | Larry               |
		| Last Name                       | Barry               |
		| Business Email                  | a@b.com             |
		| Business Phone                  | 5558675309          |
		| Business Website                |                     |
		| Business has an account manager |                     |
		| Owner's First Name              | Larry               |
		| Owner's Last Name               | Barry               |
		| Owner's Address                 | 18942 Sandelford Dr |
		| Owner's Address 2               |                     |
		| Owner's Zip Code                | 77449               |
		| Owner's City                    | Katy                |
		| Owner's State                   | Texas               |
	Then user verifies the appearance of the Decline page

@Transportation @Declined @Regression @TX @CA
Scenario: CA Postal Service Declined Hauling Sugarcane
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
		| Do you haul any of these? Check all that apply:                                                                                                       | Sugarcane                |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                       | No                       |
		| Do you haul any hazardous materials?                                                                                                                  | No                       |
		| Do you participate in a delivery service on behalf of Amazon.com, Inc.?                                                                               | No                       |
		| Do you rent any vehicles?                                                                                                                             | No                       |
		| Do you use any Owner-Operators?                                                                                                                       | No                       |
		| Does your business have a USDOT Number?                                                                                                               | No                       |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer              |
		| First Name                      | Larry               |
		| Last Name                       | Barry               |
		| Business Email                  | a@b.com             |
		| Business Phone                  | 5558675309          |
		| Business Website                |                     |
		| Business has an account manager |                     |
		| Want Save Money                 | Yes                 |
		| Owner's First Name              | Larry               |
		| Owner's Last Name               | Barry               |
		| Owner's Address                 | 18942 Sandelford Dr |
		| Owner's Address 2               |                     |
		| Owner's Zip Code                | 77449               |
		| Owner's City                    | Katy                |
		| Owner's State                   | Texas               |
	Then user verifies the appearance of the Decline page