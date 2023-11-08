Feature: CA_OtherVehicleSelectionPreservation_U

US 78677 - Verifies that the Tow Truck-wheel/Lift Hook automatically defaults to vehicle type other when navigating back and forth

@Unit @CA @TN @Auto
Scenario: CA Other Vehicle Selection Preservation Unit Vehicle Modal Verification
	Given user starts a quote with:
		| Industry        | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Towing Services | 0         | I Lease a Space From Others | Vehicles     | 77050    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
    Then user verifies the appearance of the Introduction page
	Then user checks the stepper appearance on the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1     | Address2 | City    | Select an Address |
		| 2012                  | Corporation             | 5827 Hermann |          | Houston | Original          |
	Then user clicks continue from CA Introduction
    Then user verifies the appearance of the Vehicles page
	Then user checks the stepper appearance on the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Type Insure   | Parking Address | Vehicle Worth | Plowing Snow |
		| 1GBKC34J2YF518855 | Flatbed Truck | Tennessee       | 2500          | No           |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	When user navigates back to the previous CA page
	Then user verifies that the following other vehicle type is still selected: Flatbed Truck