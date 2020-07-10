@reg
Feature: R050-UserPermissions
	In order to validate user permissions
	As an impersonated user 
	I want to verify the user's ability to perform policy actions is based on their role

Scenario Outline: 1 Policy Permissions
	When I impersonate impersonateable user '<email>'
	Then validate policy permissions '<C>', '<R>', '<U>', '<D>'

Examples: 
	| Role                           | Email                         | C   | R   | U   | D   |
	| Apollo Underwriter             | ApolloTestUserG105@biberk.com | yes | yes | yes | yes |
	| Apollo Underwriting Manager    | ApolloTestUserG309@biberk.com | yes | yes | yes | yes |
	| Apollo Policy Services         | ApolloTestUserG310@biberk.com | no  | yes | yes | no  |
	| Apollo Policy Services Manager | ApolloTestUserG106@biberk.com | no  | yes | yes | no  |
	| Apollo Administrator           | ApolloTestUserG311@biberk.com | yes | yes | yes | yes |
	| Apollo Business Analyst        | ApolloTestUserG312@biberk.com | no  | yes | no  | no  |
