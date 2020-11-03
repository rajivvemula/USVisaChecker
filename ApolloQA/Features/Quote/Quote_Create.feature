Feature: Create a new Quote
	As a user I want to be able to create a new quote

@SmokeTest @Quote
Scenario: Create New Quote
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks the + New button
	And user Selects a random Business Name
	And user Selects Line of Business as Commercial Auto
	And user Selects Policy Effective Date as Tomorrow
	And user Clicks the Next Button
	Then A new Quote should successfully be created
	And User should be redirected to the newly created Quote
	And Quote header should contain correct values


