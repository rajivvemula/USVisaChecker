@SmokeTestBase
Feature: S000-SmokeTest
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
	| Application  | 
	| Organization | 
	| Home         |

Scenario:1D Verify Correct Tabs Displayed In Waffle Menu
	Given User opens Waffle Menu
	Then Correct waffleTabs are displayed
	Then User closes Waffle Menu


Scenario:1F Navigate to Organization Insert Page
	Given User is on Homepage
	When User navigates to Organization Tab
	Then Tab navigates to Organization URL
	When User clicks orgGridNew button
	Then Verify correct page orgInsert is displayed

Scenario:1G Navigate to FNOL Insert Page
	Given User is on Homepage
	Given User opens Waffle Menu
	When User navigates to Claims Tab
	Then Tab navigates to Claims URL
	When User clicks fnolGridNew button
	Then Verify correct page fnolInsert is displayed

Scenario:1H Navigate to Application Insert Page
	Given User is on Homepage
	When User navigates to Application Tab
	Then Tab navigates to Application URL
	When User clicks appGridNew button
	Then Verify correct page appInsert is displayed

Scenario:1I Can search by valid policy number
	When User enters 10543 in search field
	And User selects the first result
	Then User is directed to Policy URL with ID 10543

Scenario:1J Can search by valid organization number
	When User enters Casey Test Org 916 in search field
	And User selects the first result
	Then User is directed to Organization

Scenario:1K Can impersonate impersonateable user
	When I impersonate impersonateable user Sonia.Amaravel@biberk.com
	Then I am currently impersonating user Sonia.Amaravel@biberk.com

Scenario:1L Can stop impersonation
	When I click stop impersonation
	Then I am not impersonating
