Feature: CA_RetailStoreAutomotiveParts_D

Feature file to test the following new questions:
1. Do you have new or used vehicle/trailer inventory that you sell or lease to others? (This question causes question 2 to appear and is tested as part of the first scneario)
2. This policy is only for vehicles you own or lease for business purposes and also add to the policy.  It does not cover vehicles held for sale as inventory.  Separate coverage known as auto dealers coverage must be purchased.
3. Do you rent vehicles/trailers to others for pay?

Retail Store: Automotive Parts
4303 Harmony Church Rd, Adams, TN 37010

@Declined @CA @Regression @SC
Scenario: CA Retail Store Automotive Parts Declined Garage Keepers Insurance Coverage Service Repair
	Given user starts a quote with:
		| Industry                       | Employees | Location             | Own or Lease                | ZIP Code | LOB |
		| Retail Store: Automotive Parts | 7         | I Work at a Job Site | Vehicles;Tools or Equipment | 37010    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		| test             | No  |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1               | Address2 | City  | Select an Address |
		| 2012                  | Corporation             | 4303 Harmony Church Rd |          | Adams |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Towing Or Roadside |
		| 1FTFW1E88NFA58133 | Tennessee       | No                 |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | Accident | DLNumber  |
		| Test      | Driver   | TN      | 03/13/1986 | No       | 085671243 |
	Then user continues to the Operations page
	Then user fills out the Operations page:
		| Question                                                                                                                                                                                                                         | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                                                                                                      | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                                                                                                                                                       | 0                |
		| Do you have new or used vehicle/trailer inventory that you sell or lease to others?                                                                                                                                              | Yes              |
		| This policy is only for vehicles you own or lease for business purposes and also add to the policy.  It does not cover vehicles held for sale as inventory.  Separate coverage known as auto dealers coverage must be purchased. | I do not agree   |
		| Do you rent vehicles/trailers to others for pay?                                                                                                                                                                                 | No               |
	Then user continues to the Contact page
	And user enters contact information:
		| Question                        | Answer                 |
		| First Name                      | Test                   |
		| Last Name                       | Driver                 |
		| Business Email                  | abc@321.com            |
		| Business Phone                  | (555) 867-5309         |
		| Business Website                |                        |
		| Business has an account manager |                        |
		| Want Save Money                 | Yes                    |
		| Owner's First Name              | Test                   |
		| Owner's Last Name               | Owner                  |
		| Owner's Address                 | 4303 Harmony Church Rd |
		| Owner's Address 2               |                        |
		| Owner's Zip Code                | 37010                  |
		| Owner's City                    | Adams                  |
		| Owner's State                   | SC                     |
	Then user verifies the appearance of the Decline page

@Declined @CA @Regression @SC @NewCAQuestions
Scenario: CA Retail Store Automotive Parts Declined Renting Vehicles To Others For Pay
	Given user starts a quote with:
		| Industry                       | Employees | Location             | Own or Lease                | ZIP Code | LOB |
		| Retail Store: Automotive Parts | 7         | I Work at a Job Site | Vehicles;Tools or Equipment | 37010    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		| test             | No  |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1               | Address2 | City  | Select an Address |
		| 2012                  | Corporation             | 4303 Harmony Church Rd |          | Adams |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Towing Or Roadside |
		| 1FTFW1E88NFA58133 | Tennessee       | No                 |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | Accident | DLNumber  |
		| Test      | Driver   | TN      | 03/13/1986 | No       | 085671243 |
	Then user continues to the Operations page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
		| Do you have new or used vehicle/trailer inventory that you sell or lease to others?         | No               |
		| Do you rent vehicles/trailers to others for pay?                                            | Yes              |
	Then user continues to the Contact page
	And user enters contact information:
		| Question                        | Answer                 |
		| First Name                      | Test                   |
		| Last Name                       | Driver                 |
		| Business Email                  | abc@321.com            |
		| Business Phone                  | (555) 867-5309         |
		| Business Website                |                        |
		| Business has an account manager |                        |
		| Want Save Money                 | Yes                    |
		| Owner's First Name              | Test                   |
		| Owner's Last Name               | Owner                  |
		| Owner's Address                 | 4303 Harmony Church Rd |
		| Owner's Address 2               |                        |
		| Owner's Zip Code                | 37010                  |
		| Owner's City                    | Adams                  |
		| Owner's State                   | SC                     |
	Then user verifies the appearance of the Decline page