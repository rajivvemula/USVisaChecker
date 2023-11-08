Feature: WC_BakeryStore_Retail_I
Issued Policy for Keyword: Bakery Store: Retail
Yes I have Employee
Number of employee : 5
Business Operation: I Run My Business From Property I Own
ZIP Code: 07010
Included Officer: 1
Business started year : Started 9 years ago
Business Structured: Corporation
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000  
Payment Option: 15% Down + 9 Monthly Installments 


Scenario: WC Bakery Store: Retail creates issued policy in New Jersey
	Given user starts a quote with:
	| Industry             | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Bakery Store: Retail | 8         | I Run My Business From Property I Own |              | 07010    | WC  |
