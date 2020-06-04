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
