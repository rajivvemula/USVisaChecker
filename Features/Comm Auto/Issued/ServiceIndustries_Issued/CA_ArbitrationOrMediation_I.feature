Feature: CA_ArbitrationOrMediation_I


@Issued @Regression @NV @CA @Service
Scenario: CA Arbitration Or Mediation Issued In Nevada
	Given user starts a quote with:
		| Industry                 | Employees | Location                         | Client Home | Own or Lease | ZIP Code | LOB |
		| Arbitration or Mediation | 3         | I Run My Business Out of My Home | No          | Vehicles     | 89109    | CA  |
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
		| Year Business Started | How Business Structured | Address1        | Address2 | City      | Select an Address |
		| 1999                  | Partnership             | 333 Celeste Ave |          | Las Vegas | Original          |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address |
		| 1FMCU02Z58KA43824 | Nevada          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber     |
		| TEST FN   | TEST LN  | NV      | 09/01/1991 |     |       |             |             | No       | 123456789091 |
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
		| Owner's Address                 | 33 Celeste Ave          |
		| Owner's Address 2               |                         |
		| Owner's Zip Code                | 89109                   |
		| Owner's City                    | Las Vegas               |
		| Owner's State                   | Nevada                  |
		| Select an Address               | Original                |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question           | Answer                                                    |
		| Yearly             | No                                                        |
		| Policy Coverages   | $300,000 Combined Single Limit                            |
		| Vehicle 1 Coverage | $500 Comprehensive Deductible / $500 Collision Deductible |
		| Policy Medical     | $2,000                                                    |
	Then user verifies proposal email modal
		| Question                                    | Answer |
		| Bodily Injury and Property Damage Liability | Yes    |
		| Medical Payments                            | Yes    |
		| Comp/Collision-ACV (One Vehicle)            | Yes    |
		| Uninsured/Underinsured Motorist             | Yes    |
		| Rental Reimbursement                        | No     |
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
	And user verifies the PL section on the Thank You page