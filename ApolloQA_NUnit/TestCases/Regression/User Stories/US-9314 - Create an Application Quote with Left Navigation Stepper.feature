@newWindow
@BuzzSmoke

#US-9314
#US-9314-TC01
#US-9314-TC02

Feature: US-9314 - 9 Create an Application Quote with Left Navigation Stepper
	In order to test application navigation
	As an authorized user
	I want to verify the application tabs are present and clickable

Scenario: 0 Login
	Given User is on Apollo Homepage
	When User logs in as ApolloTestUserG301@biberk.com with default password 1
	Then current logged in user is ApolloTestUserG301@biberk.com

Scenario: 1 Create new application
	Given User is on Homepage
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
