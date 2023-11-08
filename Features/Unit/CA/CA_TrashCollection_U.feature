Feature: CA_TrashCollection_U
Task 79718
Makes sure the question "Does this vehicle haul to landfills?" Appear for updated taxonomy list 

#@Unit @Issued @Cali @CA
Scenario: CA Trash Collection Unit Vehicle Haul Landfills Verification
	Given user starts a quote with:
	| Industry        | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Trash Collector | 2         | I Run My Business From Property I Own | Vehicles     | 60606    | CA  |
	Then user verifies the appearance of the Start Your Quote page 
	Then user fills in the Start Your Quote page with these values:
	| Name of Business | DBA | Policy Start Date |
	| Trash            |     |                   |
	Then user clicks continue from the Start Your Quote page
    Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
	| Year Business Started | How Business Structured | Address1       | Address2 | City    | Select an Address |
	| 2019                  | Corporation             | 225 S Canal St |          | Chicago |                   |
	Then user clicks continue from CA Introduction
    Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
	| VIN               | Type Insure | Parking Address | Haul | Plowing Snow |
	| 1FDUF4GY7FEA88586 | SUV         | Illinois        | No   | No           | 
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
	| FirstName | LastName | DLState | DOB        | Accident | DLNumber     |
	| First     | Last     | IL      | 01/01/1988 | No       | C12121212121 |