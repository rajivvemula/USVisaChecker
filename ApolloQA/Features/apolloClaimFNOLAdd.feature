Feature: apolloClaimFNOLAdd


@biBerkClaimFNOLAdd @SmokeTest
Scenario: Carrier Pigeon Is not a how notice was received option
	Given user is successfully logged into biberk
	Given user clicks on waffle menu
	When user clicks on Claims
	And user clicks on addFNOL button to begin an FNOL report
	Then user verifies 'Carrier Pigeon' is not an option