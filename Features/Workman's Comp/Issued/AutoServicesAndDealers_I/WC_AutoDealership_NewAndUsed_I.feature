Feature: WC_AutoDealership_NewAndUsed_I
Issued Policy for the 
Keyword: Auto Dealership: New and Used
Employee option: 30
ZIP code: 35143
Business Structured: LLC
Business Operation: I Lease a Space From Others  
Business started year : Started 8 years ago
Payroll: 1,800,000
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000 
Payment Option: 15% Down + 9 Monthly Installments
Credit card type: Discover



Scenario: WC Auto Dealership: New And Used policy issued for Alabama
  Given user starts a quote with:
	| Industry                      | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Auto Dealership: New and Used | 30        | I Lease a Space From Others |              | 35143    | WC  |
