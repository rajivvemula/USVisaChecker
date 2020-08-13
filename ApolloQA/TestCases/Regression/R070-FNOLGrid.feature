Feature: R070-FNOLGrid
	

@fnol
Scenario: User is able to navigate to FNOL Grid
	Given User is on Dashboard
	When User Clicks on Waffle Mene 
	And User clicks on Claims
	Then User is shown the Manager Dashboard

Scenario: User is able to click on Add New Fnol
	Given User is shown the Manager Dashboard
	When User clicks on Add New FNOL Button
	Then User is taken to the FNOL Occurence Page

Scenario: User is able to Click Add FNOL From Nav Bar
	Given User is on Dashboard
	When USer clicks Add FNOL
	Then User is taken to the FNOL Occurence Page 