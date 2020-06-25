
@reg
Feature: R040-InsertNewOrganization
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: 1 Insert New Organization
	Given I am on the OrganizationGrid page
	When I click the New Organization button
	Then I am taken to the OrganizationInsert page

Scenario: 2 Insert New Organization
	Given I am on the OrganizationInsert page
	When I enter organization information
	| Name              | Alternate Name | Legal Name     | Type    | Code  |
	| Test Organization | Test Alt Name | Test Legal Name | Insured | 12345 |
	Then A new organization is created with the appropriate values