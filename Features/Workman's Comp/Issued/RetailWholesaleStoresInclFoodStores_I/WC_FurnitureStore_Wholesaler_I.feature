Feature: WC_FurnitureStore_Wholesaler_I
Issued Policy for Keyword: Furniture Store: Wholesaler
Yes I have Employee
Number of employee : 12
Business Operation: I Run My Business From Property I Own
ZIP Code: 20147
Included Officer: 2
Business started year : Started 3 years ago
Business Structured: Sub-Chapter Corp
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000  
Payment Option: 25% Down + 6 Monthly Installments 


Scenario: WC Furniture Store: Wholesaler creates issued policy in Virginia
	Given user starts a quote with:
	| Industry                    | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Furniture Store: Wholesaler | 12        | I Run My Business From Property I Own |              | 20147    | WC  |
