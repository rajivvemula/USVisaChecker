Feature: ValidateHomePage

@Smoke @Homepage @Static
Scenario: Validate Home Page
	Given user lands on biBerk Home page
	Then user validates the static page: Home
	Then user verifies the navigation to Reviews Page