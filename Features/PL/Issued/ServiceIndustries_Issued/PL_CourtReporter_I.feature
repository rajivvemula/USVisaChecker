Feature: PL_CourtReporter_I

Partial Feature File added for implementing the "Then user verifies the PL thank you page appearance" step logic - US 71969

Scenario: PL Court Reporter verify the PL thank you page (CA, BOP and WC)
	Given user starts a quote with:
		| Industry       | Employees | Location                    | Own or Lease                          | ZIP Code | LOB |
		| Court Reporter | 7         | I Lease a Space From Others | Vehicles;Furniture;Tools or Equipment | 85327    | PL  |
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: CA,BOP,WC

Scenario: PL Court Reporter verify the PL thank you page (GL, CA and WC)
	Given user starts a quote with:
		| Industry       | Employees | Location                         | Client Home | Own or Lease | ZIP Code | LOB |
		| Court Reporter | 7         | I Run My Business Out of My Home | Yes         | Vehicles     | 85327    | PL  |
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: GL,CA,WC