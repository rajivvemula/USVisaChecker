Feature: N005-MainNavbar
	In order to test Main Navigation Bar functionality
	As an authenticated user on a page containing the Main Navigation Bar
	I want to be able to use the Nav Bar shortcuts, search, and other functionality


Scenario: Home tab is clickable
	Given I am on a page containing the Main Navigation Bar
	When I click on the Home tab
	Then The Home tab should load properly

Scenario: Policy tab is clickable
	When I click on the Policy tab
	Then The Policy tab should load properly

Scenario: Organization tab is clickable
	When I click on the Organization tab
	Then The Organization tab should load properly

Scenario: Can search by valid policy number
	When I enter policy number 10339 in the search field
	And I click the first search result
	Then I should be directed to policy 10339

Scenario: Can search by valid organization
	When I enter organization name Casey Test Org in the search field
	And I click the first search result
	Then I should be directed to organization Casey Test Org

Scenario: Can impersonate impersonateable user
	When I impersonate impersonateable user Sonia.Amaravel@biberk.com
	Then I am currently impersonating user Sonia.Amaravel@biberk.com

Scenario: Can stop impersonation
	When I click stop impersonation
	Then I am not impersonating

	

	

