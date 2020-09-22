@reg @pol
Feature: R012-PolicyLocation
	In order to Policy Locations is working as intended
	As any User(defaults to admin)
	I want to be able to add, delete locations
#
#Scenario: 1 User Can Navigate To General Information
#	Given User navigates to Policy Page For Policy 10146
#	When User Click on General Information
#	Then User is shown the General Information screen for that policy


Scenario: 2 User Can Navigate To Locations
	When User Click on Locations
	Then User is shown the Locations screen for that policy

Scenario: 3 User is able to a default location 
	When User clicks on New in Locations
	And User inputs a location name
	Then Location name should be present in the grid

