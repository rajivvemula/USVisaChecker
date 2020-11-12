Feature: apolloClaimFNOL


@biBerkClaimFNOLAdd @SmokeTest
Scenario: Create an Occurrence successfully
	Given user is successfully logged into biberk
	When user clicks ' apps ' icon button
	When user clicks Claim right menu button
	When user clicks New FNOL Button
	And user waits for spinner to load
	And user selects 'No' this occurrence related to an existing claim
	And user enters occurrence information for Policy
	And user enters Location information
	And user enters police involved info - 'Yes'
	And user enters fire involved info - 'Yes'
	When user clicks  Save  Button
	And user waits for spinner to load
	Then user asserts for Occurence save

Scenario: User cancels an Occurrence addition
	Given user is successfully logged into biberk
	When user clicks ' apps ' icon button
	When user clicks Claim right menu button
	When user clicks New FNOL Button
	And user waits for spinner to load
	And user selects 'Yes' this occurrence related to an existing claim
	And user enters occurrence information for Policy
	And user selects Location Information from dropdown
	And user enters police involved info - 'Yes'
	And user enters fire involved info - 'Yes'
	When user clicks Cancel Button
	When user clicks Continue anyway Button
	Then user asserts for Occurence cancel


