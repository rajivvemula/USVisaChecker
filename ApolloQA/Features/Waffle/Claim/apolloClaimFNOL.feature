#TODO
Feature: apolloClaimFNOL

@tc:29860
Scenario: Creates FNOL successfully
	Given user is successfully logged into biberk
	When user clicks ' apps ' icon Button
	When user clicks 'Claim' right menu Button
	When user clicks 'New FNOL' Button
	And user waits for spinner to load
	And user selects 'Yes' this occurrence related to an existing claim
	And user enters occurrence information for Policy
	And user waits for spinner to load
	And user enters loss date and time
	And user enters Location information
	And user enters police involved info - 'Yes'
	And user enters fire involved info - 'Yes'
	When user clicks 'Add Receipt Information' Button
	And user waits for spinner to load
	Then user completes receipt informaiton
	When user clicks 'Add Loss Details' Button
	Then user completes Loss Details information
	When user clicks 'Add Contacts' Button
	When user clicks 'Add Documents' Button
	When user clicks 'Next' Button
	And user selects pending claim to activate
	When user clicks 'Activate a Claim' Button
	And user waits for spinner to load
	Then claim should be successfully activated


	

@ignore
Scenario: TC 25518 User able to search by policy number
	Given user is successfully logged into biberk
	When user clicks ' apps ' icon Button
	When user clicks 'Claim right menu' Button
	When user clicks 'New FNOL' Button
	And user waits for spinner to load
	And user selects 'Yes' this occurrence related to an existing claim
	And user enters occurrence information for Policy
	And user waits for spinner to load
	And user enters loss date and time
	And user selects Location Information from dropdown
	And user enters police involved info - 'No'
	And user enters fire involved info - 'No'
	When user clicks 'Cancel' Button
	When user clicks 'Continue anyway' Button
	Then user asserts for Occurence cancel

@ignore
Scenario: TC 25541 Location field accepts 255 characters
	Given user is successfully logged into biberk
	When user clicks ' apps ' icon Button
	When user clicks 'Claim right menu' Button
	When user clicks 'New FNOL' Button
	And user waits for spinner to load
	And user enters 255 characters in Location description field
	Then user verifies 256 characters in field is not accepted

@ignore
Scenario: TC 25541 Address dropdown provided and include correct Address fields
	Given user is successfully logged into biberk
	When user clicks ' apps ' icon Button
	When user clicks 'Claim right menu' Button
	When user clicks 'New FNOL' Button
	And user waits for spinner to load
	And user selects 'Yes' this occurrence related to an existing claim
	And user enters occurrence information for Policy
	When user validates address dropdwon
	Then user validates Address fields 

@ignore
Scenario Outline: TC 25638 Claim headers visible
	Given user is successfully logged into biberk
	When user clicks ' apps ' icon Button
	When user clicks 'Claim right menu' Button
	When user clicks 'Adjuster Dashboard' Button
	And user waits for spinner to load
	When user selects open claim
	And user waits for spinner to load
	Then claim header is visible on '<Page>'
	Examples: 
		| Page                |
		| Occurrence          |
		| Receipt Information |
		| Loss Details        |
		| Reserves            |
		| Payment             |
		| Recovery            |
		| Medicare            |
		| Contacts            |
		| Documents           |
		| Activities          |

@ignore
Scenario: TC 25656, 25657 Claim headers visible
Given user is successfully logged into biberk
	When user clicks ' apps ' icon Button
	When user clicks 'Claim right menu' Button
	When user clicks 'Adjuster Dashboard' Button
	And user waits for spinner to load
	When user selects open claim
	When user selects Recovery button
	Then user asserts of claims header
	When user selects Salvage button
	Then user asserts of claims header
	When user selects Recovery button
	When user selects Subrogation button
	Then user asserts of claims header




