Feature: ReportClaim_GL

Verifying Reporting a Claim scenario for General Liability

@Claims @Unit @GL
Scenario: Report a Claim for GL
	Given user has navigated to the following URL within the host environment: policyholders/claims/general-liability
	Then user validates the GL Claim page elements
	And user verifies the GL Claims page error messages
	When user fills out the GL Claims page with these values:
		| Question                      | Answer                                |
		| Policy Number                 | N9PL056696                            |
		| Business Name                 | TestingB                              |
		| First Name                    | TestF                                 |
		| Last Name                     | TestL                                 |
		| Phone                         | 8407673450                            |
		| Ext                           |                                       |
		| How to Connect                | testemail@gmail.com                   |
		| Date of Injury                | 11/12/2022                            |
		| Injury Location               | Work Place                            |
		| Short Description             | This is the Report Claims description |
	And user clicks on the Submit Claim Button
	Then user verifies the Claims Submitted page