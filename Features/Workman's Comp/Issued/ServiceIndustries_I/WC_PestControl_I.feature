Feature: WC_PestControl_I
Keyword: Pest Control
Yes I have Employee
Number of employee : 3
Business Operation: I Work at a Job Site
Excluded Officer: 1 
Business started year : Started 8 years ago
Business Structured: Partnership
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000  
Payment Option: 15% Down + 9 Monthly Installments 


Scenario: WC Pest Control creates issued policy for Connecticut
	Given user starts a quote with:
	| Industry     | Employees | Location             | Own or Lease | ZIP Code | LOB |
	| Pest Control | 3         | I Work at a Job Site |              | 06001    | WC  |
