@reg
Feature: R051-PolicyPermissions
	In order to test policy CRUD operations
	As an impersonated user
	I want to validate policy CRUD operations


Scenario: 1.0 Full CRUD - Can Create Policy
	When I impersonate impersonateable user ApolloTestUserG108@biberk.com
	Then I can create a policy

Scenario: 1.1 Full CRUD - Can Update General Info
	Then I can update the policy general information tab

Scenario: 2.0 Read Only - Cannot Create Policy
	When I impersonate impersonateable user ApolloTestUserG207@biberk.com
	Then I cannot create a policy

Scenario: 2.1 Read Only - Cannot Update General Info
	Then I cannot update the policy general information tab


