Feature: CA_FurnitureMovingAndStorage_I
Checks question "What is the furthest any of your vehicles travel in any one direction from their home base?" for 
vehicle code 520
#@Unit @CA @FL
Scenario: CA Furniture Moving And Storage Issued In Florida
	Given user starts a quote with:
		| Industry                     | Employees | Location                              | Own or Lease                | ZIP Code | LOB |
		| Furniture Moving and Storage | 2         | I Run My Business From Property I Own | Vehicles;Inventory or Stock | 33065    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
    Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1             | Address2 | City          | Select an Address |
        | 2019                  | Corporation             | 2700 Riverside Dr    |          | Coral Springs |                   |
	Then user clicks continue from CA Introduction
    Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth | 
		| 1FMPU13505LB12332 | Florida           | 2800          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB      | CDL                 | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber      |
		| First     | Laasr    | FL      | 01011988 | Yes 3 or more years |       |             |             | No       | C101010101010 |
	Then user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer                   |
		| Do you haul intermodal containers?                                                          | No                       |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less         |
		| Do you haul any fine art or jewelry?                                                        | No                       |
		| Do you provide residential moving services?                                                 | No                       |
		| Does your business engage in team driving?                                                  | No - one driver per haul |
		| Do any of your vehicles travel to Mexico?                                                   | No                       |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                        |
		| What services do you provide?                                                               | Moving Services Only     |
		| Do you haul large equipment or machinery requiring chains to secure in transit?             | No                       |
		| Do you haul any hazardous materials?                                                        | No                       |
		| Do you rent any vehicles?                                                  | No                       |
		| Do you use any Owner-Operators?                                                             | No                       |
		| Does your business have a USDOT Number?                                                     | No                       |
		Then user continues to the Contact page
