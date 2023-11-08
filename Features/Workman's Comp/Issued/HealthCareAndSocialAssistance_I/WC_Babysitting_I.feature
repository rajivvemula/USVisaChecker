Feature: WC_Babysitting_I
Issued Policy for;
Keyword: Babysitting
Employee option: Various employees - 8
ZIPCode: 11237
Employee Payroll: Null
Entity type: Corporation
Years in business: Started 5 years ago
Included owner officers: Yes 2
Excluded owner officer: 0
EL Limits: 100K/500K/100K
Payment Option: 40% Down + 2 Quarterly Installments
Credit card: Discover


Scenario: WC Babysitting creates issued policy in NY
	Given user starts a quote with:
	| Industry    | Employees | Location                         | Own or Lease | ZIP Code | LOB |
	| Babysitting | 8         | I Run My Business Out of My Home |              | 11237    | WC  |
