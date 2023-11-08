Feature: CA_Actor_D

@Hospitality @Declined @Regression @Cali @CA @FMCSA
Scenario: CA_Actor gets declined making a policy for California
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Actor    | 2         | I Lease a Space From Others | Vehicles     | 96039    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA | Policy Start Date |
		| TEST CA DECLINE  |     |                   |
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured | Address1    | Address2 | City       | Select an Address |
		| 2006                  | Partnership             | 100 Main St |          | Happy Camp | Original          |
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| No VIN | Type Insure | Year | Make | Model    | Parking Address | Vehicle Worth |
		|        | SUV         | 2009 | GMC  | YUKON XL | California      | 18000         |
	Then user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | CDL | ILDDC | ILViolation | ILDLRevoked | Accident | DLNumber |
		| TEST FN   | TEST LN  | CA      | 05/15/1945 |     |       |             |             | Yes      | C1234567 |
	Then user clicks continue from the Drivers page
	Then user verifies the appearance of the Drivers Incidents page
	Then user adds incidents with the following values:
		| Driver          | Date       | Incident Type | At Fault |
		| TEST FN TEST LN | 11/18/2020 | Accident      | No       |
	Then user continues to the Operations page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	Then user continues to the Contact page
	Then user verifies appearance of the contacts page
	And user enters contact information:
		| Question                        | Answer                  |
		| First Name                      | TEST FN                 |
		| Last Name                       | TEST LN                 |
		| Business Email                  | QAAutomation@biberk.com |
		| Business Phone                  | (123) 123-1321          |
		| Business Website                |                         |
		| Business has an account manager |                         |
		| Owner's First Name              | TEST FN                 |
		| Owner's Last Name               | TEST LN                 |
		| Owner's Address                 | 100 Main St             |
		| Owner's Address 2               |                         |
		| Owner's Zip Code                | 96039                   |
		| Owner's City                    | Happy Camp              |
		| Owner's State                   | California              |
		| Select an Address               | Original                |
	Then user verifies the appearance of the Decline page