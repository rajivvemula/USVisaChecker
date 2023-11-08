Feature: WC_Hotel_NoRestaurant_I
Issued Policy for Keyword: Hotel: No Restaurant
Employee option: Various employees - 30
ZIPCode: 33316
Employee Payroll: 1,850,000
Entity type: Limited Liability Co. (LLC)
Years in business: Started 7 years ago
Included owner officers: 3
Excluded owner officer: 2
EL Limits: 100K/500K/100K
Payment Option: 25% Down + 9 Monthly Installments
Credit card: Visa


Scenario: WC Hotel: NoRestaurant creates issued policy in Florida
	Given user starts a quote with:
	| Industry             | Employees | Location                              | Own or Lease | ZIP Code |
	| Hotel: No Restaurant | 30        | I Run My Business From Property I Own |              | 33316    |
 