Feature: CA_TransportationOfGoodsTerminalToTerminal_I


@Issued @Regression @GA @CA @Transportation
Scenario: CA Transportation Of Goods Terminal To Terminal Issued In Georgia
	Given user starts a quote with:
		| Industry                                      | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Transportation of Goods: Terminal to Terminal | 2         | I Run My Business From Property I Own | Vehicles     | 31093    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business                | DBA               | Policy Start Date |
		| Georgia Transportation of Goods | GA Transportation |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Government Entity Type | Address1               | Address2 | City          | Select an Address |
		| 2012                  | Government Entity       | Federal                | 1879 Watson Blvd Apt 1 |          | Warner Robins |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| No VIN           | Type Insure   | Year | Make     | Model        | Parking Address | Vehicle Worth |
		| 1XKWDB9X8Y850920 | Truck Tractor | 2000 | KENWORTH | CONSTRUCTION | Georgia         | 5800          |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| No VIN            | Type Insure     | Year | Make                   | No Model | Trailer Address | Trailer Worth |
		| 2TLSBES87NB000753 | Dry Van Trailer | 2020 | BIG TEX TRAILER CO INC |          | Georgia         | 2800          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber  |
		| Donald    | Duck     | GA      | 03/13/1986 | Yes 3 or more years |       |             |             | No       | 147849578 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                                                                                                   | Answer                   |
		| Do you haul intermodal containers?                                                                                                                                         | No                       |
		| Do you have any active Trailer Interchange Agreements?                                                                                                                     | No                       |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                                                | 50 miles or less         |
		| Do you haul any fine art or jewelry?                                                                                                                                       | No                       |
		| Do you provide residential moving services?                                                                                                                                | No                       |
		| Does your business engage in team driving?                                                                                                                                 | No - one driver per haul |
		| Do any of your vehicles travel to Mexico?                                                                                                                                  | No                       |
		| How many auto insurance claims did your business file in the last 3 years?                                                                                                 | 0                        |
		| I agree to provide a claims history (also known as a "loss run") that matches the information in this application for the last 3 years within 30 days of {effective date}. | true                     |
		| Do you haul any of these? Check all that apply:                                                                                                                            |                          |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                                            | No                       |
		| Do you haul any hazardous materials?                                                                                                                                       | No                       |
		| Do you rent any vehicles?                                                                                                                                                  | No                       |
		| Do you use any Owner-Operators?                                                                                                                                            | No                       |
		| Does your business have a USDOT Number?                                                                                                                                    | No                       |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer                                       |
		| First Name                      | Ariana                                       |
		| Last Name                       | Grande                                       |
		| Business Email                  | transportationterminaltoterminal@yopmail.com |
		| Business Phone                  | (555) 867-5309                               |
		| Business Website                |                                              |
		| Business has an account manager |                                              |
		| Want Save Money                 | Yes                                          |
		| Owner's First Name              | AutoLarryzzzzzzzzzzz                         |
		| Owner's Last Name               | AutoBarryzzzzzzzzzzzzz                       |
		| Owner's Address                 | 1879 Watson Blvd Apt 1                       |
		| Owner's Address 2               |                                              |
		| Owner's Zip Code                | 31093                                        |
		| Owner's City                    | Warner Robins                                |
		| Owner's State                   | GA                                           |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question            | Answer                                                      |
		| Yearly              | No                                                          |
		| Policy Coverages    | $750,000 Combined Single Limit                              |
		| Vehicle 1 Coverage  | $1000 Comprehensive Deductible / $1000 Collision Deductible |
		| Vehicle 2 Coverage  | No Physical Damage Coverage                                 |
		| Cargo Liability     | $100,000 Limit / $1,000 Deductible                          |
		| Trailer Interchange | $50,000 Limit / $1,000 Deductible                           |
	Then user verifies the coverage details
		| Coverages Not Selected |
		| Medical                |
		| Rental                 |
	Then user clicks Get Plan from coverage details page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN               | Trim                | OLF   | Who Holds Vehicle |
		| 1XKWDB9X8Y850920  | W900L Extended Hood | Owned | The Business      |
		| 2TLSBES87NB000753 |                     | Owned | The Business      |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Card Type |
		| 12 Monthly   | Visa      |
	Then user clicks purchase
	Then user verifies the Thank You Page
	And user verifies the WC section on the Thank You page