Feature: CA_ActuarialConsulting_I

Verify that autopay toggle is not on the Purchase Page because the cost of the policy is less than $1,000.
They will see a statement saying they are automatically enrolled in autopay.
Wisconsin - Optional credit check - choose NO, then go back and choose YES
Ohio - Optional credit check - choose NO, then go back and choose YES

@Issued @Regression @Staging @WI @CA @Service
Scenario: CA Actuarial Consulting Issued In Wisconsin
	Given user starts a quote with:
		| Industry             | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Actuarial Consulting | 0         | I Lease a Space From Others | Vehicles     | 54311    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA      | Policy Start Date |
		| Test wisconsin   | TEST DBA |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured     | Address1            | Address2 | City      | Select an Address |
		| 2015                  | Limited Liability Co. (LLC) | 2535 Wildflower Row |          | Green Bay |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 2HGCA5534HH007097 | Wisconsin       | 1000          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber       |
		| TestF     | TestL    | WI      | 09/01/1991 |     |       |             |             | No       | W1234567890123 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question         | Answer                  |
		| First Name       | TestF                   |
		| Last Name        | TestL                   |
		| Business Email   | QAAutomation@biberk.com |
		| Business Phone   | (123) 123-1321          |
		| Business Website | test.com                |
		| Want Save Money  | No                      |
	Then user verifies landing on Summary page
	Then user clicks back from the Summary page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question           | Answer              |
		| Want Save Money    | Yes                 |
		| Owner's First Name | TestF               |
		| Owner's Last Name  | TestL               |
		| Owner's Address    | 2535 Wildflower Row |
		| Owner's Address 2  |                     |
		| Owner's Zip Code   | 54311               |
		| Owner's City       | Green Bay           |
		| Owner's State      | Wisconsin           |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question           | Answer                                                    |
		| Yearly             | No                                                        |
		| Policy Coverages   | $300,000 Combined Single Limit                            |
		| Vehicle 1 Coverage | $500 Comprehensive Deductible / $500 Collision Deductible |
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
	And user verifies the PL section on the Thank You page


@Issued @Regression @Staging @OH @CA @Service
Scenario: CA Actuarial Consulting Issued In Ohio
	Given user starts a quote with:
		| Industry             | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Actuarial Consulting | 0         | I Lease a Space From Others | Vehicles     | 43614    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA      | Policy Start Date |
		| Test Ohio        | TEST DBA |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured     | Address1          | Address2 | City   | Select an Address |
		| 2015                  | Limited Liability Co. (LLC) | 3025 Glendale Ave |          | Toledo |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 2HGCA5534HH007097 | Ohio            | 1000          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| TestF     | TestL    | OH      | 09/01/1991 |     |       |             |             | No       | OH123456 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question         | Answer                  |
		| First Name       | TestF                   |
		| Last Name        | TestL                   |
		| Business Email   | QAAutomation@biberk.com |
		| Business Phone   | (123) 123-1321          |
		| Business Website | test.com                |
		| Want Save Money  | No                      |
	Then user verifies landing on Summary page
	Then user clicks back from the Summary page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question           | Answer            |
		| Want Save Money    | Yes               |
		| Owner's First Name | TestF             |
		| Owner's Last Name  | TestL             |
		| Owner's Address    | 3025 Glendale Ave |
		| Owner's Address 2  |                   |
		| Owner's Zip Code   | 43614             |
		| Owner's City       | Toledo            |
		| Owner's State      | Ohio              |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question           | Answer                                                    |
		| Yearly             | No                                                        |
		| Policy Coverages   | $300,000 Combined Single Limit                            |
		| Vehicle 1 Coverage | $500 Comprehensive Deductible / $500 Collision Deductible |
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
	And user verifies the PL section on the Thank You page


@Issued @Regression @Staging @IL @CA @Service
Scenario: CA Actuarial Consulting Issued In Illinois With Mandatory Autopay
	Given user starts a quote with:
		| Industry             | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Actuarial Consulting | 0         | I Lease a Space From Others | Vehicles     | 46001    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA      | Policy Start Date |
		| Test CA          | Test DBA |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1            | Address2 | City       | Select an Address |
		| 2000                  | Corporation             | 402 E Washington St |          | Alexandria |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 2HGCA5534HH007097 | Indiana         | 20            |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber   |
		| TestF     | TestL    | IN      | 09/01/1991 |     |       |             |             | No       | 1523456985 |
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
		| Business Website                | test.com                |
		| Business has an account manager |                         |
		| Manager's First Name            |                         |
		| Manager's Last Name             |                         |
		| Manager's Email                 |                         |
		| Manager's Phone                 |                         |
		| Want Save Money                 | Yes                     |
		| Owner's First Name              | TestF                   |
		| Owner's Last Name               | TestL                   |
		| Owner's Address                 | 402 E Washington St     |
		| Owner's Address 2               |                         |
		| Owner's Zip Code                | 46001                   |
		| Owner's City                    | Alexandria              |
		| Owner's State                   | Indiana                 |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question           | Answer                         |
		| Yearly             |                                |
		| Policy Coverages   | $100,000 Combined Single Limit |
		| Vehicle 1 Coverage | No Physical Damage Coverage    |
	Then user verifies the current price is less than $1,000
	Then user clicks continue from the Quote page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | The Business      |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Card Type | Autopay  |
		| 12 Monthly   | Visa      | Required |
	Then user clicks purchase
	Then user verifies the Thank You Page
	And user verifies the PL section on the Thank You page
	And user verifies the BOP section on the Thank You page