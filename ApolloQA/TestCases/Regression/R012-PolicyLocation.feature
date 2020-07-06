@reg
Feature: R012-PolicyLocation
	In order to Policy Locations is working as intended
	As any User(defaults to admin)
	I want to be able to add, delete locations


Scenario: 2 User Can Navigate To Locations
	When User Click on Locations
	Then User is shown the Locations screen for that policy
