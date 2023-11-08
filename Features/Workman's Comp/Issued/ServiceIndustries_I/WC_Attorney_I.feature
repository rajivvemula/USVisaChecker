Feature: WC_Attorney_I
Issued Policy for;
Keyword: Attorney
Employee option: Various employees - 12
ZIPCode: 60623
Employee Payroll: 1,250,000
Entity type: LLC
Years in business: Been around a while, started 10 or more years ago
Included owner officers: Yes 2
Excluded owner officer: 1
EL Limits: 100K/500K/100K
Payment Option: 25% Down + 6 Monthly Installments
Credit card: American Express


Scenario: WC Attorney creates issued policy for Illinois
	Given user starts a quote with:
	| Industry | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Attorney | 12        | I Run My Business From Property I Own |              | 60623    | WC  |
