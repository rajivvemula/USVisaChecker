Feature: US- 13311- Ellipses within the grid row
	As a user, 
	I want to select the appropriate operation within the selected line of the grid 
	so that navigation is easy


Scenario: Check If Ellipsis is present 
	Given User is on Homepage
	When User navigates to Policy Tab
	Then Tab navigates to Policy URL
	Then Verify grid contains ellipsis

Scenario: Verify ellipsis has correct options displayed
	Then Verify ellipsis contains the following options
	| Key | Value  |
	| a   | Delete |
	| b   | View   |
	| c   | Edit   |
Scenario: Check if Ellpisis is not present
	Given User opens Waffle Menu
	When User navigates to Claims Tab
	Then Tab navigates to Claims URL