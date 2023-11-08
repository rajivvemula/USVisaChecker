Feature: WC_HairSalon_I
Navigate UW page, Quote details page and payment page
Keyword: Hair Salon
Yes I have Employee
Number of employee : 2-5
Business Operation: I Lease a Space From Others
Included Officer: 1
Business started year : Started 7 years ago
Business Structured: LLC
EechAccidentPolicyEachEmpLimit: 100,000/500,000/100,000  
Payment Option: 15% Down + 9 Monthly Installments 


Scenario: WC Hair Salon creates issued policy for Pennsylvania
	Given user starts a quote with:
	| Industry   | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Hair Salon | 5         | I Lease a Space From Others |              | 18706    | WC  |
