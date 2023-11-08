Feature: CA_StepperVerification_U
Verify the appearance of the stepper as you progress through the Commercial Auto path.

@Unit @CA
Scenario: CA Stepper Verification Unit Amazon Delivery Service
	Given user starts a quote with:
		| Industry                | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Amazon Delivery Service | 0         | I Run My Business From Property I Own | Vehicles     | 60606    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	Then user checks the stepper appearance on the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1       | Address2 | City    | Select an Address |
		| 2012                  | Corporation             | 225 S Canal St |          | Chicago |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	Then user checks the stepper appearance on the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address |
		| 4S4BRBCC1C3234145 | Illinois        |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	Then user checks the stepper appearance on the Drivers page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber     |
		| Donald    | Duck     | IL      | 03/13/1986 | Yes 3 or more years |       |             |             | Yes      | t74185296394 |
	Then user clicks continue from the Drivers page
	Then user verifies the appearance of the Drivers Incidents page
	Then user adds incidents with the following values:
		| Driver      | Date       | Incident Type | At Fault |
		| Donald Duck | 11/11/2021 | Accident      | No       |
	Then user checks the stepper appearance on the Driver Incidents page
	Then user continues to the Operations page
	Then user fills out the Operations page:
		| Question                                                                                          | Answer                   |
		| Do you haul intermodal containers?                                                                | No                       |
		| What is the furthest any of your vehicles travel in any one direction from their home base?       | 50 miles or less         |
		| Do you haul any fine art or jewelry?                                                              | No                       |
		| Do you provide residential moving services?                                                       | No                       |
		| Does your business engage in team driving?                                                        | No - one driver per haul |
		| Do any of your vehicles travel to Mexico?                                                         | No                       |
		| How many auto insurance claims did your business file in the last 3 years?                        | 0                        |
		| Do you haul any of these? Check all that apply:                                                   |                          |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                   | No                       |
		| Do you haul any hazardous materials?                                                              | No                       |
		| Do you participate in a delivery service on behalf of Amazon.com, Inc.?                           | No                       |
		| Do you rent any vehicles?                                                                         | No                       |
		| Do you use any Owner-Operators?                                                                   | No                       |
		| Does your business have a USDOT Number?                                                           | No                       |
		| Do you have or plan on applying for an operating authority from the Illinois Commerce Commission? | No                       |
	Then user checks the stepper appearance on the Operations page
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	Then user checks the stepper appearance on the Contact Details page
	And user enters contact information:
		| Question                        | Answer           |
		| First Name                      | Ariana           |
		| Last Name                       | Grande           |
		| Business Email                  | a@b.co           |
		| Business Phone                  | (555) 867-5309   |
		| Business Website                |                  |
		| Business has an account manager |                  |
		| Want Save Money                 | Yes              |
		| Owner's First Name              | Larryzzzzz       |
		| Owner's Last Name               | Barryzzzz        |
		| Owner's Address                 | 2112 S Spring St |
		| Owner's Address 2               |                  |
		| Owner's Zip Code                | 62704            |
		| Owner's City                    | Springfield      |
		| Owner's State                   | IL               |
	Then user verifies the appearance of the Summary page
	Then user checks the stepper appearance on the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	Then user checks the stepper appearance on the Your Quote page