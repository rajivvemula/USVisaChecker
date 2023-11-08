Feature: CA_UberDriver_R
Policy gets referred due to the reason Vehicle has 16 or more seats

@Referred @CA @Regression @IL @Transportation
Scenario: CA Uber Driver Referred In Illinois
	Given user starts a quote with:
		| Industry    | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Uber Driver | 2         | I Run My Business From Property I Own |              | 62704    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA    | Policy Start Date |
		|                  | Random |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1         | Address2 | City        | Select an Address |
		| 2012                  | Corporation             | 2112 S Spring St |          | Springfield |                   |
	And user fills in the alternate mailing address with these values:
		| Address1       | Address2 | Zip   | City    | State    | Select an Address |
		| 225 S canal St |          | 60606 | Chicago | Illinois | Suggested         |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| No VIN            | Type Insure | Year | Make   | Model  | Parking Address | Vehicle Worth | Fare Box |
		| 1N4AL3A94DC145157 | Car - Sedan | 2013 | NISSAN | ALTIMA | Illinois        | 2000          | No       |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Type Insure | Parking Address | Vehicle Worth | Fare Box | Passengers Seat |
		| 1FDEE3FS1GDC33319 | Bus         | Illinois        | 3000          | No       | 21 - 40         |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                  | Accident | DLNumber     |
		| Aubrey    | Plaza    | IL      | 03/13/1985 | Yes 3 or more years  | No       | a01234567890 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                                  | Answer          |
		| Do you offer "party" bus or limousine services where alcohol is provided or expressly permitted?          | No              |
		| Do you provide any school, camp, day care, or field trip transportation for children 12 or younger?       | No              |
		| What is the furthest any of your vehicles travel in any one direction from their home base?               | 51 to 100 miles |
		| Do any of your vehicles travel to Mexico?                                                                 | No              |
		| How many auto insurance claims did your business file in the last 3 years?                                | 0               |
		| Do you rent any vehicles?                                                                                 | No              |
		| Do you use any Owner-Operators?                                                                           | No              |
		| Does your business have a USDOT Number?                                                                   | No              |
		| Do you have or plan on applying for an operating authority from the Illinois Commerce Commission?         | Yes             |
		| Do the owner(s) of this business have a combined majority ownership in any other transportation business? | No              |
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
		| Manager's First Name            |                  |
		| Manager's Last Name             |                  |
		| Manager's Email                 |                  |
		| Manager's Phone                 |                  |
		| Want Save Money                 | Yes              |
		| Owner's First Name              | Larry            |
		| Owner's Last Name               | Barry            |
		| Owner's Address                 | 2112 S Spring St |
		| Owner's Address 2               |                  |
		| Owner's Zip Code                | 62704            |
		| Owner's City                    | Springfield      |
		| Owner's State                   | Illinois         |
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN               | OLF   | Who Holds Vehicle |
		| 1N4AL3A94DC145157 | Owned | The Business      |
		| Yes               | Owned | The Business      |
	Then user clicks continue from Additional Information
	And user verifies the CA refer confirmation appearance