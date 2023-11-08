Feature: WC_ElectricalWork_I
Get quote details, payment and issued policy.
Keyword: Electrical Work
Employee option: No Employee
ZIP code: 68008
Business Structured: LLC
Business Operation: I Lease a Space From Others
Business started year : Started 7 years ago
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000 
Payment Option: 15% Down + 9 Monthly Installments
Credit card type: American Express


Scenario: WC Electrical Work creates issued policy in Nebraska
  Given user starts a quote with:
	| Industry        | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Electrical Work |           | I Lease a Space From Others |              | 68008    | WC  |
 