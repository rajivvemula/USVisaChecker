Feature: WC_Hotel_WithRestaurant_I
Issued Policy for Keyword: Hotel: With Restaurant
Employee option: Various employees - 20
ZIPCode: 33001
Employee Payroll: 1,250,000
Entity type: Limited Liability Co. (LLC)
Years in business: Been around a while, started 10 or more years ago
Included owner officers: 2
Excluded owner officer: 2
EL Limits: 100K/500K/100K
Payment Option: 25% Down + 9 Monthly Installments


Scenario: WC Hotel: With Restaurant creates issued policy in Florida
	Given user starts a quote with:
	| Industry               | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Hotel: With Restaurant | 20        | I Lease a Space From Others |              | 33001    | WC  |
