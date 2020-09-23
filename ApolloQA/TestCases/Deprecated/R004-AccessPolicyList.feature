Feature: R004-AccessPolicyList
	
	As Any User 
	I Want To Access The Policy Page/Grid

@reg @pol
Scenario: Acess PolicyPage From Dashboard
	Given User is on Dashboard
	When User clicks on Policy Link in Navigation Bar
	Then User is shown the Policy List
