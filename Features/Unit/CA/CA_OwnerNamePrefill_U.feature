Feature: CA_OwnerNamePrefill_U

US 124289 (original Mercury US 103560) - Verifies that the Buisiness name is prefilled as a Primary owner's name on a Contact page/Primary owner's information 
if the Business type is Individual/Sole propriator and Buisness name consists of two words

@Unit @CA @Regression
Scenario: CA Prefilled Contact Page Owner's Name Unit
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 3         | I Lease a Space From Others | Vehicles     | 17404    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		| Best business    |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured    | Address1            | Address2 | City | Select an Address |
		| 2020                  | Individual/Sole Proprietor | 3279 Bitternut Blvd |          | York |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | How Used                            | Deliver Goods |
		| 4T1G11AK3NU618541 | Pennsylvania    | Errands only - no Delivery/Catering | No            |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | Accident | DLNumber |
		| TEST FN   | TEST LN  | PA      | 04/11/1981 | No       | 12345678 |	
	Then user clicks Let's Continue
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question         | Answer         |
		| Want Save Money  | Yes            |
	Then user verifies whether the Owner's name is prefilled

@Unit @CA @Regression
Scenario: CA Non Prefilled Contact Page Owner's Name Unit
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 3         | I Lease a Space From Others | Vehicles     | 17404    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		| Best             |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured    | Address1            | Address2 | City | Select an Address |
		| 2020                  | Individual/Sole Proprietor | 3279 Bitternut Blvd |          | York |                   |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| VIN               | Parking Address | How Used                            | Deliver Goods |
		| 4T1G11AK3NU618541 | Pennsylvania    | Errands only - no Delivery/Catering | No            |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | Accident | DLNumber |
		| TEST FN   | TEST LN  | PA      | 04/11/1981 | No       | 12345678 |	
	Then user clicks Let's Continue
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question         | Answer         |
		| Want Save Money  | Yes            |
	Then user verifies whether the Owner's name is prefilled