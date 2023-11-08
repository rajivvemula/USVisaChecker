Feature: Generate_CA_Geologist_I

Populate the system with testing data primarily base on most common policy types per book of business.

@Generate @CA
Scenario: Generate CA Geologist successfully purchases a policy for FL
	Given user starts a quote with:
		| Industry  | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Geologist | 2         | I Run My Business From Property I Own | Vehicles     | 33458    | CA  |
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
		| Year Business Started | How Business Structured    | Address1        | Address2 | City    | Select an Address | Mailing Address |
		| 1900                  | Individual/Sole Proprietor | 112 Palomino Dr |          | Jupiter |                   | Yes             |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 3D3KR19D97G838924 | Florida         | 12000         |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address |
		| 5NMZU3LB2JH065041 | Florida         |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth | Commuter |
		| 1FTNE2EW0DDA17671 | Florida         | 10000         | No       |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber      |
		| Chris     | Rock     | FL      | 03/13/1986 |     |       |             |             | No       | G544061459250 |
		| Eric      | Smith    | FL      | 04/01/1988 |     |       |             |             | No       | G544061739250 |
		| Mike      | Jones    | FL      | 09/03/1989 |     |       |             |             | No       | G544061739150 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer                |
		| First Name                      | Steve                 |
		| Last Name                       | Smith                 |
		| Business Email                  | Geologist@yopmail.com |
		| Business Phone                  | (555) 867-5309        |
		| Business Website                |                       |
		| Business has an account manager |                       |
		| Want Save Money                 | Yes                   |
		| Owner's First Name              | OwnerzFirstName       |
		| Owner's Last Name               | OwnerzLastName        |
		| Owner's Address                 | 112 Palomino Dr       |
		| Owner's Address 2               |                       |
		| Owner's Zip Code                | 33458                 |
		| Owner's City                    | Jupiter               |
		| Owner's State                   | Florida               |
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question         | Answer                         |
		| Yearly           | No                             |
		| Policy Coverages | $100,000 Combined Single Limit |
	Then user clicks continue from the Quote page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | Myself            |
		| Yes | Owned | Myself            |
		| Yes | Owned | Myself            |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Card Type |
		| 12 Monthly   | Visa      |
	Then user clicks purchase
	Then user verifies the Thank You Page