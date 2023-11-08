Feature: 1000PlusEmployeesModalVerification

Unit test for verifying the 1000+ employees modal

@Unit @Regression
Scenario: 1000+ employees - Yes
	Given user starts a quote with:
		| Industry   | Employees |
		| Accountant | 1001      |
	When user responds with Yes to the over 1000 employees modal
	Then the madlibs location screen will appear

@Unit @Regression
Scenario: 1000+ employees - No
	Given user starts a quote with:
		| Industry   | Employees |
		| Accountant | 1001      |
	When user responds with No to the over 1000 employees modal
	Then the over 1000 employees modal will be closed