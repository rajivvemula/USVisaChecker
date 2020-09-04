Feature: R060-NewApplication
	In order to test application creation
	As an authorized user
	I want to be able to create an application

Scenario: 1 Create new application
	When I impersonate impersonateable user ApolloTestUserG108@biberk.com
	And I attempt to create an application with Casey Test Org 827, Commercial Auto, 09/15/2020
	Then an application is successfully created with the proper values

