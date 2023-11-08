Feature: WC_ManufacturingFoodProducts_I
Keyword: Manufacturing: Food Products
Yes I have Employee
Number of employee : 20
ZIP Code: 11205
Business Operation: I Lease a Space From Others
Included Officer: 3
Business started year : Started 7 years ago
Business Structured: LLC
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000  
Payment Option: 25% Down + 6 Monthly Installments


Scenario: WC Manufacturing: Food Products policy issued in NY
	Given user starts a quote with:
	| Industry                     | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Manufacturing: Food Products | 20        | I Lease a Space From Others |              | 11205    | WC  |
 