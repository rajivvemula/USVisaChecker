Feature: CA_OptCreditCheck_U

@Unit @CA
Scenario: CA Opt Credit Check Unit In OH
	Given user starts a quote with:
		| Industry    | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Uber Driver | 2         | I Run My Business From Property I Own |              | 45102    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business   | DBA | Policy Start Date |
		| PassOn CreditCheck |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1       | Address2 | City   | Select an Address |
		| 2012                  | Corporation             | 1261 Ohio Pike |          | Amelia | Suggested         |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Trim        | Parking Address | Vehicle Worth | Fare Box |
		| 3N1CB51DX3L800403 | Sedan 4D XE | Ohio            | 2000          | No       |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| Aubrey    | Plaza    | OH      | 03/13/1985 |     |       |             |             | No       |          |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                            | Answer          |
		| Do you offer "party" bus or limousine services where alcohol is provided or expressly permitted?    | No              |
		| Do you provide any school, camp, day care, or field trip transportation for children 12 or younger? | No              |
		| What is the furthest any of your vehicles travel in any one direction from their home base?         | 51 to 100 miles |
		| Do any of your vehicles travel to Mexico?                                                           | No              |
		| How many auto insurance claims did your business file in the last 3 years?                          | 0               |
		| Do you rent any vehicles?                                                                           | No              |
		| Do you use any Owner-Operators?                                                                     | No              |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer         |
		| First Name                      | Ariana         |
		| Last Name                       | Grande         |
		| Business Email                  | a@b.co         |
		| Business Phone                  | (555) 867-5309 |
		| Business Website                |                |
		| Business has an account manager |                |
		| Manager's First Name            |                |
		| Manager's Last Name             |                |
		| Manager's Email                 |                |
		| Manager's Phone                 |                |
		| Want Save Money                 | No             |
	Then user verifies landing on Summary page

@Unit @CA
Scenario: CA Opt Credit Check In WI
	Given user starts a quote with:
		| Industry    | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Uber Driver | 2         | I Run My Business From Property I Own |              | 53223    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business  | DBA | Policy Start Date |
		| DoThe CreditCheck |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1             | Address2 | City      | Select an Address |
		| 2012                  | Corporation             | 2455 W Wisconsin Ave |          | Milwaukee | Suggested         |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Fare Box |
		| 1G6DP1E33C0141237 | Wisconsin       | No       |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| Aubrey    | Plaza    | WI      | 03/13/1985 |     |       |             |             | No       |          |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                            | Answer          |
		| Do you offer "party" bus or limousine services where alcohol is provided or expressly permitted?    | No              |
		| Do you provide any school, camp, day care, or field trip transportation for children 12 or younger? | No              |
		| What is the furthest any of your vehicles travel in any one direction from their home base?         | 51 to 100 miles |
		| Do any of your vehicles travel to Mexico?                                                           | No              |
		| How many auto insurance claims did your business file in the last 3 years?                          | 0               |
		| Do you rent any vehicles?                                                                           | No              |
		| Do you use any Owner-Operators?                                                                     | No              |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer               |
		| First Name                      | Ariana               |
		| Last Name                       | Grande               |
		| Business Email                  | a@b.co               |
		| Business Phone                  | (555) 867-5309       |
		| Business Website                |                      |
		| Business has an account manager |                      |
		| Manager's First Name            |                      |
		| Manager's Last Name             |                      |
		| Manager's Email                 |                      |
		| Manager's Phone                 |                      |
		| Want Save Money                 | Yes                  |
		| Owner's First Name              | Larryzzz             |
		| Owner's Last Name               | Barryzzzz            |
		| Owner's Address                 | 2455 W Wisconsin Ave |
		| Owner's Address 2               |                      |
		| Owner's Zip Code                | 53223                |
		| Owner's City                    | Milwaukee            |
		| Owner's State                   | Wisconsin            |
		| Select an Address               | Suggested            |
	Then user verifies landing on Summary page

@Unit @CA
Scenario: CA Opt Credit Check Mandatory In IL
	Given user starts a quote with:
		| Industry    | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Uber Driver | 2         | I Run My Business From Property I Own |              | 60606    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business      | DBA | Policy Start Date |
		| CreditCheck Mandatory |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1       | Address2 | City    | Select an Address |
		| 2012                  | Corporation             | 225 S Canal St |          | Chicago |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Fare Box |
		| 1G6DP1E33C0141237 | Illinois        | No       |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber     |
		| Aubrey    | Plaza    | IL      | 03/13/1985 |     |       |             |             | No       | t74187457844 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                            | Answer          |
		| Do you offer "party" bus or limousine services where alcohol is provided or expressly permitted?    | No              |
		| Do you provide any school, camp, day care, or field trip transportation for children 12 or younger? | No              |
		| What is the furthest any of your vehicles travel in any one direction from their home base?         | 51 to 100 miles |
		| Do any of your vehicles travel to Mexico?                                                           | No              |
		| How many auto insurance claims did your business file in the last 3 years?                          | 0               |
		| Do you rent any vehicles?                                                                           | No              |
		| Do you use any Owner-Operators?                                                                     | No              |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer         |
		| First Name                      | Ariana         |
		| Last Name                       | Grande         |
		| Business Email                  | a@b.co         |
		| Business Phone                  | (555) 867-5309 |
		| Business Website                |                |
		| Business has an account manager |                |
		| Manager's First Name            |                |
		| Manager's Last Name             |                |
		| Manager's Email                 |                |
		| Manager's Phone                 |                |
		| Want Save Money                 | Yes            |
		| Owner's First Name              | Larryzzz       |
		| Owner's Last Name               | Barryzzzz      |
		| Owner's Address                 | 225 S Canal St |
		| Owner's Address 2               |                |
		| Owner's Zip Code                | 60606          |
		| Owner's City                    | Chicago        |
		| Owner's State                   | Illinois       |
	Then user verifies landing on Summary page