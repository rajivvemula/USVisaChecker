@navigation @smoketest
Feature: B001-DashboardTabs
	Test Out the initial tabs that are present upon logging in

Scenario: User Navigates to Homepage
Given User is on Homepage

Scenario Outline: User Interactions With Dashboard Tabs
	When User navigates to <Tab> Tab
	Then Tab navigates to <Assert> URL

Examples:
	| Tab          | Assert       | 
	| Policy       | Policy       |
	| Application  | Application  |
	| Organization | Organization |
	| Home         | Home         |