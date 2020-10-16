Feature: F004-FNOLOccurenceNegativeTests
Negative Tests for FNOL Occurence Page


Scenario: Negative Tests
	Then Verify Date of Loss - cannot be a future date.
	Then Verify Time of Loss - default time
	Then Verify How Received contains phone - email - carrier pigeon
	Then Verify Date Reported - defaults to today
	Then Verify CAT defaults to None and has option1 and option2