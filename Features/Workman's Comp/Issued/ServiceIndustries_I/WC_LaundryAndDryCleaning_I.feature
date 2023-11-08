Feature: WC_LaundryAndDryCleaning_I


Scenario: WC Laundry And Dry Cleaning creates issued policy for NY
	Given user starts a quote with:
	| Industry                 | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Laundry and Dry Cleaning | 5         | I Run My Business From Property I Own |              | 11223    | WC  |
