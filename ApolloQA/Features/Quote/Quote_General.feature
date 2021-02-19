Feature: Quote General
	As a user I want to be able to create a new quote

@SmokeTest @Quote @bugReported
@tc:17022 @tc:17024 @tc:17027 @tc:17974 @tc:17028
#BUG 30162
Scenario: Create New Quote
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks New Button
	And user selects dropdown Line of Business option equaling Commercial Auto
	And user selects dropdown Producer option at index 0	
	And user Selects Policy Effective Date as Tomorrow
	And user selects dropdown Named Insured option at index 0	
	And user selects dropdown Physical Address option containing , IL,
	And user clicks Next Button
	Then A new Quote should successfully be created
	And User should be redirected to the newly created Quote Business Information Section
	And Quote header should contain correct values


@SmokeTest @Quote @tc:16080 @tc:16082 @tc:17029
Scenario: Left Nav Bar displays successfully
	Given user is successfully logged into biberk
	When User Navigates to Quote latest
	Then Left Nav Sections should be displayed successfully
	| SectionName           |
	| Business Information  |
	| Contacts              |
	| Vehicles              |
	| Drivers               |
	| Operations			|
	| Policy Coverages      |
	| Modifiers             |
	| Policy Addl Interests |
	| Summary               |
	| UW Results            |



@SmokeTest @Quote
Scenario: Left Nav Bar Sections load Successfully
Given user is successfully logged into biberk
When User Navigates to Quote latest
When user waits '10' seconds
Then User should be able to navigate to each section successfully





	
