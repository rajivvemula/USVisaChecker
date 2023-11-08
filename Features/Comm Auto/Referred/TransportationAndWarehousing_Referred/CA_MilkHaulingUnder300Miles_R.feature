Feature: CA_MilkHaulingUnder300Miles_R
CA Milk Hauling Under 300 Miles Referred In Illinois

@CA @Regression @Transportation @Referred @IL
Scenario: CA Milk Hauling Under 300 Miles Referred
	Given user starts a quote with:
		| Industry                      | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Milk Hauling: under 300 miles | 2         | I Lease a Space From Others | Vehicles     | 60185    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA | Policy Start Date |
		| TEST CA REFER    |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1    | Address2 | City         | Select an Address |
		| 2010                  | Corporation             | 100 Main St |          | West Chicago |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 2HGFA16517H504306 | Illinois        | 4250          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber     |
		| TEST FN   | TEST LN  | IL      | 10/05/1989 | Yes 3 or more years |       |             |             | No       | L12345678901 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                          | Answer                   |
		| Do you haul intermodal containers?                                                                | No                       |
		| What is the furthest any of your vehicles travel in any one direction from their home base?       | 50 miles or less         |
		| Do you haul any fine art or jewelry?                                                              | No                       |
		| Do you provide residential moving services?                                                       | No                       |
		| Does your business engage in team driving?                                                        | No - one driver per haul |
		| Do any of your vehicles travel to Mexico?                                                         | No                       |
		| How many auto insurance claims did your business file in the last 3 years?                        | 5                        |
		| Do you haul any of these? Check all that apply:                                                   |                          |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                   | No                       |
		| Do you haul any hazardous materials?                                                              | No                       |
		| Do you rent any vehicles?                                                                         | No                       |
		| Do you use any Owner-Operators?                                                                   | No                       |
		| Does your business have a USDOT Number?                                                           | No                       |
		| Do you have or plan on applying for an operating authority from the Illinois Commerce Commission? | No                       |
	Then user continues to the Contact page
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
		| Owner's Address                 | 100 Main St             |
		| Owner's Address 2               |                         |
		| Owner's Zip Code                | 60185                   |
		| Owner's City                    | West Chicago            |
		| Owner's State                   | Illinois                |
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | The Business      |
	Then user clicks continue from Additional Information
	And user verifies the CA refer confirmation appearance