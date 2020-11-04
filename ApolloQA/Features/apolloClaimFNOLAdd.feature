Feature: apolloClaimFNOLAdd


@biBerkClaimFNOLAdd @SmokeTest
Scenario: Carrier Pigeon Is not a how notice was received option
	Given user is successfully logged into biberk
	When user clicks on waffle menu
	And user clicks on Claims
	And user clicks on addFNOL button to begin an FNOL report
	Then user verifies 'Carrier Pigeon' is not an option

Scenario: Create an Occurrence successfully
	Given user is successfully logged into biberk
	When user clicks on waffle menu
	And user clicks on Claims
	And user clicks on addFNOL button to begin an FNOL report
	And user enters occurrence information for Policy
	And user selects 'No' this occurrence related to an existing claim