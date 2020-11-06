Feature: Impersonation


Scenario: Unable to select user to impersonate
	Given user is successfully logged into biberk
	When user clicks  assignment_ind  Button
	And user enters ApolloTestUserG201@biberk.com username into email field
	When user clicks  Submit  Button
	Then user asserts for error - 'User cannot be impersonated.'
