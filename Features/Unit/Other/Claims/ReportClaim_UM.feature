Feature: ReportClaim_UM

Verifying Reporting a Claim scenario for Umbrella Insurance

@Claims @Unit @UM
Scenario: Report a Claim for UM
	Given user has navigated to the following URL within the host environment: policyholders/claims/umbrella
	Then user validates the UM Claim page elements
	And user verifies the UM Claims page error messages
	When user fills out the UM Claims page with these values:
		| Question          | Answer                                 |
		| Policy Number     | N9PL056696                             |
		| Business Name     | TestingB                               |
		| First Name        | TestF                                  |
		| Last Name         | TestL                                  |
		| Phone             | 8407673452                             |
		| Ext               |                                        |
		| How to Connect    | testemail@gmail.com                    |
		| Date of Injury    | 11/09/2022                             |
		| Injury Location   | Work Place                             |
		| Short Description | This is the Testing Claims description |
	And user clicks on the Submit Claim Button
	Then user verifies the Claims Submitted page