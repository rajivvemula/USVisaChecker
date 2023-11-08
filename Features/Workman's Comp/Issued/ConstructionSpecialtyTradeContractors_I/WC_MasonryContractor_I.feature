Feature: WC_MasonryContractor_I
Issued Policy for;
Keyword: Masonry Contractor
Employee option: Various employees - 2
ZIPCode: 90001
Employee Payroll: 150,000
Entity type: Limited Liability Co. (LLC)
Years in business: 6
Included owner officers: No
Excluded owner officer: 1
EL Limits: 1,000,000K/1,000,000K/1,000,000K
Payment Option: 10% Down + 10 Monthly Installments
Credit card: Master Card


Scenario: WC Masonry Contractor creates issued policy in California
  Given user starts a quote with:
	| Industry           | Employees | Location                    | Own or Lease | ZIP Code | LOB |
	| Masonry Contractor | 2         | I Lease a Space From Others |              | 90001    | WC  |
