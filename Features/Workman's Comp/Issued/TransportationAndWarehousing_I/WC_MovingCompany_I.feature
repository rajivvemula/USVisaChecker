Feature: WC_MovingCompany_I
Issued Policy
Keyword: Moving Company
Zip Code: 60618
City: Long Key
Employee option: 10
Business Operation: I Run My Business From Property I Own
Years in Businiess: Been around a while, started 10 or more years ago
Payroll: 1,250,000
Entity type: LLC
Payment option: 15% Down + 9 Monthly Installments


Scenario: WC Moving Company creates issued policy in Illinois
	Given user starts a quote with:
	| Industry       | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Moving Company | 10        | I Run My Business From Property I Own |              | 60618    | WC  |
