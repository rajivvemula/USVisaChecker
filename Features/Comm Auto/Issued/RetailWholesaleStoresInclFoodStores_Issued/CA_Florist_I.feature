Feature: CA_Florist_I

Testing the Save for Later modal as well as completing a Illinois run.

@Issued @Regression @IL @CA @Retail
Scenario: CA Florist Issued In Illinois
	Given user starts a quote with:
		| Industry | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Florist  | 5         | I Own a Property & Lease to Others | Vehicles     | 60007    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business   | DBA | Policy Start Date |
		| TEST CA AUTH QUOTE |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured    | Address1                   | Address2 | City              | Select an Address |
		| 2005                  | Individual/Sole Proprietor | 175 N Arlington Heights Rd |          | Elk Grove Village |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | How Used                            | Deliver Goods |
		| 4T1G11AK3NU618541 | Illinois        | Errands only - no Delivery/Catering | No            |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | Accident | DLNumber     |
		| TEST FN   | TEST LN  | IL      | 04/11/1981 | No       | x12345678901 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer                     |
		| First Name                      | TEST FN                    |
		| Last Name                       | TEST LN                    |
		| Business Email                  | QAAutomation@biberk.com    |
		| Business Phone                  | (657) 478-4378             |
		| Business Website                |                            |
		| Business has an account manager |                            |
		| Want Save Money                 | Yes                        |
		| Owner's First Name              | TEST FN                    |
		| Owner's Last Name               | TEST LN                    |
		| Owner's Address                 | 175 N Arlington Heights Rd |
		| Owner's Address 2               |                            |
		| Owner's Zip Code                | 60007                      |
		| Owner's City                    | Elk Grove Village          |
		| Owner's State                   | IL                         |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question           | Answer                                                    |
		| Yearly             | Yes                                                       |
		| Policy Coverages   | $100,000 Combined Single Limit                            |
		| Vehicle 1 Coverage | $500 Comprehensive Deductible / $500 Collision Deductible |
	Then user verifies proposal email modal
		| Question                                    | Answer |
		| Bodily Injury and Property Damage Liability | Yes    |
		| Uninsured/Underinsured Motorist             | Yes    |
		| Comp/Collision (One Vehicle)                | Yes    |
		| Medical Payments                            | No     |
		| Rental Reimbursement                        | No     |
	Then user clicks continue from the Quote page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | Myself            |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Card Type |
		| 12 Monthly   | Visa      |
	Then user clicks purchase


@Florist @Issued @Regression @IL @CA @Retail @Staging
Scenario: CA Florist Issued In Illinois With Optional Autopay
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 0         | I Lease a Space From Others | Vehicles     | 60101    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA      | Policy Start Date |
		| TEST CA          | TEST DBA |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured     | Address1      | Address2 | City    | Select an Address |
		| 2015                  | Limited Liability Co. (LLC) | 233 N Mill Rd |          | Addison |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth | How Used          | Deliver Goods |
		| 3VWCA21C9XM407107 | Illinois        | 3000          | Delivery/Catering | Yes           |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | Accident | DLNumber     |
		| TestF     | TestL    | IL      | 09/01/1991 | No       | H11112222333 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer                  |
		| First Name                      | TestF                   |
		| Last Name                       | TestL                   |
		| Business Email                  | qaautomation@biberk.com |
		| Business Phone                  | (123) 123-1321          |
		| Business Website                |                         |
		| Business has an account manager |                         |
		| Want Save Money                 | Yes                     |
		| Owner's First Name              | TestF                   |
		| Owner's Last Name               | TestL                   |
		| Owner's Address                 | 530 W Stevens Dr        |
		| Owner's Address 2               |                         |
		| Owner's Zip Code                | 60101                   |
		| Owner's City                    | Addison                 |
		| Owner's State                   | Illinois                |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question           | Answer                                                    |
		| Yearly             | No                                                        |
		| Policy Coverages   | $100,000 Combined Single Limit                            |
		| Vehicle 1 Coverage | $500 Comprehensive Deductible / $500 Collision Deductible |
	Then user verifies the current price is more than $1,000
	Then user clicks continue from the Quote page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | The Business      |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Card Type | Autopay            |
		| 12 Monthly   | Visa      | Optional Choose On |
	Then user clicks purchase
	Then user verifies the Thank You Page
	And user verifies the BOP section on the Thank You page