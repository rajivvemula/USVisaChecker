Feature: G002-GridActions
Test Various Actions on Grid Pages


Scenario: Grid Titles
	Then Grid column label is displayed
	| Key | Value |
	| a   | label |
	Then Verify grid contains ellipsis
	Then Verify grid does not contain ellipsis
	Then Verify ellipsis contains the following options
	| Key | Value  |
	| a   | Delete |