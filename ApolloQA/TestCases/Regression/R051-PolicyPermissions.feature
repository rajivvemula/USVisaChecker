@reg
Feature: R051-PolicyPermissions
	In order to test policy CRUD operations
	As an impersonated user
	I want to validate policy CRUD operations


Scenario: 1 User with full CRUD policy permissions
	When I impersonate impersonateable user ApolloTestUserG105@biberk.com
	Then I can create a policy
	And I can read a policy
	#And I can update a policy
	#And I can delete a policy

Scenario: 2 User with read-only policy permissions
	When I impersonate impersonateable user ApolloTestUserG310@biberk.com
	Then I cannot create a policy
	And I can read a policy
	#And I cannot update a policy
	#And I cannot delete a policy

