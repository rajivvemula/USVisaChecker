
Feature: S002-SmokeTestApplication
	In order to test application creation
	As an authorized user
	I want to be able to create an application and get a quote

# This is more of a full workflow just covering required values, rather than a thorough test of the individual pages. 
# To do - add page tags to steps to identify which page they belong to (e.g. @Application-BusinessInformation)



Scenario: 1 Create new application
	When I create a new application with values
	| Business Name      | LOB             | Effective Date |
	| Casey Test Org 916 | Commercial Auto | 10/13/2020     |
	Then an application is successfully created with the proper values


Scenario: 2 Business Information - Select Mailing
	#Given I am on the application's Business Information tab
	When I update mailing address to existing address 345 Existing Address, Plains, PA, 18705
	Then The Mailing Address is successfully updated

Scenario Outline: 3 UW Questions - Answer Questions
	Given I am on the application's UW Questions tab
	Then question type <Question Type> is displayed with text: <Question Text>
	When I attempt to answer with selection: <Selection>
	Then the selection is recorded

Examples:
	| Question Type            | Question Text                                                            | Selection       |
	| bh-question-singleselect | How far at most would your vehicles be driven from their base locations? | 51 to 100 miles |
	| bh-question-boolean      | Do you haul any non-owned goods for pay?                                 | false           |
	| bh-question-boolean      | Do you have operating authority from any other states?                   | false           |
	| bh-question-boolean      | Do you have 6 or more vehicles and >= 1 year in business?                | false           |