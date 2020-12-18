@RegressionTesting
Feature: US-00000-LoginAsAdminForUS
Covers Login and Navigation Tests


Scenario:1A User is able to login as Admin
	Given User is on Apollo Homepage
	When I enter AdminUsername and AdminPassword 
	Then I should see the Apollo Dashboard as Admin

Scenario:1B User Navigates to Homepage
Given User is on Homepage

Scenario Outline:1C User Interactions With Dashboard Tabs
	When User navigates to <Tab> Tab
	Then Tab navigates to <Tab> URL

Examples:
	| Tab          |
	| Policy       |
	| Quote        |
	| Organization |
	| Home         |