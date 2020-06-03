Feature: MainNavTest

In order to test the main navigation bar
As a currently logged in user
I want to verify the tabs are present and clickable

@tag1
Scenario: Main Navbar displayed properly
	Given I am logged in
	When I navigate to the homepage
	Then The Main Navbar should display properly
