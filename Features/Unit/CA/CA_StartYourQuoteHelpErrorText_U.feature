Feature: CA_StartYourQuoteHelpErrorText_U
Purpose: Validate error and help text populates in the appropriate fields
@Unit
Scenario: CA Start Your Quote Helo Error Text Unit As Florist 
	Given user starts a quote with:
	| Industry | Employees | Location                           | Own or Lease | ZIP Code | LOB |
	| Florist  | 5         | I Own a Property & Lease to Others | Vehicles     | 60007    | CA  |
	Then user verifies the appearance of the Start Your Quote page 
	Then user verifies the help and error text of the Start Your Quote page