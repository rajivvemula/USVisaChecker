Feature: CA_TuckPointer_I
CA policy in IL without entering purchase path

@Issued @Regression @IL @CA @Construction
Scenario: CA Tuck Pointer Issued In Illinois
	Given user starts a quote with:
		| Industry     | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Tuck-pointer | 2         | I Run My Business From Property I Own | Vehicles     | 60606    | CA  |
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
		| Year Business Started | How Business Structured | Address1       | Address2 | City    | Select an Address |
		| 2012                  | Corporation             | 225 S Canal St |          | Chicago |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth | Escort Trucks | Plowing Snow |
		| 1FTPW14597FA39833 | Illinois        | 30000         | No            | No           |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Type Insure | Parking Address | Vehicle Worth | Haul | For Hire | Plowing Snow |
		| 1FDUF4GY7FEA88586 | Dump Truck  | Illinois        | 18878         | No   | No       | No           |
	Then user clicks Let's Continue