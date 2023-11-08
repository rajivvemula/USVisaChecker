Feature: WC_AutoPartsRetail_I
Issued Policy for the 
Keyword: Retail Store: Automotive Parts
Employee option: 10
ZIP code: 35143
Business Structured: Corporation
Business Operation: I Lease a Space From Others  
Business started year : Started 8 years ago
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000 
Payment Option: 15% Down + 9 Monthly Installments
Credit card type: Discover



Scenario: WC Retail Store: Automotive Parts creates issued policy for Alabama
  Given user starts a quote with:
	| Industry                       | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Retail Store: Automotive Parts | 10        | I Lease a Space From Others |              | 35143    | WC  |



