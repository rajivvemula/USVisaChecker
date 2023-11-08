Feature: WC_ClothingStore_Retail_I
Issued Policy for Keyword: Clothing Store: Retail
Yes I have Employee
Number of employee : 4
Business Operation: I Lease a Space From Others 
ZIP Code: 07030
Included Officer: 1
Business started year : Started 6 years ago
Business Structured: Individual/Sole Proprietor
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000  
Payment Option: 20% Down + 9 Monthly Installments 


Scenario: WC Clothing Store: Retail creates issued policy in NJ
	Given user starts a quote with:
	| Industry               | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Clothing Store: Retail | 4         | I Lease a Space From Others |              | 07030    | WC  |
 