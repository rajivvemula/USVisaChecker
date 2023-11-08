Feature: CA_FuelTruck_U
Purpose: Verify Fuel Truck displays as an option
State: IL
Number of Vehicles: 2
Number of Trailers: 0

@Regression @CA @Auto @Unit
Scenario: CA Fuel Truck Unit Displays Fuel Truck Within Top 5 Option In Vehicle Type List
	Given user starts a quote with:
	| Industry                 | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Anhydrous Ammonia Dealer | 2         | I Run My Business From Property I Own | Vehicles     | 62704    | CA  |
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
	| Year Business Started | How Business Structured | Address1         | Address2 | City        | Select an Address |
	| 1999                  | Corporation             | 2112 S Spring St |          | Springfield |                   |
	Then user clicks continue from CA Introduction
    Then user verifies the appearance of the Vehicles page
	And Fuel Truck is in the top five

@Regression @CA @Auto @Unit
Scenario: CA Fuel Truck Unit Displays In Vehicle Type List
	Given user starts a quote with:
	| Industry | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Florist  | 2         | I Run My Business From Property I Own | Vehicles     | 62704    | CA  |
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
	| Year Business Started | How Business Structured | Address1         | Address2 | City        | Select an Address |
	| 1999                  | Corporation             | 2112 S Spring St |          | Springfield |                   |
	Then user clicks continue from CA Introduction
    Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| No VIN            | Type Insure |
		| 16VDX1024L5068821 | Fuel Truck  |