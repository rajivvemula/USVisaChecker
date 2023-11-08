Feature: CA_DeliveryCourierService_I


@Issued @Regression @NV @CA @Transportation
Scenario: CA Delivery Courier Service Issued In Nevada
	Given user starts a quote with:
		| Industry                  | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Delivery: Courier Service | 3         | I Work at a Job Site | Vehicles     | 89119    | CA  |
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
		| Year Business Started | How Business Structured | Address1           | Address2 | City     | Select an Address |
		| 2000                  | Corporation             | 7777 E Flamingo Rd |          | Paradise | Original          |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address |
		| 3N1AB6AP9CL760256 | Nevada          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber     |
		| TEST FN   | TEST LN  | NV      | 08/08/1988 | Yes 3 or more years |       |             |             | No       | 097584622088 |
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
		| Owner's Zip Code                | 89119                   |
		| Owner's City                    | Paradise                |
		| Owner's State                   | Nevada                  |
		| Select an Address               | Original                |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question           | Answer                                                                                       |
		| Yearly             | No                                                                                           |
		| Policy Coverages   | Bodily Injury: $25,000 per person/$50,000 per accident/Property Damage: $20,000 per accident |
		| Policy Medical     | $5,000                                                                                       |
		| Vehicle 1 Coverage | $500 Comprehensive Deductible / $500 Collision Deductible                                    |
		| Cargo Liability    | $100,000 Limit / $1,000 Deductible                                                           |
	Then user verifies proposal email modal
		| Question                                    | Answer |
		| Bodily Injury and Property Damage Liability | Yes    |
		| Cargo Liability                             | Yes    |
		| Medical Payments                            | Yes    |
		| Comp/Collision-ACV (One Vehicle)            | Yes    |
		| Uninsured/Underinsured Motorist             | Yes    |
		| Rental Reimbursement                        | No     |
	#Then user verifies the Quote Details
	#| Coverages Not Selected |
	#| Rental                 |
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
	And user verifies the WC section on the Thank You page
