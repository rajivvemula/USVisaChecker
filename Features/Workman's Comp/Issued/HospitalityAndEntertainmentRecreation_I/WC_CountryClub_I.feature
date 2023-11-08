Feature: WC_CountryClub_I
Issued Policy for;
Keyword: Country Club
Employee option: Various employees
ZIPCode: 07050
Employee Payroll: 100,000
Entity type: LLC
Years in business: 5
Included owner officers: Yes 1
Excluded owner officer: 2
EL Limits: 100K/500K/100K


Scenario: WC Country Club creates issued policy in New Jersey
	Given user starts a quote with:
	| Industry     | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Country Club | 5         | I Lease a Space From Others |              | 07050    | WC  |

