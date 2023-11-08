Feature: WC_FulfillmentCenter_I
Issued Policy
Keyword: Fulfillment Center
Zip Code: 73344
Employee option: 30
Business Operation: I Run My Business From Property I Own
Years in Businiess: Started 8 years ago
Payroll: 1,550,000
Entity type: LLC
Payment option: 25% Down + 8 Monthly Installments

 
Scenario: WC Fulfillment Center creates issued policy in Texas
	Given user starts a quote with:
	| Industry           | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Fulfillment Center | 30        | I Run My Business From Property I Own |              | 73344    | WC  |
