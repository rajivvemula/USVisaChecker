Feature: WC_SchoolBusOperation_I
Issued Policy for the 
Keyword: School Bus Operation
Employee option: 3
ZIP code: 17601
Business Structured: Corporation
Business Operation: I Lease a Space From Others
Business started year : Started 4 years ago
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000 
Payment Option: 15% Down + 9 Monthly Installments


Scenario: WC School Bus Operation creates issued policy in Pennsylvania
	Given user starts a quote with:
	| Industry             | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| School Bus Operation | 3         | I Lease a Space From Others |              | 17601    | WC  |
 