Feature: CA_NewsReporter_I

CA News Reporter issued in Tennessee and purchases a policy successfully

@Issued @Regression @TN @CA @Hospitality
Scenario: CA News Reporter Issued In Tennessee
	Given user starts a quote with:
		| Industry      | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| News Reporter | 2         | I Run My Business From Property I Own | Vehicles     | 37211    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured    | Address1            | Address2 | City      | Select an Address |
		| 1980                  | Individual/Sole Proprietor | 708 Misty Pines Cir |          | Nashville |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 5N1AR18U65C767389 | Tennessee       | 12000         |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber  |
		| Anna      | Kendrick | TN      | 03/13/1986 |     |       |             |             | Yes      | 147849578 |
	Then user clicks continue from the Drivers page
	Then user verifies the appearance of the Drivers Incidents page
	Then user adds incidents with the following values:
		| Driver        | Date       | Incident Type | At Fault |
		| Anna Kendrick | 11/11/2021 | Accident      | No       |
	Then user continues to the Operations page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer                 |
		| First Name                      | Ariana                 |
		| Last Name                       | Grande                 |
		| Business Email                  | chauffeur@yopmail.com  |
		| Business Phone                  | (555) 867-5309         |
		| Business Website                |                        |
		| Business has an account manager |                        |
		| Want Save Money                 | Yes                    |
		| Owner's First Name              | AutoLarryzzzzzzzzzzz   |
		| Owner's Last Name               | AutoBarryzzzzzzzzzzzzz |
		| Owner's Address                 | 1879 Watson Blvd Apt 1 |
		| Owner's Address 2               |                        |
		| Owner's Zip Code                | 31093                  |
		| Owner's City                    | warner robins          |
		| Owner's State                   | Georgia                |
		| Select an Address               | Suggested              |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question           | Answer                                                    |
		| Yearly             | No                                                        |
		| Policy Coverages   | $100,000 Combined Single Limit                            |
		| Vehicle 1 Coverage | $500 Comprehensive Deductible / $500 Collision Deductible |
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
	Then user verifies the Thank You Page
	And user verifies the WC section on the Thank You page