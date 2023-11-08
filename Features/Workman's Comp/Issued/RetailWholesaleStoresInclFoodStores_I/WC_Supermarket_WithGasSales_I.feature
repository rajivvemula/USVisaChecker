Feature: WC_Supermarket_WithGasSales_I
Issued Policy for;
Keyword: Supermarket: With Gas Sales
Yes I have Employee
Number of employee : 8
Business Operation: I Lease a Space From Others
ZIP Code: 30310
Included Officer: 1
Business started year : Brand new venture or Started earlier this year
Business Structured: Partnership
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000  
Payment Option: 15% Down + 9 Monthly Installments 


Scenario: WC Supermarket: With Gas Sales creates issued policy in Georgia
	Given user starts a quote with:
	| Industry                    | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Supermarket: With Gas Sales | 8         | I Lease a Space From Others |              | 30310    | WC  |
