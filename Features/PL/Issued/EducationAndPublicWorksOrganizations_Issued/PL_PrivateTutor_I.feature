Feature: PL_PrivateTutor_I

US 71963

Scenario: PL PrivateTutor verify details of your quote page
	Given user starts a quote with:
		| Industry      | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Private Tutor | 7         | I Lease a Space From Others |              | 35747    | PL  |
	Then user verifies that the following coverages are displayed in the details of their PL Plus Quote: PL,Sexual Abuse