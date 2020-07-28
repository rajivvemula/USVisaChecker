@reg
Feature: R051-PolicyPermissions
	In order to test policy CRUD operations
	As an impersonated user
	I want to validate policy CRUD operations


Scenario: 1.0 User with full CRUD policy permissions
	When I impersonate impersonateable user ApolloTestUserG105@biberk.com
	Then I can create a policy

Scenario: 1.1 User with full CRUD policy permissions
	Then I can update a policy

Scenario: 2.0 User with RU policy permissions
	When I impersonate impersonateable user ApolloTestUserG310@biberk.com
	Then I cannot create a policy

Scenario: 2.1 User with RU policy permissions
	Then I can update a policy


