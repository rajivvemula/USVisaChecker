Feature: Quote General
	As a user I want to be able to create a new quote

@SmokeTest @Quote 
@tc:17022 @tc:17024 @tc:17027 @tc:17974 @tc:17028 @tc:37651
Scenario Outline: Create quote using a newly created organization
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks 'New' Button
	When User create a new Org with <State>
	And User enters quote details on Quote Page
	When user clicks 'Next' Button
	Then Toast containing was created. is visible 
	When user clicks 'Business Information' Sidetab
	Then User verifies quote details on Business Information Page
	Then User checks Governing <State> are correctly matching
	 

    Examples:
	| State |
	| IL    |
	| AZ    |
	| NV    |
	| SC    |
	| GA    |
	| CA    |
	| TX    |
	| IN    |
	| TN    |
	| MO    |

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





	
