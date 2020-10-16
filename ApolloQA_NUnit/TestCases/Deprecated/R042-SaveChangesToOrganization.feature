@org
Feature: R042-SaveChangesToOrganization
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: User is able to make a change in an existing organization
	Given User is on Business Information Tab
	When User changes sub-industry type
	Then Change should be saved to the organization