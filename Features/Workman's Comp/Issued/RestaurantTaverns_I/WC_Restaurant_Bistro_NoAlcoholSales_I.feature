Feature: WC_Restaurant_Bistro_NoAlcoholSales_I
Issued Policy for;
Keyword: Restaurant: Bistro; No Alcohol Sales
Employee option: Various employees - 10
ZIPCode: 11238
Employee Payroll: 880,000
Entity type: Limited Liability Co. (LLC)
Years in business: 6
Included owner officers: 1
Excluded owner officer: 1
EL Limits: 100K/500K/100K
Payment Option: 25% Down + 6 Monthly Installments


Scenario: WC Restaurant: Bistro No Alcohol Sales policy issued in NY
	Given user starts a quote with:
	| Industry                             | Employees | Location                           | Own or Lease | ZIP Code | LOB |
	| Restaurant: Bistro; No Alcohol Sales | 10        | I Own a Property & Lease to Others |              | 11238    | WC  |
