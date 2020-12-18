Feature: Quote Left Nav Bar
	As a user I want to be able to create a new quote

@SmokeTest @Quote
Scenario: Left Nav Bar displays successfully
Given user is successfully logged into biberk
When User Navigates to Quote latest
Then Left Nav Sections should be displayed successfully


Scenario: Left Nav Bar Sections load Successfully
Given user is successfully logged into biberk
When User Navigates to Quote latest
Then User should be able to navigate to each section successfully



	
