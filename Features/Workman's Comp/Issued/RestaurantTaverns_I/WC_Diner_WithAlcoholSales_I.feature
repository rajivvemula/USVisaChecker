Feature: WC_Diner_WithAlcoholSales_I
Issued Policy for;
Keyword: Restaurant: Diner: With Alcohol Sales
Employee option: Various employees - 20
ZIPCode: 07044
Employee Payroll: 1,880,000
Entity type: Limited Liability Co. (LLC)
Years in business: 9
Included owner officers: 3
Excluded owner officer: 2
EL Limits: 100K/500K/100K
Payment Option: 15% Down + 9 Monthly Installments


Scenario: WC Diner: With Alcohol Sales creates issued policy in New Jersey
	Given user starts a quote with:
	| Industry                  | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Diner: With Alcohol Sales | 20        | I Run My Business From Property I Own |              | 07044    | WC  |
  