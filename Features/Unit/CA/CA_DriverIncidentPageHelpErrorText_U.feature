Feature: CA_DriverIncidentPageHelpErrorText_U

Scenario verifying help and error texts for Drivers Incidents Page

@Unit @Regression @CA @Transportation @Cali
Scenario: CA Driver Incident Page Help Error Text Unit Hot Shot Trucking In CA
	Given user starts a quote with:
		| Industry          | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Hot Shot Trucking | 3         | I Work at a Job Site | Vehicles     | 95204    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA         | Policy Start Date |
		| TEST CA QUOTE    | TEST CA DBA |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1             | Address2 | City     | Select an Address |
		| 2000                  | Corporation             | 1687 N California St |          | Stockton |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Trim        | Parking Address | Vehicle Worth |
		| 3N1CB51DX3L800403 | Sedan 4D XE | California      | 3000          |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL                 | Accident | DLNumber |
		| TEST FN   | TEST LN  | CA      | 08/08/1988 | Yes 3 or more years | Yes      | E9758462 |
	Then user clicks continue from the Drivers page
	Then user verifies the appearance of the Drivers Incidents page
	Then user verifies each error element on the CA Driver Incidents page for the following questions:
		| Question Alias     |
		| DriverIncidents    |
		| DriverIncidentDate |
		| DriverIncidentType |
	# set type = accident to show "at fault" question
	Then user adds incidents with the following values:
		| Incident Type |
		| Accident      |
	Then user verifies each error element on the CA Driver Incidents page for the following questions:
		| Question Alias              |
		| DriverAccidentDetermination |
	# set type = violation/conviction to show "what was violation" and "is there another" questions
	Then user edits incident #0 with the following values:
		| Incident Type        |
		| Violation/Conviction |
	Then user verifies each error element on the CA Driver Incidents page for the following questions:
		| Question Alias          |
		| DriverIncidentViolation |
		| DriverIncident2Flag     |
	#set v/c = speeding 16mph over limit to show reckless driving question
	Then user edits incident #0 with the following values:
		| Violation/Conviction                         |
		| Speeding 16 MPH or more over the Speed Limit |
	Then user verifies each error element on the CA Driver Incidents page for the following questions:
		| Question Alias                   |
		| DriverIncidentRecklessConviction |
	Then user verifies each help element on the CA Driver Incidents page for the following questions:
		| Question Alias          |
		| DriverIncidentType      |
		| DriverIncidentViolation |