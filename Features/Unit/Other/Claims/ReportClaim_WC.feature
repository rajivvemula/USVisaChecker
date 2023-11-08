Feature: ReportClaim_WC

Verifying Reporting a Claim scenario for Workers Compensation

@Claims @Unit @WC
Scenario: Report a Claim for WC
	Given user has navigated to the following URL within the host environment: policyholders/claims/workers-compensation
	Then user validates the WC Claim page elements
	And user verifies the WC Claims page error messages
	When user fills out the WC Claims page with these values:
		| Question                      | Answer                                |
		| Policy Number                 | N9WC606830                            |
		| Business Name                 | TestingB                              |
		| First Name                    | TestF                                 |
		| Last Name                     | TestL                                 |
		| Phone                         | 8407673450                            |
		| Ext                           |                                       |
		| How to Connect                | testemail@gmail.com                   |
		| Injured Worker First Name     | injtestf                              |
		| Injured Worker Last Name      | injtestl                              |
		| Injured Worker Street Address | 1633 Page St                          |
		| ZIP Code                      | 80823                                 |
		| City                          | Karval                                |
		| Injured Worker SSN            | 433635864                             |
		| Injured Worker DOB            | 02/03/1990                            |
		| Injured Worker Phone          | 5874595555                            |
		| Injured Worker Ext            |                                       |
		| Date of Injury                | 10/11/2022                            |
		| Injury Location               | Work Place                            |
		| Short Description             | This is the Report Claims description |
	And user clicks on the Submit Claim Button
	Then user verifies the Claims Submitted page