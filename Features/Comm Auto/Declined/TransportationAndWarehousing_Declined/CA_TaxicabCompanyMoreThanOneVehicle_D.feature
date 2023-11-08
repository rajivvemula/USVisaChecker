Feature: CA_TaxicabCompanyMoreThanOneVehicle_D

Declined due to selecting one of the following FMCSA options: Broker, Freight Forwarding.

Background:
	Given user starts a quote with:
		| Industry                               | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Taxicab company: more than one vehicle | 10        | I Lease a Space From Others | Vehicles     | 77449    | CA  |
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
		| Year Business Started | How Business Structured | Address1            | Address2 | City | Select an Address |
		| 2012                  | Corporation             | 18942 Sandelford Dr |          | Katy |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Type Insure                     | Parking Address | Vehicle Worth | Fare Box | Seatbelt |
		| 2L1MJ5LK0FBL00196 | Limousine: seating less than 10 | Texas           | 1500          | Yes      | Yes      |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| Chuck     | Norris   | TX      | 03/13/1988 |     |       |             |             | No       | 02938544 |
	Then user clicks continue from the Drivers page

@Transportation @Declined @Regression @TX @CA @FMCSA
Scenario: CA Taxi Cab Company More Than One Vehicle Declined FMCSA Broker
	Then user fills out the Operations page:
		| Question                                                                                                                 | Answer          |
		| Do you offer "party" bus or limousine services where alcohol is provided or expressly permitted?                         | No              |
		| Do you provide any school, camp, day care, or field trip transportation for children 12 or younger?                      | No              |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                              | 51 to 100 miles |
		| Do any of your vehicles travel to Mexico?                                                                                | No              |
		| How many auto insurance claims did your business file in the last 3 years?                                               | 0               |
		| Do you rent any vehicles?                                                                                                | No              |
		| Do you use any Owner-Operators?                                                                                          | No              |
		| Does your business have a USDOT Number?                                                                                  | Yes             |
		| Enter the USDOT number                                                                                                   | 355352          |
		| Do you have or plan on applying for an operating authority from the Federal Motor Carrier Safety Administration (FMCSA)? | Yes             |
		| Do the owner(s) of this business have a combined majority ownership in any other transportation business?                | No              |
		| Which types of authority from FMCSA do you have or plan on having?                                                       | Broker          |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer              |
		| First Name                      | Larry               |
		| Last Name                       | Barry               |
		| Business Email                  | a@b.com             |
		| Business Phone                  | 5558675309          |
		| Business Website                |                     |
		| Business has an account manager |                     |
		| Want Save Money                 | Yes                 |
		| Owner's First Name              | Larry               |
		| Owner's Last Name               | Barry               |
		| Owner's Address                 | 18942 Sandelford Dr |
		| Owner's Address 2               |                     |
		| Owner's Zip Code                | 77449               |
		| Owner's City                    | Katy                |
		| Owner's State                   | Texas               |
	Then user verifies the appearance of the Decline page

@Transportation @Declined @Regression @TX @CA @FMCSA
Scenario: CA Taxi Cab Company More Than One Vehicle Declined FMCSA Freight Forwarding
	Then user fills out the Operations page:
		| Question                                                                                                                 | Answer             |
		| Do you offer "party" bus or limousine services where alcohol is provided or expressly permitted?                         | No                 |
		| Do you provide any school, camp, day care, or field trip transportation for children 12 or younger?                      | No                 |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                              | 51 to 100 miles    |
		| Do any of your vehicles travel to Mexico?                                                                                | No                 |
		| How many auto insurance claims did your business file in the last 3 years?                                               | 0                  |
		| Do you rent any vehicles?                                                                                                | No                 |
		| Do you use any Owner-Operators?                                                                                          | No                 |
		| Does your business have a USDOT Number?                                                                                  | Yes                |
		| Enter the USDOT number                                                                                                   | 355352             |
		| Do you have or plan on applying for an operating authority from the Federal Motor Carrier Safety Administration (FMCSA)? | Yes                |
		| Which types of authority from FMCSA do you have or plan on having?                                                       | Freight Forwarding |
		| Do the owner(s) of this business have a combined majority ownership in any other transportation business?                | Yes                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer              |
		| First Name                      | Larry               |
		| Last Name                       | Barry               |
		| Business Email                  | a@b.com             |
		| Business Phone                  | 5558675309          |
		| Business Website                |                     |
		| Business has an account manager |                     |
		| Want Save Money                 | Yes                 |
		| Owner's First Name              | Larry               |
		| Owner's Last Name               | Barry               |
		| Owner's Address                 | 18942 Sandelford Dr |
		| Owner's Address 2               |                     |
		| Owner's Zip Code                | 77449               |
		| Owner's City                    | Katy                |
		| Owner's State                   | Texas               |
	Then user verifies the appearance of the Decline page