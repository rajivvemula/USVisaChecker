@reg @pol
Feature: R011-PolicyCoverage
	Temporary Select Coverage



	
#Scenario: 1 User Can Navigate To General Information
#	Given User navigates to Policy Page For Policy 10146
#	When User Click on General Information
#	Then User is shown the General Information screen for that policy

Scenario: 2 User Can Navigate To Coverages
	When User Click on Coverages
	Then User is shown the Coverages screen for that policy


Scenario:3 Select Default Coverage
	When User Clicks New in Coverages
	And User inputs default values for Premium and Coverage
	Then User is shown toast for creating coverage
