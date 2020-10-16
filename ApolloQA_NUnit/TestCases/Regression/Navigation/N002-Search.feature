Feature: N002-Search
Test Search Feature


Scenario: User Searches A Value
	When User enters <Value> in search field
	And User selects the first result
	Then User is directed to <policy> URL with ID <10543>
	Then User is directed to Organization