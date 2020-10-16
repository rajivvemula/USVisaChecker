Feature: N003-SideTabs
Test Side Tab and Interactions located in such as policy, org etc


Scenario: User Interaction With Side Tab
	When User navigates to <Tab> SideTab
	Then Verify <tabset> are present
	Then Verify sidetab is present
	| Key | Value                   |
	| a   | Application Information |
	| b   | Business Information    |
	| c   | Contacts                |
	| d   | UW Questions            |
	| e   | Policy Coverages        |
	| f   | Drivers                 |
	| g   | Vehicles                |
	| h   | Additional Questions    |
	| i   | Summary                 |

#clicks tabs listed in examples table, also pulls applicationTabs tabset from Defaults for verification
Scenario Outline: Check Application tabs are present and clickable
	When User navigates to <Tab Name> SideTab
	Then <Tab Name> page is displayed
	And Verify applicationTabs are present

Examples:
	| Tab Name                |
	| Application Information |
	| Business Information    |
	| Contacts                |
	| UW Questions            |
	| Additional Questions    |
	| Policy Coverages        |
	| Drivers                 |
	| Vehicles                |
	| Additional Interests    |
	| Summary                 |