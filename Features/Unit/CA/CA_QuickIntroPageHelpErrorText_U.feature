Feature: CA_QuickIntroPageHelpErrorText_U

Scenario targeting Help and Error Texts

@unit @Staging @Regression @CA @Retail
Scenario: CA Quick Intro Page Help Error Text Unit Potato Wholesaler In Illinois
	Given user starts a quote with:
	| Industry          | Employees | Location                              | Own or Lease | ZIP Code | LOB |
	| Potato Wholesaler | 2         | I Run My Business From Property I Own | Vehicles     | 60606    | CA  |
	Then user verifies the appearance of the Start Your Quote page 
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
	| Name of Business | DBA | Policy Start Date |
	|                  |     |                   |
	Then user clicks continue from the Start Your Quote page
    Then user verifies the appearance of the Introduction page
	Then user verifies each error element on the CA Introduction page
	Then user verifies each help text element on the CA Introduction page