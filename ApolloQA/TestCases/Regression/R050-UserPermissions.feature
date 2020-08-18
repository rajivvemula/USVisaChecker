@reg
Feature: R050-UserPermissions
	In order to validate user permissions
	As an impersonated user 
	I want to verify the user's ability to perform policy actions is based on their role

Scenario Outline: 1 Policy Permissions
	When I impersonate impersonateable user <Email>
	Then I <Create Policy> create a policy
	And I <Update Policy> update the policy general information tab
	And I <Add Contact> add a contact
	And I <Add Vehicle> add a new vehicle

Examples: 
	| Role                           | Email                         | Create Policy | Update Policy | Add Contact | Add Vehicle |
	| Apollo Underwriter             | ApolloTestUserG108@biberk.com | can           | can           | can         | can         |
	| Apollo Policy Services         | ApolloTestUserG110@biberk.com | cannot        | can           | cannot      | cannot      |
