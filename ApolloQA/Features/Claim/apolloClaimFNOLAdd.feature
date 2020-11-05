Feature: apolloClaimFNOLAdd


@biBerkClaimFNOLAdd @SmokeTest
Scenario: Carrier Pigeon Is not a how notice was received option
	Given user is successfully logged into biberk
	When user clicks  apps  icon Button
	When user clicks  Claim  Button
	When user clicks  New FNOL  Button
	Then user verifies 'Carrier Pigeon' is not an option

Scenario: Create an Occurrence successfully
	Given user is successfully logged into biberk
	When user clicks  apps  Button
	When user clicks  Claim  Button
	When user clicks  New FNOL  Button
	And user enters occurrence information for Policy
	And user selects 'No' this occurrence related to an existing claim
	And user enters Reported by contact information
	And user enters catastrophe and claimant contact info
	And user enters police involved info - 'Yes'
	And user enters fire involved info - 'Yes'
	When user clicks  Save  Button
	Then user asserts for Occurence save

Scenario: User cancels an Occurrence addition
	Given user is successfully logged into biberk
	When user clicks  apps  Button
	When user clicks  Claim  Button
	When user clicks  New FNOL  Button
	And user enters occurrence information for Policy
	And user selects 'No' this occurrence related to an existing claim
	And user enters Reported by contact information
	And user enters catastrophe and claimant contact info
	And user enters police involved info - 'Yes'
	And user enters fire involved info - 'Yes'
	When user clicks  Cancel  Button
	When user clicks Continue anyway Button
	Then user asserts for Occurence cancel
