Feature: ReportClaim_CA
Verify Reporting a Claim scenario for Comm Auto.

@Claims @Unit @CA
Scenario: Report a Claim for CA
	Given user has navigated to the following URL within the host environment: policyholders/claims/Commercial-auto
	Then user validates the CA Claim page elements
	And user verifies the CA Claims page error messages
	When user fills out the CA Claims page with these values:
		| Question          | Answer                                |
		| Policy Number     | N9WC606830                            |
		| Business Name     | TestingB                              |
		| First Name        | TestF                                 |
		| Last Name         | TestL                                 |
		| Phone             | 8407673450                            |
		| How to Connect    | testemail@gmail.com                   |
		| Driver First Name | testf                                 |
		| Driver Last Name  | testl                                 |
		| Driver Address    | 1633 Page St                          |
		| ZIP Code          | 80823                                 |
		| City              | Karval                                |
		| Driver Phone      | 5874595555                            |
		| Date of Loss      | 08/01/2023                            |
		| Location of Loss  | Karval                                |
		| Year              | 1997                                  |
		| Make              | ACURA                                 |
		| Short Description | This is the Report Claims description |
	And user clicks on the CA Submit Claim Button
	Then user verifies the Claims Submitted page