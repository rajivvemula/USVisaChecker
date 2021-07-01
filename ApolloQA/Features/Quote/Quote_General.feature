Feature: Quote General
	As a user I want test all general quote related functionality


#Add precondition to search for latest quote LOB=Commercial Auto
@SmokeTest @Quote @tc:16080 @tc:16082 @tc:17029
@bugReported
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





	
