Feature: CA_RemoveButton

Using Remove Button to delete a vehicle, a driver and a driver incident, and a button "No, go back" from a Removal dialog modal

@Unit @Regression @CA
Scenario: Using Remove button and subsequently Go back button for Drivers, Incidents, and Vehicles pages
	Given user starts a quote with:
		| Industry                | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Amazon Delivery Service | 3         | I Lease a Space From Others | Vehicles     | 60185    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business   | DBA | Policy Start Date |
		| TEST CA AUTH QUOTE |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1    | Address2 | City         | Select an Address |
		| 2005                  | Corporation             | 100 Main St |          | West Chicago |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| 2HGFA16517H504306 | Illinois        | 5000          |
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| JH4KA4630JC008595 | Illinois        | 5000          |
	Then user adds another vehicle or trailer
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | Vehicle Worth |
		| KLATA52671B611178 | Illinois        | 6000          |	
	Then user clicks on Remove Vehicle button
	And user verifies the removal modal for a vehicle with answer of No, go back
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | Accident | DLNumber     |
		| John      | Legend   | IL      | 03/13/1986 | No  | Yes      | A12345678910 |
		| Kelly     | Clarkson | IL      | 10/01/1990 | No  | Yes      | B12345678910 |
    And user clicks on Remove Driver button
	And user verifies the removal modal for a driver with answer of No, go back
	Then user clicks continue from the Drivers page
	Then user verifies the appearance of the Drivers Incidents page
	Then user adds incidents with the following values:
		| Driver      | Date       | Incident Type | At Fault |
		| John Legend | 11/11/2021 | Accident      | No       |
		| John Legend | 11/12/2021 | Accident      | No       |
	And user clicks on Remove Incident button
	And user verifies the removal modal for an incident with answer of No, go back