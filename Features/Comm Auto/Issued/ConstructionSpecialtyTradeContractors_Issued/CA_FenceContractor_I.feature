Feature: CA_FenceContractor_I

Issuing a CA policy for a not For-hire trucking industry keyword in accordance with new DMV rules for California. 
In this scenario the question "Do you have or plan on applying for an operating authority from the California Department of Motor Vehicles?" 
should appear on Your operations page for a vehicle with gross weight higher than 10,000 lbs

@Issued @Regression @Cali @CA @Construction
Scenario: CA policy for a Fence Contractor issued in California according to new DMV rules
	Given user starts a quote with:
		| Industry         | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Fence Contractor | 3         | I Run My Business From Property I Own | Vehicles     | 90012    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1      | Address2 | City        | Select an Address |
		| 2020                  | Corporation             | 100 S Main St |          | Los Angeles |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| No VIN            | Type Insure | Year | Make | Model | Parking Address | Gross Weight    | Vehicle Worth | Plowing Snow |
		| WBAVD33536KV61628 | Cargo Van   | 2020 | RAM  | 1500  | California      | 10001-15000 lbs | 25000         | No           |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| Mickey    | Mouse    | CA      | 03/13/1985 |     |       |             |             | No       | c0123456 |
	Then user clicks Let's Continue
	Then user fills out the Operations page:
		| Question                                                                                                     | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                  | 50 miles or less |
		| Do you have or plan on applying for an operating authority from the California Department of Motor Vehicles? | No               |
		| How many auto insurance claims did your business file in the last 3 years?                                   | 0                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer         |
		| First Name                      | OneF           |
		| Last Name                       | OneL           |
		| Business Email                  | test@this.com  |
		| Business Phone                  | (555) 867-5309 |
		| Business Website                |                |
		| Business has an account manager |                |
		| Owner's First Name              | OwnerF         |
		| Owner's Last Name               | OwnerL         |
		| Owner's Address                 | 123 S Main St  |
		| Owner's Address 2               |                |
		| Owner's Zip Code                | 90012          |
		| Owner's City                    | Los Angeles    |
		| Owner's State                   | California     |
		| Select an Address               | Suggested      |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question           | Answer                                                      |
		| Yearly             | No                                                          |
		| Policy Coverages   | $300,000 Combined Single Limit                              |
		| Vehicle 1 Coverage | $1000 Comprehensive Deductible / $1000 Collision Deductible |
	Then user clicks continue from the Quote page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN               | OLF   | Who Holds Vehicle |
		| WBAVD33536KV61628 | Owned | The Business      |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Card Type |
		| 12 Monthly   | Visa      |
	Then user clicks purchase
	Then user verifies the Thank You Page
	And user verifies the WC section on the Thank You page
