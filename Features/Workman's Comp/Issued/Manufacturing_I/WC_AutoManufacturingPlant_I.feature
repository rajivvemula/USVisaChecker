Feature: WC_AutoManufacturingPlant_I
Issued Policy for Keyword: Auto Manufacturing Plant
Number of employee : 13
Business Operation: I Lease a Space From Others
ZIP Code: 35401
Included Officer: 3
Excluded Officer: 1
Business started year : Been around a while, started 10 or more years ago
Business Structured: LLC
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000 


Scenario: WC Auto Manufacturing Plant creates issued policy in Alabama
	Given user starts a quote with:
	| Industry                 | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Auto Manufacturing Plant | 13        | I Lease a Space From Others |              | 35401    | WC  |