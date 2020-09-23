Feature: D002-ApplicationInsert
Tests on Application Insert Page


Scenario: App Insert Actions
	When User searches <value> in Business Name
	Then Search <value> displayed is <false>
	When User enters <value> in Business Name
