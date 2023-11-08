Feature: CA_ScenicAndSightseeingTransportation_R

verify the new refferal reason due to US 38007
Referral reason : "Initial Premium over $70,000"
If the cost is under $70k and add vehicle/driver makes it go over - it WILL refer.
Initial premium is less than $70k, however material changes (adding vehicles or drivers) are made bumping premium >= $70k----> Refer

@CA @Regression @Transportation @Referred @TX
Scenario: CA Scenic And Sightseeing Transportation Referred Over 70k
	Given user starts a quote with:
		| Industry                              | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Scenic and Sightseeing Transportation | 2         | I Lease a Space From Others | Vehicles     | 76226    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business            | DBA | Policy Start Date |
		| ScenicSights Transportation |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured     | Address1         | Address2 | City   |
		| 2005                  | Limited Liability Co. (LLC) | 2516 Basswood Dr |          | Argyle |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Trailer Address | Trailer Worth |
		| 13N14830731017973 | Texas           | 76000         |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | Accident | DLNumber |
		| TEST FN   | TEST LN  | TX      | 09/03/1989 | No       | 01234568 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                            | Answer          |
		| Do you offer "party" bus or limousine services where alcohol is provided or expressly permitted?    | No              |
		| Do you provide any school, camp, day care, or field trip transportation for children 12 or younger? | No              |
		| What is the furthest any of your vehicles travel in any one direction from their home base?         | 51 to 100 miles |
		| Do any of your vehicles travel to Mexico?                                                           | No              |
		| How many auto insurance claims did your business file in the last 3 years?                          | 5               |
		| Do you rent any vehicles?                                                                           | No              |
		| Do you use any Owner-Operators?                                                                     | No              |
	Then user continues to the Contact page
	And user enters contact information:
		| Question                        | Answer                |
		| First Name                      | TEST CFN              |
		| Last Name                       | TEST CLN              |
		| Business Email                  | ydwsaiq6wtn@vddaz.com |
		| Business Phone                  | (123) 555-5678        |
		| Business Website                |                       |
		| Business has an account manager |                       |
		| Want Save Money                 | Yes                   |
		| Owner's First Name              | TEST FN               |
		| Owner's Last Name               | TEST LN               |
		| Owner's Address                 | 7424 W Flint St       |
		| Owner's Address 2               |                       |
		| Owner's Zip Code                | 65802                 |
		| Owner's City                    | Springfield           |
		| Owner's State                   | Missouri              |
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF   | Who Holds Vehicle |
		| Yes | Owned | The Business      |
	Then user clicks continue from Additional Information
	And user verifies the CA refer confirmation appearance