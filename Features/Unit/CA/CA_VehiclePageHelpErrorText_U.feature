Feature: CA_VehiclePageHelpErrorText_U
This file validates the appearence of help and error text on the vehicles page

@Unit
Scenario: CA Vehicle Page Help Error Text Unit
	Given user starts a quote with:
		| Industry   | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Food Truck | 0         | I Run My Business From Property I Own | Vehicles     | 60004    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business   | DBA | Policy Start Date |
		| TEST CA AUTH REFER |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured     | Address1        | Address2 | City              | Select an Address |
		| 2010                  | Limited Liability Co. (LLC) | 1600 N Yale Ave |          | Arlington Heights |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	Then user clicks Let's Continue
	Then user verifies the following front end help and error text of the Vehicle Page:
		| Question Alias  | Type  |
		| isVinTelligence | Error |
	And user creates a vehicle or trailer with variable values:
		| VIN |
		|     |
	Then user verifies the following front end help and error text of the Vehicle Page:
		| Question Alias  | Type  |
		| isVinTelligence | Help  |
		| vinNumber       | Error |
	And user creates a vehicle or trailer with variable values:
		| VIN               |
		| 1GNFK13067J109399 |
	Then user verifies the following front end help and error text of the Vehicle Page:
		| Question Alias | Type |
		| details        | Help |
	Then user verifies the following Apollo help and error text of the Vehicle Page:
		| Question Alias | Type  |
		| VehicleUse     | Error |
	And user creates a vehicle or trailer with variable values:
		| No VIN |
		|        |
	Then user verifies the following front end help and error text of the Vehicle Page:
		| Question Alias    | Type  |
		| vehicleCategory   | Error |
		| yearOfManufacture | Error |
	And user creates a vehicle or trailer with variable values:
		| Year | Enter Year Make Model |
		| 2007 |                       |
	Then user verifies the following front end help and error text of the Vehicle Page:
		| Question Alias | Type  |
		| make           | Error |
	And user creates a vehicle or trailer with variable values:
		| Make      | Enter Year Make Model |
		| CHEVROLET |                       |
	Then user verifies the following front end help and error text of the Vehicle Page:
		| Question Alias | Type  |
		| model          | Error |
	And user creates a vehicle or trailer with variable values:
		| Model |
		| TAHOE |
	Then user verifies the following Apollo help and error text of the Vehicle Page:
		| Question Alias | Type |
		| VehicleValue   | Help |
	And user creates a vehicle or trailer with variable values:
		| Type Insure |
		| Food Truck  |
	Then user verifies the following Apollo help and error text of the Vehicle Page:
		| Question Alias | Type |
		| GVWr           | Help |
	And user creates a vehicle or trailer with variable values:
		| Type Insure                     |
		| Limousine: seating less than 10 |
	Then user verifies the following Apollo help and error text of the Vehicle Page:
		| Question Alias | Type  |
		| Seatbelts      | Error |
	And user creates a vehicle or trailer with variable values:
		| Type Insure |
		| Bus         |
	Then user verifies the following Apollo help and error text of the Vehicle Page:
		| Question Alias   | Type  |
		| VehicleSeatCount | Error |
	And user creates a vehicle or trailer with variable values:
		| Type Insure         |
		| Tow Truck: Tilt Bed |
	Then user verifies the following Apollo help and error text of the Vehicle Page:
		| Question Alias | Type  |
		| Repossession   | Error |
	And user creates a vehicle or trailer with variable values:
		| Type Insure |
		| Dump Truck  |
	Then user verifies the following Apollo help and error text of the Vehicle Page:
		| Question Alias | Type  |
		| Landfills      | Error |
	And user creates a vehicle or trailer with variable values:
		| Type Insure        |
		| Other Open Trailer |
	Then user verifies the following Apollo help and error text of the Vehicle Page:
		| Question Alias | Type  |
		| TrailerValue   | Error |