Feature: WC_FitnessCenter_I
Issued Policy for Keyword: Fitness Center
Employee option: Various employees - 20
ZIPCode: 85085
Employee Payroll: 1,480,000
Entity type: LLC
Years in business: Started 5 years ago
Included owner officers: 4
Excluded owner officer: 1
EL Limits: 100,000/500,000/100,000
Payment Option: 20% Down + 9 Monthly Installments



Scenario: WC Fitness Center creates issued policy in Arizona
	Given user starts a quote with:
	| Industry       | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Fitness Center | 20        | I Run My Business From Property I Own |              | 85085    | WC  |
