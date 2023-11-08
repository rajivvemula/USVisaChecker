Feature: Resetting

Tests that are resettable context objects are configured for the smart reset on retries

@Internal @Resetting @Build @NoSelenium
Scenario: Test Resetting
	Given this is a resetting test
	Then resettables should have valid defaults
