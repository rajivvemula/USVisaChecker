Feature: P002-PolicyInformation
	Functions to set data to a specific Policy


Scenario: Set Organization Data
	When user Selects an Organization with the following relevant values
	| Organization Type | Insurrance Score Tier |
	| Individual        | AB01                  |

Scenario: Set Vehicles Data
	When user Selects Vehicle Type risks with the following relevant values
	| Vehicle Age | Radius | Class Code | 
	| 3           | 100    | 602        | 

