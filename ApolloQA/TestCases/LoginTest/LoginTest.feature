Feature: LoginTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: User Logs in to admin account
	Given User is on homepage and on log on screen
	When User enters username and password
	Then User is shown the Dashboard
	Then User navigates to policy 
