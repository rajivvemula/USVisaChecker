Feature: Reviews

Verify the appearence of the reviews page

@Unit @Regression @Static
Scenario: Verify Reviews Page
	Given user has navigated to the following URL within the host environment: about-biberk/reviews
	Then user validates the static page: Reviews