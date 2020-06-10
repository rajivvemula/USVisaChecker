Feature: MainNavTest

In order to test the main navigation bar
As a currently logged in user
I want to verify the tabs are present and clickable

@tag1
Scenario: Home tab is clickable
	Given I am logged in
	When I click on the Home tab
	Then The Home tab should load properly

Scenario: Policy tab is clickable
	Given I am logged in
	When I click on the Policy tab
	Then The Policy tab should load properly

Scenario: Organization tab is clickable
	Given I am logged in
	When I click on the Organization tab
	Then The Organization tab should load properly

Scenario: Can search by policy number
	Given I am logged in
	When I enter policy number 12890 in the search field
	Then I should be able to click the policy number
	And I should be directed to policy 12890

Scenario: Can search by organization
	Given I am logged in
	When I enter organization name ACME in the search field
	Then I should be able to click the organization
	And I should be directed to organization ACME