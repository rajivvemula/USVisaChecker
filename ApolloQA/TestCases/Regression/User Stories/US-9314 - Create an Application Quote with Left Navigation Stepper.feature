@US-9314
Feature: US-9314 - 9 Create an Application Quote with Left Navigation Stepper
	In order to test application navigation
	As an authorized user
	I want to verify the application tabs are present and clickable

Scenario: 0 User is able to login as Admin
	Given User is on Apollo Homepage
	When I enter AdminUsername and AdminPassword 
	Then I should see the Apollo Dashboard as Admin

Scenario: 1 Create new application
	When I create a new application with values
	| Business Name               | LOB             | Effective Date |
	| Casey Test Organization 921 | Commercial Auto | 10/21/2020     |
	Then an application is successfully created with the proper values
	And Business Information page is displayed

@US-9314-TC01
@US-9314-TC02
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
