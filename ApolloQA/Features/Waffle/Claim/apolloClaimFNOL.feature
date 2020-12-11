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
	And user waits for spinner to load
	And user enters loss date and time
	And user enters Location information
	And user enters police involved info - 'Yes'
	And user enters fire involved info - 'Yes'
	When user clicks  Save  Button
	And user waits for spinner to load
	Then user asserts for Occurence save

Scenario: TC 25518 : User able to search by policy number
	Given user is successfully logged into biberk
	When user clicks ' apps ' icon button
	When user clicks Claim right menu button
	When user clicks New FNOL Button
	And user waits for spinner to load
	And user selects 'Yes' this occurrence related to an existing claim
	And user enters occurrence information for Policy
	And user waits for spinner to load
	And user enters loss date and time
	And user selects Location Information from dropdown
	And user enters police involved info - 'No'
	And user enters fire involved info - 'No'
	When user clicks Cancel Button
	When user clicks Continue anyway Button
	Then user asserts for Occurence cancel

Scenario: TC 25541 : Location field accepts 255 characters
	Given user is successfully logged into biberk
	When user clicks ' apps ' icon button
	When user clicks Claim right menu button
	When user clicks New FNOL Button
	And user waits for spinner to load
	And user enters 255 characters in Location description field
	Then user verifies 256 characters in field is not accepted
