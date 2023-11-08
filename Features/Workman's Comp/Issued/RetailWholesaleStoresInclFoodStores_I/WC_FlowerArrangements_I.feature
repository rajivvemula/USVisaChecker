Feature: WC_FlowerArrangements_I
Issued Policy for;
Keyword: Flower Arrangements
Employee option: Various employees - 2
ZIPCode: 96713
Employee Payroll: 300,000
Entity type: Corporation
Years in business: 5
Included owner officers: No
Excluded owner officer: 1
EL Limits: 100K/500K/100K
Payment Option: 25% Down + 6 Monthly Installments
Credit card: Master card
HI UI #	0675309


Scenario: WC Flower Arrangements creates issued policy in Hawaii
	Given user starts a quote with:
	| Industry            | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Flower Arrangements | 2         | I Run My Business From Property I Own |              | 96713    | WC  |
 