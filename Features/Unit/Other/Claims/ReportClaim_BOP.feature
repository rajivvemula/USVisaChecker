Feature: ReportClaim_BOP
Verify Reporting a Claim scenario for Business Owners Policy

@Claims @Unit @BOP
Scenario: Report a Claim for BOP
	Given user has navigated to the following URL within the host environment: policyholders/claims/property-and-liability
	Then user validates the BOP Claim page elements
	And user verifies the BOP Claims page error messages
	When user fills out the BOP Claims page with these values:
		| Question          | Answer                                |
		| Policy Number     | N9PL056696                            |
		| Business Name     | TestingB                              |
		| First Name        | TestF                                 |
		| Last Name         | TestL                                 |
		| Phone             | 8407673450                            |
		| Ext               |                                       |
		| How to Connect    | testemail@gmail.com                   |
		| Date of Loss      | 11/12/2022                            |
		| Location of Loss  | Work Place                            |
		| Short Description | This is the Report Claims description |
	And user clicks on the Submit Claim Button
	Then user verifies the Claims Submitted page