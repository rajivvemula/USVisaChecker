@navigation @smoketest
Feature: B001-DashboardTabs
	Test Out the initial tabs that are present upon logging in

Scenario:1 User Navigates to Homepage
Given User is on Homepage

Scenario Outline:2 User Interactions With Dashboard Tabs
	When User navigates to <Tab> Tab
	Then Tab navigates to <Tab> URL

Examples:
	| Tab          |  
	| Policy       | 
	| Application  | 
	| Organization | 
	| Home         |

Scenario: 3 Verify Correct Tabs Displayed In Waffle Menu
	Given User opens Waffle Menu
	Then Correct waffleTabs is displayed
	Then User closes Waffle Menu

Scenario Outline: 4 User Interactions With Waffle Menu Tabs
	Given User opens Waffle Menu
	When User navigates to <Tab> Tab
	Then Tab navigates to <Tab> URL

Examples:
	| Tab            |
	| Underwriting   |
	| Billing        |
	| Administration |
	| Collections    |
	| Claims         |