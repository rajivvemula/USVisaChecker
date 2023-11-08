Feature: WC_MattressStore_Retail_I
Issued Policy for Keyword: Mattress Store: Retail
Yes I have Employee
Number of employee : 20
Business Operation: I Lease a Space From Others
ZIP Code: 27006
Included Officer: 2
Business started year : Started 7 years ago
Business Structured: LLC
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000  
Payment Option: 25% Down + 6 Monthly Installments 


Scenario: WC MattressStore: Retail creates issued policy in North Carolina
	Given user starts a quote with:
	| Industry               | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Mattress Store: Retail | 20        | I Lease a Space From Others |              | 27006    | WC  |
 