@smoketest @navigation
Feature: A000-UserLoginAsAdmin
	As a Admin
	I want to login 
	So I can access the Apollo


Scenario: User is able to login as Admin
	Given User is on Apollo Homepage
	When I enter AdminUsername and AdminPassword 
	Then I should see the Apollo Dashboard as Admin
