Feature: 404Error

Ensure that a 404 page exists

@Unit @Smoke @Static
Scenario: 404 shows an error page
	Given user has navigated to the following URL within the host environment: qwetyuioadfhuizvop
	Then user should see a 404 page