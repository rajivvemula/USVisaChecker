Feature: WC_PortableToiletLeasing_I
Keyword:Portable Toilet Leasing
Yes I have Employee
Number of employee : 3
ZIP Code: 10001
Business Operation: I Lease a Space From Others
Included Officer: 3
Business started year : Started 8 years ago
Business Structured: LLC
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000  
Payment Option: 25% Down + 6 Monthly Installments


Scenario: WC Portable Toilet Leasing creates issued policy for NY
	Given user starts a quote with:
	| Industry                | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Portable Toilet Leasing | 3         | I Lease a Space From Others |              | 10001    | WC  |
 