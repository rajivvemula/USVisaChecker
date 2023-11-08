Feature: CA_PurchasePageHelpErrorText_U

CA Purchase Page Help Error Text Unit Verification

@Unit @Staging @Regression @SC @CA @Transportation
Scenario: CA Purchase Page Help Error Text Unit
	Given user starts a quote with:
		| Industry        | Employees | Location                    | Own or Lease                | ZIP Code | LOB |
		| Towing Services | 0         | I Lease a Space From Others | Vehicles;Tools or Equipment | 29209    | CA  |
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
		| Year Business Started | How Business Structured | Address1              | Address2 | City     | Select an Address |
		| 2012                  | Corporation             | 7501 Garners Ferry Rd |          | Columbia |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Type Insure                | Parking Address | Vehicle Worth | Auto Repo | Plowing Snow |
		| 1FDJF3717DPB12872 | Tow Truck: Wheel-Lift/Hook | South Carolina  | 2800          | No        | No           |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Plowing Snow |
		| WDDHF7HB0BA270302 | South Carolina  | No           |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber  |
		| Minnie    | Mouse    | SC      | 03/13/1986 | Yes 3 or more years |       |             |             | Yes      | 085671243 |
	Then user clicks continue from the Drivers page
	Then user verifies the appearance of the Drivers Incidents page
	Then user adds incidents with the following values:
		| Driver       | Date       | Incident Type        | At Fault | Violation/Conviction                         | Reckless | Another V/C | Violation/Conviction          | Another V/C | Violation/Conviction | Another V/C |
		| Minnie Mouse | 11/11/2021 | Accident             | No       |                                              |          |             |                               |             |                      |             |
		| Minnie Mouse | 11/12/2021 | Violation/Conviction |          | Speeding 16 MPH or more over the Speed Limit | Yes      | Yes         | Red Light/Stop Sign violation | Yes         | Hit and Run          | No          |
	Then user continues to the Operations page
	Then user fills out the Operations page:
		| Question                                                                                                                                                                   | Answer                                                                     |
		| Do you haul intermodal containers?                                                                                                                                         | No                                                                         |
		| Is your business on call 24/7?                                                                                                                                             | No                                                                         |
		| Does your business also have a repair shop, impound lot, or salvage yard?                                                                                                  | No we only provide towing or roadside assistance services                  |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                                                                                | 50 miles or less                                                           |
		| Do you haul any fine art or jewelry?                                                                                                                                       | No                                                                         |
		| Do you provide residential moving services?                                                                                                                                | No                                                                         |
		| Does your business engage in team driving?                                                                                                                                 | No - one driver per haul                                                   |
		| Do any of your vehicles travel to Mexico?                                                                                                                                  | No                                                                         |
		| How many auto insurance claims did your business file in the last 3 years?                                                                                                 | 0                                                                          |
		| I agree to provide a claims history (also known as a "loss run") that matches the information in this application for the last 3 years within 30 days of {effective date}. | true                                                                       |
		| Do you haul any of these? Check all that apply:                                                                                                                            | Building Materials;Logs (Forestry);Mobile/Manufactured Homes;Sand & Gravel |
		| Do you haul large equipment or machinery requiring chains to secure in transit?                                                                                            | No                                                                         |
		| Do you haul any hazardous materials?                                                                                                                                       | No                                                                         |
		| Do you rent any vehicles?                                                                                                                                                  | No                                                                         |
		| Do you use any Owner-Operators?                                                                                                                                            | No                                                                         |
		| Does your business have a USDOT Number?                                                                                                                                    | No                                                                         |
		| Do you have or plan on applying for an operating authority from a South Carolina state department?                                                                         | Yes                                                                        |
		| Do the owner(s) of this business have a combined majority ownership in any other transportation business?                                                                  | No                                                                         |
	Then user continues to the Contact page
	And user enters contact information:
		| Question                        | Answer           |
		| First Name                      | Ariana           |
		| Last Name                       | Grande           |
		| Business Email                  | a@b.co           |
		| Business Phone                  | (412) 867-5309   |
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
		| Question           | Answer                                                      |
		| Yearly             | Yes                                                         |
		| Policy Coverages   | $100,000 Combined Single Limit                              |
		| Vehicle 1 Coverage | $1000 Comprehensive Deductible / $1000 Collision Deductible |
		| Vehicle 2 Coverage | $500 Comprehensive Deductible / $500 Collision Deductible   |
		| In-Tow             | $100,000 Limit / $1,000 Deductible                          |
	Then user clicks continue from the Quote page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN | OLF      | Who Holds Vehicle |
		| Yes | Owned    | The Business      |
		| Yes | Financed |                   |
	Then user clicks continue from Additional Information
	Then user verifies each error element on the CA purchase page
	Then user verifies each help text element on the CA purchase page