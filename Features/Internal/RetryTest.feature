Feature: RetryTest

An internal unit test to verify the retry automation

Background: 
	Given override retry config to allow retries

@Internal @RetryLogic @NoSelenium @Build
Scenario: Test breaks on run and retry is able to pass
	Given test tracks try count
	When test suddenly fails on first run
	Then everything is fine
	And test should run following number of times: 2

@Internal @RetryLogic @NoSelenium @Build
Scenario: Test never requires a retry and still passes
	Given test tracks try count
	When test has no issues
	Then everything is fine
	And test should run following number of times: 1

@Internal @RetryLogic @NoSelenium @TrackFailingSteps @Build
Scenario: Test that would have failed normally doesn't magically pass on retry
	Given test tracks try count
	When test fails consistently
	Then test should normally fail
	And test should run following number of times: 2

@Internal @RetryLogic @NoSelenium @TrackFailingSteps @Build
Scenario: Test should not retry if error is blacklisted for retry
	Given test tracks try count
	When test fails once in a way that shouldn't retry
	Then test should normally fail
	And test should run following number of times: 1

@Internal @RetryLogic @NoSelenium @Build
Scenario: Test should retry on a step if it is flagged when it normally would retry anyway
	Given test tracks try count
	And next step is unstable and should retry if failed
	When test suddenly fails on first run
	Then everything is fine
	And test should run following number of times: 2

@Internal @RetryLogic @NoSelenium @Build
Scenario: Test should retry on a step if it is flagged when it is normally blacklisted
	Given test tracks try count
	And next step is unstable and should retry if failed
	When test fails once in a way that shouldn't retry
	Then everything is fine
	And test should run following number of times: 2
