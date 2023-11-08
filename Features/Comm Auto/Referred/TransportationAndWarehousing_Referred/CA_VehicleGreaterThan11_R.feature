Feature: CA_VehicleGreaterThan11_R
CA Vehicle Greater Than 11 Referred In Illinois

@CA @Regression @Transportation @IL @Referred
Scenario: CA Vehicle Greater Than 11 Referred
	Given user starts a quote with:
		| Industry                      | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Milk Hauling: under 300 miles | 12        | I Lease a Space From Others | Vehicles     | 60185    | CA  |
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
		| 2HGFA16517H504306 | Illinois        | 5000          |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| JH4KA4630JC008595 | Illinois        | 5000          |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| KLATA52671B611178 | Illinois        | 6000          |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| WBAAM3333XFP59732 | Illinois        | 2000          |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| JH4DA9450LS007904 | Illinois        | 7000          |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| JH4KA4531JC024340 | Illinois        | 6500          |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| JH4DA9350NS005381 | Illinois        | 4000          |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| JHMBB2269NC026648 | Illinois        | 4500          |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| JH4DA3453GS006314 | Illinois        | 7200          |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 4JGBB86E27A199749 | Illinois        | 5000          |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address |
		| SALME1D48CA365300 | Illinois        |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address |
		| KMHDU4AD4AU955646 | Illinois        |
	Then user clicks Let's Continue
	Then user fills out the Operations page:
		| Question                                                                                                                                              | Answer                   |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                           | 50 miles or less         |
		| Does your business engage in team driving?                                                                                                            | No - one driver per haul |
		| Do any of your vehicles travel to Mexico?                                                                                                             | No                       |
		| Do you haul any fine art or jewelry?                                                                                                                  | No                       |
		| Do you haul intermodal containers?                                                                                                                    | No                       |
		| How many auto insurance claims did your business file in the last 3 years?                                                                            | 0                        |
		| I agree to submit proof of insurance claims history, also known as loss runs, for the last 3 years within 30 days of the effective date of the policy | true                     |
		| Do you provide residential moving services?                                                                                                           | No                       |
		| Do you haul any of these? Check all that apply:                                                                                                       |                          |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                       | No                       |
		| Do you haul any hazardous materials?                                                                                                                  | No                       |
		| Do you rent any vehicles?                                                                                                                             | No                       |
		| Do you use any Owner-Operators?                                                                                                                       | No                       |
		| Does your business have a USDOT Number?                                                                                                               | No                       |
		| Do you have or plan on applying for an operating authority from the Illinois Commerce Commission?                                                     | No                       |
	Then user continues to the Contact page
	And user enters contact information:
		| Question                        | Answer             |
		| First Name                      | TEST JE            |
		| Last Name                       | TEST EJ            |
		| Business Email                  | joe.eso@biberk.com |
		| Business Phone                  | (123) 123-1321     |
		| Business Website                |                    |
		| Business has an account manager |                    |
		| Want Save Money                 | Yes                |
		| Owner's First Name              | TEST JE            |
		| Owner's Last Name               | TEST EJ            |
		| Owner's Address                 | 100 Main St        |
		| Owner's Address 2               |                    |
		| Owner's Zip Code                | 60185              |
		| Owner's City                    | West Chicago       |
		| Owner's State                   | Illinois           |
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | The Business      |
		| Yes | Owned | The Business      |
		| Yes | Owned | The Business      |
		| Yes | Owned | The Business      |
		| Yes | Owned | The Business      |
		| Yes | Owned | The Business      |
		| Yes | Owned | The Business      |
		| Yes | Owned | The Business      |
		| Yes | Owned | The Business      |
		| Yes | Owned | The Business      |
		| Yes | Owned | The Business      |
		| Yes | Owned | The Business      |
	Then user clicks continue from Additional Information
	And user verifies the CA refer confirmation appearance