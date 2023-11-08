Feature: ReportClaim_PL

Logic to unit test the submission of A PL claim and verify the submissions page

@Claims @PL @Unit 
Scenario: ReportClaim_PL
	Given user has navigated to the following URL within the host environment: /policyholders/claims/professional-liability
	Then user validates the PL Claim page elements
	And user validates the PL Claims page error messages
	When user fills out the PL Claims page with these values:
		| Question          | Answer                                 |
		| Policy Number     | N9PL913392                             |
		| Business Name     | TestingB                               |
		| First Name        | TestF                                  |
		| Last Name         | TestL                                  |
		| Phone             | 8407673450                             |
		| Ext               |                                        |
		| How to Connect    | testemail@gmail.com                    |
		| Date of Injury    | 11/09/2022                             |
		| Injury Location   | Work Place                             |
		| Short Description | This is the Testing Claims description |
	And user clicks on the Submit Claim Button
	Then user verifies the Claims Submitted page