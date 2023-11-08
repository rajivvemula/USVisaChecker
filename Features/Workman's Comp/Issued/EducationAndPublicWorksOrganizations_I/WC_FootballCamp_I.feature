Feature: WC_FootballCamp_I
Issued Policy for the 
Keyword: Football Camp
Employee option: 8
ZIP code: 24751
Business Structured: LLC
Business Operation: I Lease a Space From Others
Business started year : Been around a while, started 10 or more years ago
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000 
Payment Option: 15% Down + 9 Monthly Installments

Partial feature file for implementing the "When user saves their quote for later by sending it to the following email(s):" step

Scenario: WC Football Camp creates issued policy in West Virginia
	Given user starts a quote with:
		| Industry      | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Football Camp | 8         | I Lease a Space From Others |              | 24751    | WC  |
	When user saves their quote for later by sending it to the following email(s): Email1@test.com