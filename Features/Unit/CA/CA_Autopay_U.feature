Feature: CA_Autopay_U


@Unit @CA
Scenario: CA Autopay Unit Required For Monthly Less Than $1k Total
	Given user starts a quote with:
		| Industry  | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Hat Store | 0         | I Lease a Space From Others | Vehicles     | 46750    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		| Forced Autopay   |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1         | Address2 | City       | Select an Address |
		| 2020                  | Corporation             | 1746 College Ave |          | Huntington |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth | How Used                            | Deliver Goods |
		| KNDUP131046570381 | Indiana         | 100           | Errands only - no Delivery/Catering | No            |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | Accident | DLNumber  |
		| Forced    | Autopay  | IN      | 04/11/1981 | No       | 152365987 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| Do you haul any non-owned goods for pay?                                                    | No               |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer                    |
		| First Name                      | Forcedzzzzzzzzz           |
		| Last Name                       | Autopayzzzz               |
		| Business Email                  | forcedautopay@yopmail.com |
		| Business Phone                  | (657) 478-4378            |
		| Business Website                |                           |
		| Business has an account manager |                           |
		| Want Save Money                 | Yes                       |
		| Owner's First Name              | Forcedzzzzzzzzz           |
		| Owner's Last Name               | Forcedzzzzzzzzz           |
		| Owner's Address                 | 368 Harbison Blvd         |
		| Owner's Address 2               |                           |
		| Owner's Zip Code                | 29212                     |
		| Owner's City                    | Columbia                  |
		| Owner's State                   | SC                        |
	Then user verifies landing on Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question           | Answer                                                      |
		| Yearly             | No                                                          |
		| Policy Coverages   | $100,000 Combined Single Limit                              |
		| Vehicle 1 Coverage | $1000 Comprehensive Deductible / $1000 Collision Deductible |
	Then user clicks continue from the Quote page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | The Business      |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Autopay  |
		| 12 Monthly   | Required |



@Unit @CA
Scenario: CA Autopay Unit Optional For Monthly More Than $1k Total
	Given user starts a quote with:
		| Industry   | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Hair Salon | 0         | I Lease a Space From Others | Vehicles     | 60606    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		| Optional Autopay |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1       | Address2 | City    | Select an Address |
		| 2000                  | Corporation             | 225 S Canal St |          | Chicago |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth | How Used                            | Deliver Goods |
		| SCBBB6ZGXMC085104 | Illinois        | 500           | Errands only - no Delivery/Catering | No            |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | Accident | DLNumber     |
		| Optional  | Autopay  | IL      | 04/11/1981 | No       | y78965982544 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| Do you haul any non-owned goods for pay?                                                    | No               |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer                    |
		| First Name                      | Optionalzzzzzzzzz         |
		| Last Name                       | Autopayzzzz               |
		| Business Email                  | forcedautopay@yopmail.com |
		| Business Phone                  | (657) 478-4378            |
		| Business Website                |                           |
		| Business has an account manager |                           |
		| Want Save Money                 | Yes                       |
		| Owner's First Name              | Optionalzzzzzzzzz         |
		| Owner's Last Name               | Autopayzzzzzzzzz          |
		| Owner's Address                 | 225 S Canal St            |
		| Owner's Address 2               |                           |
		| Owner's Zip Code                | 60606                     |
		| Owner's City                    | Chicago                   |
		| Owner's State                   | IL                        |
	Then user verifies landing on Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question             | Answer                                                    |
		| Yearly               | No                                                        |
		| Policy Coverages     | $2,000,000 Combined Single Limit                          |
		| Vehicle 1 Coverage   | $500 Comprehensive Deductible / $500 Collision Deductible |
		| Medical Payments     | $500                                                      |
		| Rental Reimbursement | $30 per day/60 days/$1800 total                           |
	Then user clicks continue from the Quote page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | The Business      |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Autopay            |
		| 12 Monthly   | Optional Choose On |