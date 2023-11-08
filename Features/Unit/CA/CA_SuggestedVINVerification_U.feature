Feature: CA_SuggestedVINVerification_U

Suggested VIN and Original VIN verification on Summary Page

Background:
	Given user starts a quote with:
		| Industry    | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Uber Driver | 2         | I Run My Business From Property I Own | Vehicles     | 37211    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured    | Address1            | Address2 | City      | Select an Address |
		| 1980                  | Individual/Sole Proprietor | 708 Misty Pines Cir |          | Nashville |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page

@Unit @CA @SuggestedVIN
Scenario: CA Suggested VIN Verification Unit Summary Page Original VIN
	Then user creates a vehicle or trailer with variable values:
		| Suggested VIN | VIN               | Parking Address | Vehicle Worth | Type Insure | Year | Make  | Model   | Fare Box |
		| Original      | JH4DA1745GP002661 | Tennessee       | 12000         | Car - Sedan | 1986 | ACURA | INTEGRA | No       |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber  |
		| Anna      | Kendrick | TN      | 03/13/1986 |     |       |             |             | Yes      | 147849578 |
	Then user clicks continue from the Drivers page
	Then user verifies the appearance of the Drivers Incidents page
	Then user adds incidents with the following values:
		| Driver        | Date       | Incident Type | At Fault |
		| Anna Kendrick | 11/11/2021 | Accident      | No       |
	Then user continues to the Operations page
	Then user fills out the Operations page:
		| Question                                                                                            | Answer           |
		| Do you offer "party" bus or limousine services where alcohol is provided or expressly permitted?    | No               |
		| Do you provide any school, camp, day care, or field trip transportation for children 12 or younger? | No               |
		| Do any of your vehicles travel to Mexico?                                                           | No               |
		| What is the furthest any of your vehicles travel in any one direction from their home base?         | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                          | 0                |
		| Do you rent any vehicles?                                                                           | No               |
		| Do you use any Owner-Operators?                                                                     | No               |
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
		| Want Save Money                 | Yes                    |
		| Owner's First Name              | AutoLarryzzzzzzzzzzz   |
		| Owner's Last Name               | AutoBarryzzzzzzzzzzzzz |
		| Owner's Address                 | 1879 Watson Blvd Apt 1 |
		| Owner's Address 2               |                        |
		| Owner's Zip Code                | 31093                  |
		| Owner's City                    | warner robins          |
		| Owner's State                   | Georgia                |
		| Select an Address               | Suggested              |
	Then user verifies the appearance of the Summary page

@Unit @CA @SuggestedVIN
Scenario: CA Suggested VIN Verification Unit Summary Page Suggested VIN
	Then user creates a vehicle or trailer with variable values:
		| Suggested VIN | VIN               | Parking Address | Vehicle Worth | Fare Box |
		| Suggested     | JH4DA1745GP002661 | Tennessee       | 12000         | No       |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber  |
		| Anna      | Kendrick | TN      | 03/13/1986 |     |       |             |             | Yes      | 147849578 |
	Then user clicks continue from the Drivers page
	Then user verifies the appearance of the Drivers Incidents page
	Then user adds incidents with the following values:
		| Driver        | Date       | Incident Type | At Fault |
		| Anna Kendrick | 11/11/2021 | Accident      | No       |
	Then user continues to the Operations page
	Then user fills out the Operations page:
		| Question                                                                                            | Answer           |
		| Do you offer "party" bus or limousine services where alcohol is provided or expressly permitted?    | No               |
		| Do you provide any school, camp, day care, or field trip transportation for children 12 or younger? | No               |
		| Do any of your vehicles travel to Mexico?                                                           | No               |
		| What is the furthest any of your vehicles travel in any one direction from their home base?         | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                          | 0                |
		| Do you rent any vehicles?                                                                           | No               |
		| Do you use any Owner-Operators?                                                                     | No               |
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
		| Want Save Money                 | Yes                    |
		| Owner's First Name              | AutoLarryzzzzzzzzzzz   |
		| Owner's Last Name               | AutoBarryzzzzzzzzzzzzz |
		| Owner's Address                 | 1879 Watson Blvd Apt 1 |
		| Owner's Address 2               |                        |
		| Owner's Zip Code                | 31093                  |
		| Owner's City                    | warner robins          |
		| Owner's State                   | Georgia                |
		| Select an Address               | Suggested              |
	Then user verifies the appearance of the Summary page