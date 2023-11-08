Feature: CA_Ridesharing_I


@Issued @Regression @MO @CA @Transportation
Scenario: CA Ridesharing Issued In Missouri
	Given user starts a quote with:
		| Industry    | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Ridesharing | 2         | I Run My Business From Property I Own | Vehicles     | 65109    | CA  |
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
		| Year Business Started | How Business Structured | Address1           | Address2 | City           | Select an Address |
		| 2000                  | Corporation             | 1425 Missouri Blvd |          | Jefferson City |                   |
	Then user fills in the alternate mailing address with these values:
		| Address1     | Address2 | Zip   | City     | State    | Select an Address |
		| 1213 Noah Dr | APT 4    | 63052 | Imperial | Missouri | Suggested         |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth | Fare Box |
		| 5N1AR18U65C767389 | Missouri        | 2800          | No       |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Trailer Address | Trailer Worth |
		| 1MT2N5220LH028352 | Missouri        | 3200          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| Daisy     | Duck     | MO      | 03/13/1986 |     |       |             |             | No       |          |
		| Goofy     | Dog      | MO      | 04/01/1986 |     |       |             |             | Yes      |          |
	Then user clicks continue from the Drivers page
	Then user verifies the appearance of the Drivers Incidents page
	Then user adds incidents with the following values:
		| Driver    | Date       | Incident Type        | At Fault | Violation/Conviction         | Describe V/C                   | Another V/C | Violation/Conviction                         | Reckless | Another V/C |
		| Goofy Dog | 02/02/2022 | Accident             | No       |                              |                                |             |                                              |          |             |
		| Goofy Dog | 02/03/2022 | Violation/Conviction |          | Other Minor Moving Violation | I forgot to brake at stop sign | Yes         | Speeding 16 MPH or more over the Speed Limit | No       | No          |
	Then user continues to the Operations page
	Then user fills out the Operations page:
		| Question                                                                                            | Answer          |
		| Do you offer "party" bus or limousine services where alcohol is provided or expressly permitted?    | No              |
		| Do you provide any school, camp, day care, or field trip transportation for children 12 or younger? | No              |
		| What is the furthest any of your vehicles travel in any one direction from their home base?         | 51 to 100 miles |
		| Do any of your vehicles travel to Mexico?                                                           | No              |
		| How many auto insurance claims did your business file in the last 3 years?                          | 0               |
		| Do you rent any vehicles?                                                          | No              |
		| Do you use any Owner-Operators?                                                                     | No              |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer           |
		| First Name                      | Ariana           |
		| Last Name                       | Grande           |
		| Business Email                  | a@b.co           |
		| Business Phone                  | (555) 867-5309   |
		| Business Website                |                  |
		| Business has an account manager |                  |
		| Want Save Money                 | Yes              |
		| Owner's First Name              | Larry            |
		| Owner's Last Name               | Barry            |
		| Owner's Address                 | 2112 S Spring St |
		| Owner's Address 2               |                  |
		| Owner's Zip Code                | 62704            |
		| Owner's City                    | Springfield      |
		| Owner's State                   | IL               |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question             | Answer                                                      |
		| Yearly               | Yes                                                         |
		| Policy Coverages     | $750,000 Combined Single Limit                              |
		| Vehicle 1 Coverage   | $1000 Comprehensive Deductible / $1000 Collision Deductible |
		| Vehicle 2 Coverage   | $500 Comprehensive Deductible / $500 Collision Deductible   |
		| Rental Reimbursement | $30 per day/30 days/$900 total                              |
	Then user clicks continue from the Quote page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | The Business      |
		| Yes | Owned | The Business      |
	Then user clicks continue from Additional Information
    Then user goes to purchase a plan using the following information:
		| Payment Plan | Card Type |
		| 12 Monthly   | Visa      |
	Then user clicks purchase
	Then user verifies the Thank You Page
	And user verifies the WC section on the Thank You page