@buzzsmoke
@newWindow
Feature: US-9158-Create Impersonation

#TC01 - Verify impersonating access in UI only for users who has impersonate role
#TC02 - Verify Impersonate pop-up to enter user's email id to start impersonate
#TC03 - Verify user role of the person who is impersonating should be role of the user being impersonated
#TC04 - Verify admin users cannot be impersonated
#TC05 - Verify impersonating user should be able to perform any action that impersonated user would do it in screen / data

#NOTES#
# Roles/permissions are currently being re-worked (TC-03 and TC-05 not implemented)


Scenario: 0 Login as user with impersonation access and verify impersonation icon is available/clickable
	Given User is on Apollo Homepage
	When User logs in as ApolloTestUserG301@biberk.com with default password 1
	Then current logged in user is ApolloTestUserG301@biberk.com
	And the Impersonate icon is visible


Scenario Outline: 1 Attempt to impersonate invalid user
	When User clicks the Impersonate icon
	And User enters impersonation username: <Username>
	And User clicks Submit impersonation
	Then Impersonation error displays text: <Error Text>
	When User escapes the modal

Examples: 
| Username                      | Error Text                   |
| ApolloTestUserG301@biberk.com | Cannot impersonate yourself. |
| ApolloTestUserG302@biberk.com | User cannot be impersonated. |
| fake_email123@address.com     | User cannot be impersonated. |


Scenario Outline: 3 Impersonate valid user
	When User clicks the Impersonate icon
	And User enters impersonation username: <Username>
	And User clicks Submit impersonation
	Then I am currently impersonating user <Username>
	When I click stop impersonation
	Then I am not impersonating

Examples:
| Username                      |
| Sonia.Amaravel@biberk.com     |
| ApolloTestUserG107@biberk.com |


Scenario: 4 Login as user without impersonation access and verify unable to impersonate
	When User logs out
	When User logs in as ApolloTestUserG312@biberk.com with default password 2
	Then current logged in user is ApolloTestUserG312@biberk.com
	Then the Impersonate icon is not visible