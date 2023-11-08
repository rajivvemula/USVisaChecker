Feature: QuoteSaving

Ensuring tests are able to save quote ID for future use

@Internal @QuoteSave
Scenario: test saves a PL quote ID
	Given no quote ID is set
	And user starts a quote with:
		| Industry            | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Magazine Publishing | 3         | I Lease a Space From Others |              | 67155    | PL  |
	When user saves their PL quote ID
		| Industry            | State  |
		| Magazine Publishing | Kansas |
	Then saved quote ID should persist
	And output the saved quote ID

@Internal @QuoteSave
Scenario: test saves a CA quote ID
	Given no quote ID is set
	And user starts a quote with:
		| Industry   | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Food Truck | 0         | I Run My Business From Property I Own | Vehicles     | 60004    | CA  |
	When user saves their CA quote ID
		| Industry   | State    |
		| Food Truck | Illinois |
	Then saved quote ID should persist
	And output the saved quote ID

@Internal @QuoteSave
Scenario: test saves a WC quote ID
	Given no quote ID is set
	And user starts a quote with:
		| Industry                                                 | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Acoustical Insulation Material Installation: No Ceilings | 3         | I Lease a Space From Others |              | 85383    | WC  |
	When user saves their WC quote ID
		| Industry   | State    |
		| Acoustical Insulation Material Installation: No Ceilings | Illinois |
	Then saved quote ID should persist
	And output the saved quote ID

@Internal @QuoteSave
Scenario: test saves a CA quote ID with a reason
	Given no quote ID is set
	And user starts a quote with:
		| Industry   | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Food Truck | 0         | I Run My Business From Property I Own | Vehicles     | 60004    | CA  |
	When user saves their CA quote ID
		| Industry   | State    | Save Reason                  |
		| Food Truck | Illinois | Want to send to app insights |
	Then saved quote ID should have a reason
	And output the saved quote ID

@Internal @QuoteSave
Scenario: test saves a CA quote ID without a reason
	Given no quote ID is set
	And user starts a quote with:
		| Industry   | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Food Truck | 0         | I Run My Business From Property I Own | Vehicles     | 60004    | CA  |
	When user saves their CA quote ID
		| Industry   | State    |
		| Food Truck | Illinois |
	Then saved quote ID should not have a reason
	And output the saved quote ID