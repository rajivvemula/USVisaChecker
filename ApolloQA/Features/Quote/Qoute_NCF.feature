Feature: Qoute_NCF
Smoke Automation : Quote - NCF score  
Task 38664


Scenario: Verify User is able to generate a NCF request and response
	Given user is successfully logged into biberk
	When User selects latest Quote through API
	When user clicks 'Business Information' Sidetab
	And user clicks 'Get Score' Button
	When User enters contact information for NCF
	And user clicks 'Submit' Button
	Then Toast containing Your request is being processed. You will be notified when it is finished. is visible 
	Then User Verify CosmosDB contains a record within Ncfrequest
	When user waits '10' seconds
	Then User Verify CosmosDB contains a record within Ncfresponse
	Then User verifies that A credit score is displayed in Business Information
	When user clicks 'Summary' Sidetab
	And user clicks 'Rating Worksheet' Button
	Then User Verify correct score is displayed in rating worksheet