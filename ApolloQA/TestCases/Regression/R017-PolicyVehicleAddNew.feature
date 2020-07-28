@reg
Feature: R017-PolicyVehicleAddNew
	
	As any User(defaults to admin)
	I want to be able to add a new vehicle



Scenario: 2 User Can Navigate To Vehicles
	When User Click on Vehicles
	Then User is shown the Vehicles screen for that policy



Scenario: 3 User Can Click Add New Vehicle
	When User Click on Add New Vehicle
	Then User is shown the Add New Vehicle Modal


Scenario: User is able to add new Vehicle 
	When I user enter all info into add new vehicle
	| VIN               | Year | Make  | Model  | Trim | State   | Plate   | Type | Cost | Value | Radius | Business       | Code | Notes          |
	| JHMCG56492C003897 | 2002 | Honda | Accord | XL   | Arizona | BJV7821 | Car  | 4000 | 3000  | 200    | Commercial Use | 401  | Sample Vehicle |
	Then vehicle with those inputs is added and confirmed via toast
