Feature: CA_InvalidZipTest_U
Verify that invalid zip codes cannot be used and confirm error text appears
@Unit @Staging @Regression
Scenario: CA Invalid Zip Test Unit
	Given user starts a quote with:
		| Industry                  | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Delivery: Courier Service | 3         | I Work at a Job Site | Vehicles     | 31201    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA         | Policy Start Date |
		| TEST CA QUOTE    | TEST CA DBA |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1     | Address2 | City  | Select an Address |
		| 2000                  | Corporation             | 550 Gray Hwy |          | Macon | Original          |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address |
		| 3N1AB6AP9CL760256 | Georgia         |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber  |
		| TEST FN   | TEST LN  | GA      | 08/08/1988 | Yes 3 or more years |       |             |             | No       | 097584622 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer                   |
		| Do you haul intermodal containers?                                                          | No                       |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less         |
		| Do you haul any fine art or jewelry?                                                        | No                       |
		| Do you provide residential moving services?                                                 | No                       |
		| Does your business engage in team driving?                                                  | No - one driver per haul |
		| Do any of your vehicles travel to Mexico?                                                   | No                       |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                        |
		| Do you haul any of these? Check all that apply:                                             |                          |
		| Do you haul large equipment or machinery requiring chains to secure in transit?             | No                       |
		| Do you haul any hazardous materials?                                                        | No                       |
		| Do you participate in a delivery service on behalf of Amazon.com, Inc.?                     | No                       |
		| Do you rent any vehicles?                                                                   | No                       |
		| Do you use any Owner-Operators?                                                             | No                       |
		| Does your business have a USDOT Number?                                                     | No                       |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	Then user enters contact information to validate zip code error:
		| Owner's Zip Code |
		| .42.4            |
	Then user enters contact information to validate zip code error:
		| Owner's Zip Code |
		| A3F5G            |
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
		| Owner's Address                 | 7777 E Flamingo Rd      |
		| Owner's Address 2               |                         |
		| Owner's Zip Code                | 31201                   |
		| Owner's City                    | Paradise                |
		| Owner's State                   | Nevada                  |
		| Select an Address               | Original                |