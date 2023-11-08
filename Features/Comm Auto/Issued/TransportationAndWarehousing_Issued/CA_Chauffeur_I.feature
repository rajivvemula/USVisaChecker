Feature: CA_Chauffeur_I


@Issued @Regression @IN @CA @Transportation
Scenario: CA Chauffeur Issued In Indiana
	Given user starts a quote with:
		| Industry  | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Chauffeur | 2         | I Run My Business From Property I Own | Vehicles     | 46260    | CA  |
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
		| Year Business Started | How Business Structured    | Address1          | Address2     | City         | Select an Address |
		| 1900                  | Individual/Sole Proprietor | 2085 Waterford Pl | APT 7158-619 | Indianapolis | Original          |
	Then user fills in the alternate mailing address with these values:
		| Address1                       | Address2 | Zip   | City         | State   | Select an Address |
		| 2085 Waterford Pl Apt 7108-808 |          | 46260 | Indianapolis | Indiana |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| No VIN            | Type Insure | Year | Make        | No Model | Parking Address | Vehicle Worth |
		| ZHWEB3ZD5FLA03002 | Car - Coupe | 2015 | LAMBORGHINI | Veneno   | Indiana         | 12000         |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| No VIN            | Type Insure     | Year | Make                   | Enter Year Make Model | Trailer Address | Trailer Worth |
		| 2TLSBES87NB000753 | Dry Van Trailer | 2020 | BIG TEX TRAILER CO INC |                       | Indiana         | 2800          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber  |
		| Donald    | Duck     | GA      | 03/13/1986 |     |       |             |             | No       | 147849578 |
		| Goofy     | Woofy    | IN      | 04/01/1988 |     |       |             |             | No       |           |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                            | Answer                          |
		| Do you provide any school, camp, day care, or field trip transportation for children 12 or younger? | No                              |
		| Do you offer "party" bus or limousine services where alcohol is provided or expressly permitted?    | No                              |
		| How many auto insurance claims did your business file in the last 3 years?                          | 0                               |
		| Do any of your vehicles travel to Mexico?                                                           | No                              |
		| How do your passengers access your services?                                                        | Both on demand and pre-arranged |
		| What is the furthest any of your vehicles travel in any one direction from their home base?         | 50 miles or less                |
		| Do you rent any vehicles?                                                                           | No                              |
		| Do you use any Owner-Operators?                                                                     | No                              |
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
		| Owner's City                    | Warner Robins          |
		| Owner's State                   | Georgia                |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question           | Answer                                                      |
		| Yearly             | No                                                          |
		| Policy Coverages   | $100,000 Combined Single Limit                              |
		| Vehicle 1 Coverage | $1000 Comprehensive Deductible / $1000 Collision Deductible |
		| Vehicle 2 Coverage | $500 Comprehensive Deductible / $500 Collision Deductible   |
	Then user clicks continue from the Quote page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN               | OLF   | Who Holds Vehicle |
		| ZHWEB3ZD5FLA03002 | Owned | Myself            |
		| 2TLSBES87NB000753 | Owned | Myself            |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Card Type |
		| 12 Monthly   | Visa      |
	Then user clicks purchase
	Then user verifies the Thank You Page
	And user verifies the WC section on the Thank You page