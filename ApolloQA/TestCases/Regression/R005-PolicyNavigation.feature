Feature: R005-PolicyNavigation
	
	As a User
	I want to be able to navigate to each tab within policy

@regeression
Scenario: 1 User Can Navigate To General Information
	Given User navigates to Policy Page For Policy 10005
	When User Click on General Information
	Then User is shown the General Information screen for that policy

@regeression
Scenario: 2 User Can Navigate To Locations
	When User Click on Locations
	Then User is shown the Locations screen for that policy

@regeression
Scenario: 3 User Can Navigate To Contacts
	When User Click on Contacts
	Then User is shown the Contacts screen for that policy

@regeression
Scenario: 4 User Can Navigate To Vehicles
	When User Click on Vehicles
	Then User is shown the Vehicles screen for that policy

@regeression
Scenario: 5 User Can Navigate To Drivers
	When User Click on Drivers
	Then User is shown the Drivers screen for that policy

@regeression
Scenario: 6 User Can Navigate To Coverages
	When User Click on Coverages
	Then User is shown the Coverages screen for that policy

@regeression
Scenario: 7 User Can Navigate To Rate Calculation
	When User Click on Rate Calculation
	Then User is shown the Rate Calculation screen for that policy

@regeression
Scenario: 8 User Can Navigate To Documents
	When User Click on Documents
	Then User is shown the Documents screen for that policy

@regeression
Scenario: 9 User Can Navigate To Policy History
	When User Click on Policy History
	Then User is shown the Policy History screen for that policy