Feature: CA_WasteDisposalServices_D

US 79738 - Added new CA questions

@Declined @CA @Regression @SC
Scenario: CA Waste Disposal Services Declined Hauling Hazardous Materials
	Given user starts a quote with:
		| Industry                | Employees | Location                    | Own or Lease                | ZIP Code | LOB |
		| Waste Disposal Services | 0         | I Lease a Space From Others | Vehicles;Tools or Equipment | 29209    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		| test             | No  |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1         | Address2 | City     | Select an Address |
		| 2022                  | Corporation             | 806 Universal Dr |          | Columbia |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Haul | Plowing Snow |
		| 1FTFW1E88NFA58133 | South Carolina  | No   | No           |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | Accident | DLNumber  |
		| Test      | Driver   | SC      | 03/13/1986 | No       | 085671243 |
	Then user continues to the Operations page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file since it started?                     | 0                |
		| Do you haul any hazardous waste or hazardous materials?                                     | Yes              |
		| Do you enter inside customer's homes or buildings to pick up or deliver any items?          | No               |
	Then user continues to the Contact page
	And user enters contact information:
		| Question                        | Answer           |
		| First Name                      | Test             |
		| Last Name                       | Driver           |
		| Business Email                  | abc@3212.com     |
		| Business Phone                  | (555) 867-5209   |
		| Business Website                |                  |
		| Business has an account manager |                  |
		| Want Save Money                 | Yes              |
		| Owner's First Name              | Test             |
		| Owner's Last Name               | Owner            |
		| Owner's Address                 | 806 Universal Dr |
		| Owner's Address 2               |                  |
		| Owner's Zip Code                | 29209            |
		| Owner's City                    | Columbia         |
		| Owner's State                   | SC               |
	Then user verifies the appearance of the Decline page

@Declined @CA @Regression @SC
Scenario: CA Waste Disposal Services Declined Scheduling Debit Increase Entering Clients Homes
	Given user starts a quote with:
		| Industry                | Employees | Location                    | Own or Lease                | ZIP Code | LOB |
		| Waste Disposal Services | 0         | I Lease a Space From Others | Vehicles;Tools or Equipment | 29209    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA | Policy Start Date |
		| test             | No  |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1         | Address2 | City     | Select an Address |
		| 2012                  | Corporation             | 806 Universal Dr |          | Columbia |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Haul | Plowing Snow |
		| 1FTFW1E88NFA58133 | South Carolina  | No   | No           |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | Accident | DLNumber  |
		| Test      | Driver   | SC      | 03/13/1986 | No       | 085671243 |
	Then user continues to the Operations page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
		| Do you haul any hazardous waste or hazardous materials?                                     | No               |
		| Do you enter inside customer's homes or buildings to pick up or deliver any items?          | Yes              |
	Then user continues to the Contact page
	And user enters contact information:
		| Question                        | Answer           |
		| First Name                      | Test             |
		| Last Name                       | Driver           |
		| Business Email                  | abc@3212.com     |
		| Business Phone                  | (555) 867-5209   |
		| Business Website                |                  |
		| Business has an account manager |                  |
		| Want Save Money                 | Yes              |
		| Owner's First Name              | Test             |
		| Owner's Last Name               | Owner            |
		| Owner's Address                 | 806 Universal Dr |
		| Owner's Address 2               |                  |
		| Owner's Zip Code                | 29209            |
		| Owner's City                    | Columbia         |
		| Owner's State                   | SC               |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question | Answer |
		| Yearly   | No     |
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
	Then user verifies the Thank You Page