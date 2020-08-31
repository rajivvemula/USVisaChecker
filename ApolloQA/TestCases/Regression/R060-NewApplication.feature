Feature: R060-NewApplication
	In order to test application creation
	As an authorized user
	I want to be able to create an application


Scenario Outline: 1 Create new application
	When I impersonate impersonateable user <Email>
	And I attempt to create a policy with <Organization Name>, <Line of Business>, <Effective Date>
	Then a policy is successfully created with <Organization Name>, <Line of Business>, <Effective Date>

Examples: 
	| Email                         | Organization Name              | Line of Business | Effective Date |
	| ApolloTestUserG108@biberk.com | Casey Test Org 827             | Commercial Auto  | 09/15/2020     |
	| ApolloTestUserG109@biberk.com | City Market and Cafe           | Commercial Auto  | 10/01/2020     |
	| ApolloTestUserG110@biberk.com | Casey Test Org for Application | Commercial Auto  | 11/22/2020     |
