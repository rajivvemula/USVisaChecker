Feature: D004-ApplicationNavigation

Scenario: 1 Create new application
	When I create a new application with values
	| Business Name               | LOB             | Effective Date |
	| Casey Test Organization 921 | Commercial Auto | 10/21/2020     |
	Then an application is successfully created with the proper values
	And Business Information page is displayed

Scenario Outline: 2 Check Application tabs are present and clickable
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