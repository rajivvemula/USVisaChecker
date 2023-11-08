Feature: CA_FoodTruck_R
Refer based on DL mismatch outlined in US105369
Referral reason: "State mismatch on license - driver was found in expensive auto coverage state but not there."

@CA @AZ @Referred @Regression
Scenario: CA Food Truck Referred
	Given user starts a quote with:
		| Industry   | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Food Truck | 0         | I Run My Business From Property I Own | Vehicles     | 85225    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business   | DBA | Policy Start Date |
		| TEST CA AUTH REFER |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured     | Address1          | Address2 | City     | Select an Address |
		| 2010                  | Limited Liability Co. (LLC) | 990 N Arizona Ave |          | Chandler |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 1FTPW14VX6KD83743 | Arizona         | 9100          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| TEST FN   | TEST LN  | CA      | 10/25/1986 |     |       |             |             | No       | K1236985 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer                  |
		| First Name                      | TEST FN                 |
		| Last Name                       | TEST LN                 |
		| Business Email                  | QAAutomation@biberk.com |
		| Business Phone                  | (123) 123-1321          |
		| Business Website                |                         |
		| Business has an account manager |                         |
		| Want Save Money                 | Yes                     |
		| Owner's First Name              | TEST FN                 |
		| Owner's Last Name               | TEST LN                 |
		| Owner's Address                 | 990 n Arizona Ave       |
		| Owner's Address 2               |                         |
		| Owner's Zip Code                | 85225                   |
		| Owner's City                    | Chandler                |
		| Owner's State                   | Arizona                 |
		| Select an Address               | Original                |
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | The Business      |
	Then user clicks continue from Additional Information
	And user verifies the CA refer confirmation appearance