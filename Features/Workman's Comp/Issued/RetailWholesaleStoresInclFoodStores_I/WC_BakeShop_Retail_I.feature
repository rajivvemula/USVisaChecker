Feature: WC_BakeShop_Retail_I
Issued Policy for Keyword: Bake Shop: Retail
Yes I have Employee
Number of employee : 5
Business Operation: I Lease a Space From Others 
ZIP Code: 96202
Included Officer: 1
Business started year : Started 5 years ago
Business Structured: Individual/Sole Proprietor
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000  
Payment Option: 15% Down + 9 Monthly Installments 


Scenario: WC BakeShop: Retail creates issued policy in CA
	Given user starts a quote with:
	| Industry          | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Bake Shop: Retail | 5         | I Lease a Space From Others |              | 92602    | WC  |
