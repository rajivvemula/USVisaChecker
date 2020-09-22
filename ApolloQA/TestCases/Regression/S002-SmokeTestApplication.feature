@SmokeTestBase
Feature: S002-SmokeTestApplication
	In order to test application creation
	As an authorized user
	I want to be able to create an application and get a quote

# This is more of a full workflow just covering required values, rather than a thorough test of the individual pages. 
# To do - add page tags to steps to identify which page they belong to (e.g. @Application-BusinessInformation)

##This part was added for parallel feature execution
#Scenario:0 User is able to login as Admin
#	Given User is on Apollo Homepage
#	When I enter AdminUsername and AdminPassword 
#	Then I should see the Apollo Dashboard as Admin


Scenario: 1 Create new application
	When I create a new application with values
	| Business Name               | LOB             | Effective Date |
	| Casey Test Organization 921 | Commercial Auto | 10/21/2020     |
	Then an application is successfully created with the proper values


Scenario: 2 Business Information - Select Physical
	#Given I am on the application's Business Information tab
	When I update physical address to existing address 345 Existing Address, Plains, PA, 18705
	Then The Physical Address is successfully updated

Scenario: 3 Business Information - Validate Fields
	Then the following values are displayed on application's Business Information tab
	| Key                    | Value                       |
	| Business Name          | Casey Test Organization 921 |
	| Business Phone No      | 982-389-4712                |
	| Business Email Address | CaseyTest@test.com          |
	| Business Website       | CaseyTest.com               |
	#And the values are stored in the application's database entry


Scenario Outline: 4 UW Questions - Answer Questions
	Given I am on the application's UW Questions tab
	Then question type <Question Type> is displayed with text: <Question Text>
	When I attempt to answer with selection: <Selection>
	Then the selection is recorded

Examples:
	| Question Type            | Question Text                                                            | Selection       |
	| bh-question-boolean      | Do you have an inventory of vehicles that you sell or lease?             | false           |
	| bh-question-singleselect | How far at most would your vehicles be driven from their base locations? | 51 to 100 miles |
	| bh-question-boolean      | Do you have operating authority from any other states?                   | false           |
	| bh-question-boolean      | Do you have 6 or more vehicles and >= 1 year in business?                | false           |