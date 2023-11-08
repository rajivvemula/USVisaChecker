Feature: CA_DriversPageHelpAndError_U

Scenario verifying Help and Error Texts

@Unit @NV @CA @Transportation
Scenario: CA Drivers Page Help Error Text Unit
	Given user starts a quote with:
		| Industry                  | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Delivery: Courier Service | 3         | I Work at a Job Site | Vehicles     | 31201    | CA  |
	Then user verifies the appearance of the Start Your Quote page 
	Then user fills in the Start Your Quote page with these values:
	#Name of Business is randomized if left blank or "Random" is set as the value.
	#DBA is randomized only if "Random" is set as the value.  If no value is set, DBA will not be selected
	#Policy Start Date will default to tomorrow's date if left empty.  Otherwise format is "MM/DD/YY" or "MM/DD/YYYY"
		| Name of Business | DBA         | Policy Start Date |
		| TEST CA QUOTE    | TEST CA DBA |                   |
	Then user clicks continue from the Start Your Quote page
    Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1     | Address2 | City  | Select an Address |
		| 2000                  | Corporation             | 550 Gray Hwy |          | Macon | Original          |
	Then user clicks continue from CA Introduction
    Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address |
		| 3N1AB6AP9CL760256 | Georgia         |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	Then user verifies the following front end help and error element on the CA Drivers page:
		| Question Alias | Type  |
		| firstName      | Error |
		| lastName       | Error |
	Then user verifies the following Apollo help and error element on the CA Drivers page:
		| Question Alias      | Type  |
		| AccidentOrViolation | Help  |
		| DriverLicenseState  | Error |
		| DriverDOB           | Error |
		| CDL                 | Error |
		| AccidentOrViolation | Error |