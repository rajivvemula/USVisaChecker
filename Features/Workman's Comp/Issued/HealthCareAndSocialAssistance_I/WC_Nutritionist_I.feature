Feature: WC_Nutritionist_I
Issued Policy for;
Keyword: Nutritionist
Employee option: Various employees - 3
ZIPCode: 03033
Employee Payroll: 200,000
Entity type: Sub-Chapter Corp
Years in business: 6
Included owner officers: Yes 1
Excluded owner officer: 2
EL Limits: 100K/500K/100K
Payment Option: 25% Down + 6 Monthly Installments
Credit card: American Express


Scenario: WC Nutritionist creates issued policy in New Hampshire
	Given user starts a quote with:
	| Industry     | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Nutritionist | 3         | I Lease a Space From Others |              | 03033    | WC  |
 