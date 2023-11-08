Feature: WC_PawnShop_I
Issued Policy for the 
Keyword: Pawn shop
Employee option: 2
ZIP code: 19131
Business Structured: Partnership
Business Operation: I Lease a Space From Others  
Business started year : Started 8 years ago
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000 
Payment Option: 15% Down + 9 Monthly Installments
Credit card type: Discover


Scenario: WC Pawn Shop creates issued policy in PA
	Given user starts a quote with:
	| Industry  | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Pawn Shop | 2         | I Lease a Space From Others |              | 19131    | WC  |
