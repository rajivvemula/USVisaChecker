Feature: Quote General
	As a user I want to be able to create a new quote

@SmokeTest @Quote 
@tc:17022 @tc:17024 @tc:17027 @tc:17974 @tc:17028
Scenario: Create New Quote
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks 'New' Button
	#And user selects dropdown Line of Business option equaling Commercial Auto
	And user selects dropdown Producer option at index 0	
	And user Selects Policy Effective Date as Tomorrow
	When User Selects Name Insured from dropdown
	And user selects dropdown Organization Type option equaling LLC
	And user selects dropdown Tax ID Type option equaling FEIN
	And user enters tax Id number
	And user enters abcTest@example.com into Business Email Address field
	And user enters 4843668104 into Business Phone No field
	And user enters Accounting Services into Keyword field
	And user selects dropdown Keyword option equaling Accounting Services
	And user enters 2001 into Year Business Started field
	And user enters 2003 into Year Ownership Started field
	And user sets Orgnaization Address
	And user clicks 'Next' Button
	Then A new Quote should successfully be created
	#BUG 30162
	#And User should be redirected to the newly created Quote Business Information Section
	And Quote header should contain correct values

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





	
