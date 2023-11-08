Feature: WC_LoungeOrNightClub_I
Issued Policy for:
Keyword: Lounge Or Night Club
Employee option: Various employees - 6
ZIPCode: 13838
Employee Payroll: 300,000
Entity type: Limited Liability Co. (LLC)
Years in business: 1
Included owner officers: No
Excluded owner officer: 1
EL Limits: 100K/500K/100K
Payment Option: 25% Down + 6 Monthly Installments
Credit card: Discover


Scenario: WC Lounge Or Night Club creates issued policy in NY
	Given user starts a quote with:
	| Industry             | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Lounge Or Night Club | 6         | I Lease a Space From Others |              | 13838    | WC  |
