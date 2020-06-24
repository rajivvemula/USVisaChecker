﻿@reg
Feature: R030-MainNavBarNavigation
	In order to test Main Navigation Bar functionality
	As an authenticated user on a page containing the Main Navigation Bar
	I want to be able to use the Nav Bar shortcuts, search, and other functionality


Scenario: 1 Home tab is clickable
	Given I am on a page containing the Main Navigation Bar
	When I click on the Home tab
	Then The Home tab should load properly

Scenario: 2 Policy tab is clickable
	Given I am on a page containing the Main Navigation Bar
	When I click on the Policy tab
	Then The Policy tab should load properly

Scenario: 3 Organization tab is clickable
	Given I am on a page containing the Main Navigation Bar
	When I click on the Organization tab
	Then The Organization tab should load properly

Scenario: 4 Can search by valid policy number
	Given I am on a page containing the Main Navigation Bar
	When I enter policy number 10013 in the search field
	And I click the first search result
	Then I should be directed to policy 10013

Scenario: 5 Can search by valid organization
	Given I am on a page containing the Main Navigation Bar
	When I enter organization name ACME in the search field
	And I click the first search result
	Then I should be directed to organization ACME
