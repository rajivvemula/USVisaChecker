Feature: WC_ChildDayCareCenter_I
Issued Policy for the 
Keyword: Child Day Care Center
Employee option: 8
ZIP code: 30003
Business Structured: LLC
Business Operation: I Run My Business From Property I Own
Business started year : Started 8 years ago
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000 
Payment Option: 25% Down + 6 Monthly Installments
Credit card type: Discover


Scenario: WC Child Day Care Center creates issued policy in Georgia
	Given user starts a quote with:
	| Industry              | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Child Day Care Center | 8         | I Run My Business From Property I Own |              | 30003    | WC  |
