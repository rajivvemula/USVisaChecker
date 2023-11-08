Feature: CA_TrimDropdownAppearance_U

Issued a Policy to verify the Trim Dropdown appearance and returning to beginning of the CA path for changes 

@Unit @Issued @Staging @Regression @NV @CA @Transportation
Scenario: CA Trim Dropdown Appearance Unit Delivery Courier Service
	Given user starts a quote with:
		| Industry                  | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Delivery: Courier Service | 3         | I Work at a Job Site | Vehicles     | 31201    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
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
		| Question                                                                                                                                              | Answer                   |
		| Do you haul intermodal containers?                                                                                                                    | No                       |
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
		| Question                        | Answer                |
		| First Name                      | TEST FN               |
		| Last Name                       | TEST LN               |
		| Business Email                  | automation@biberk.com |
		| Business Phone                  | (123) 123-1321        |
		| Business Website                |                       |
		| Business has an account manager |                       |
		| Want Save Money                 | Yes                   |
		| Owner's First Name              | TEST FN               |
		| Owner's Last Name               | TEST LN               |
		| Owner's Address                 | 550 Gray Hwy          |
		| Owner's Address 2               |                       |
		| Owner's Zip Code                | 31201                 |
		| Owner's City                    | Macon                 |
		| Owner's State                   | Georgia               |
		| Select an Address               | Original              |
	Then user verifies the appearance of the Summary page
	Then user returns to A Quick Introduction page for reverification
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business     | DBA                | Policy Start Date |
		| TEST CA QUOTE CHANGE | TEST CA DBA CHANGE |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured     | Address1      | Address2 | City  | Select an Address |
		| 2001                  | Limited Liability Co. (LLC) | 874 Willow St |          | Macon | Original          |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Trim         |
		| 3N1AB6AP9CL760256 | Georgia         | Sedan 4D 2.0 |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL              | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber  |
		| TEST FFN  | TEST LLN | GA      | 08/08/1989 | Yes 1 to 2 years |       |             |             | No       | 091264877 |
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
		| Do you rent any vehicles?                                                                   | No                       |
		| Do you use any Owner-Operators?                                                             | No                       |
		| Does your business have a USDOT Number?                                                     | No                       |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer                |
		| First Name                      | TEST FNC              |
		| Last Name                       | TEST LNC              |
		| Business Email                  | automation@biberk.com |
		| Business Phone                  | (123) 123-1321        |
		| Business Website                |                       |
		| Business has an account manager |                       |
		| Want Save Money                 | Yes                   |
		| Owner's First Name              | TEST FNC              |
		| Owner's Last Name               | TEST LNC              |
		| Owner's Address                 | 874 Willow St         |
		| Owner's Address 2               |                       |
		| Owner's Zip Code                | 31201                 |
		| Owner's City                    | Macon                 |
		| Owner's State                   | Georgia               |
		| Select an Address               | Original              |
	Then user reverifies the appearance of Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	Then user clicks continue from the Quote page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | The Business      |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Card Type |
		| 12 Monthly   | Visa      |
	Then user clicks purchase