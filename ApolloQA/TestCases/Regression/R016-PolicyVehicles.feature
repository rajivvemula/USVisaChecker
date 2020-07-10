﻿
@reg
Feature: R016-PolicyVehicles
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario: 2 User Can Navigate To Vehicles
	When User Click on Vehicles
	Then User is shown the Vehicles screen for that policy



Scenario: 3 User Can Click Add New Vehicle
	When User Click on Add New Vehicle
	Then User is shown the Add New Vehicle Modal


Scenario Outline: Verify All Inputs on Add New Vehicle Modal
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

Scenario Outline: Verify All Selects on Add New Vehicle Modal
	When User clicks on <Select> in Add New Vehicle Modal
	Then User should see all values to be present in <Select>
	And User is required to have Select values for the <Select> as <SelectRequired>

	Examples: 
	| Select   | SelectRequired |
	| State    | true           |
	| Type     | true           |
	| Business | true           |


