@org
Feature: R045-AddAVehicleToOrganization
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario:1 User can navigate to Vehicle tab and click Add Vehicle
	When User clicks Vehicles Tab In Organization
	And User clicks Add Vehicle in Organization


Scenario Outline:4 Verify All Inputs on Add New Vehicle Modal
	When User enter <Value> for <Input>
	Then User should see <Value> For that <Input>
	And User is required to have values for the <Input> as <Required> 

	Examples: 
	| Input  | Value     | Required |
	| VIN    | 123456    | true     |
	| Year   | 2000      | true     |
	| Make   | Honda     | true     |
	| Model  | 2004      | true     |
	| Trim   | TrimA     | true     |
	| Plate  | Qwerty123 | true     |
	| Cost   | 5000      | true     |
	| Value  | 4000      | true     |
	| Radius | 1000      | true     |
	| Notes  | Sample    | false    |

Scenario Outline:5 Verify All Selects on Add New Vehicle Modal
	When User clicks on <Select> in Add New Vehicle Modal
	Then User should see all values to be present in <Select>
	And User is required to have Select values for the <Select> as <SelectRequired>

	Examples: 
	| Select   | SelectRequired |
	| State    | true           |
	| Type     | true           |
	| Business | true           |

Scenario:7 User is able to click cancel and exit the modal
	When User clicks cancel to exit modal for add vehicle
	And User clicks Add Vehicle in Organization

#Scenario: User is able to add new Vehicle 
	#When I user enter all info into add new vehicle
	#| VIN               | Year | Make  | Model  | Trim | State | Plate | Type | Cost | Value | Radius | Business | Code | Notes |
	#| JHMCG56492C003897 | 2002 | Honda | Accord | XL   | AZ    | BJV7821 | Car  | 4000 | 3000  | 200    | Commercial Use | 401  | Sample Vehicle |
	#Then vehicle with those inputs is added and confirmed via toast