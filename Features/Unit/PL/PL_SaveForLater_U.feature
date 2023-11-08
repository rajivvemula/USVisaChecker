Feature: PL_SaveForLater_U

@PL @Unit @Staging @Regression
Scenario: PL Save For Later
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Attorney | 7         | I Lease a Space From Others |              | 17404    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business       | Business Address | DBA             | LLC |
		| Corporation        | Test PL Save For Later | 1060 Church Rd   | Test LLC in DBA | Yes |
	Then user verifies the appearance of the Save in PL Business Details page
	Then user enter the following email "test@biberk.com" to save for later
	Then user verifies confirmation popup is displayed
		| Text                                             |
		| We emailed you a link to your saved application. |