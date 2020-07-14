@reg
Feature: R018-PolicyDrivers
	
	As any user(defaults to admin)
	I want to be able to add a new driver to an existing policy


Scenario: 1 User Can Navigate To General Information
	Given User navigates to Policy Page For Policy 10005
	When User Click on General Information
	Then User is shown the General Information screen for that policy

Scenario: 2 User Can Navigate To Drivers
	When User Click on Drivers
	Then User is shown the Drivers screen for that policy

