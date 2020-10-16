
Feature: A000-UserLoginAsAdmin
	As a Admin
	I want to login 
	So I can access the Apollo


Scenario: User is able to login as Admin
	Given User is on Apollo Homepage
	When I enter AdminUsername and AdminPassword 
	Then I should see the Apollo Dashboard as Admin

Scenario: User logs in with email address
	Given User is on Apollo Homepage
	When User logs in as <email> with default password <1>
	Then current logged in user is <email>

Scenario: User logs out
	When User logs out



##new driver/window only valid for the feature
#Scenario: User logs in with email in new window
#	Given User opens a new window and logs in as <email>
#	Then Home page is displayed
#
## must close new window manually for now
#Scenario: User closes the new window
#	Given User closes the new window
