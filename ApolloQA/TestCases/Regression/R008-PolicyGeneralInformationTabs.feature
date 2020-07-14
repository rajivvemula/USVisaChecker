@reg
Feature: R008-PolicyGeneralInformationTabs
	
	As Any User
	I want to navigate the tabs within General Information



Scenario: 1 User Can Navigate To General Information
	When User Click on General Information
	Then User is shown the General Information screen for that policy

		
Scenario:2 Navigate To Renewal Information
	When I click Renewal Information Tab
	Then Renewal Information info is shown

Scenario:3 Navigate To Business Profile
	When I click Business Profile Tab
	Then Business Profile info is shown

Scenario:4 Navigate To Agency Information
	When I click Agency Information Tab
	Then Agency Information info is shown

Scenario:5 Navigate To Accounting Profile
	When I click Accounting Profile Tab
	Then Accounting Profile info is shown

Scenario:6 Navigate To Description of Operations
	When I click Description of Operations Tab
	Then Description of Operations info is shown

Scenario:7 Navigate To Web Site
	When I click Web Site Tab
	Then Web Site info is shown