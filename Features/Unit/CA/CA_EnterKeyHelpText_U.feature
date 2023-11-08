Feature: CA_EnterKeyHelpText_U

Unit test that verifies that the help text does not appear when pressing the enter key after every question, Issued in Illinois

@Staging @Unit @Regression
Scenario: CA Enter Key Help Text Unit
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 0         | I Lease a Space From Others | Vehicles     | 60101    | CA  |
	Then user verifies the appearance of the Start Your Quote page
	Then user fills in the Start Your Quote page with these values:
		| Name of Business | DBA      | Policy Start Date |
		| Test CA          | Test DBA |                   |
	When user presses enter after selecting each relevant field on the Let's Start Your Quote page
	Then user verifies that no help text messages are displayed
	Then user clicks continue from the Start Your Quote page
	Then user verifies the appearance of the Introduction page
	And user fills in the Introduction page with these values:
		| Year Business Started | How Business Structured     | Address1      | Address2 | City    | Select an Address |
		| 2015                  | Limited Liability Co. (LLC) | 233 N Mill Rd |          | Addison |                   |
	When user presses enter after selecting each relevant field on the A Quick Introduction page
	Then user verifies that no help text messages are displayed
	Then user clicks continue from CA Introduction
	Then user verifies the appearance of the Vehicles page
	And user creates a vehicle or trailer with variable values:
		| No VIN            | Type Insure | Year | Make       | Model      | Parking Address | Vehicle Worth | How Used          | Deliver Goods |
		| 3VWCA21C9XM407107 | Car - Coupe | 1999 | VOLKSWAGEN | New Beetle | Illinois        | 3000          | Delivery/Catering | Yes           |
	When user presses enter after selecting each relevant field on the Your Vehicles page
	Then user verifies that no help text messages are displayed
	And user clicks Let's Continue
	Then User verifies appearance of the Drivers Page
	And user creates a driver with these values:
		| FirstName | LastName | DLState | DOB        | Accident | DLNumber     |
		| TEST FN   | TEST LN  | IL      | 09/01/1991 | No       | H11112222333 |
	When user presses enter after selecting each relevant field on the Your Drivers page
	Then user verifies that no help text messages are displayed
	And user clicks continue from the Drivers page
	Then user fills out the Operations page:
		| Question                                                                                    | Answer           |
		| What is the furthest any of your vehicles travel in any one direction from their home base? | 50 miles or less |
		| How many auto insurance claims did your business file in the last 3 years?                  | 0                |
	When user presses enter after selecting each relevant field on the Your Operations page
	Then user verifies that no help text messages are displayed
	Then user continues to the Contact page
	And user enters contact information:
		| Question           | Answer                  |
		| First Name         | TEST F                  |
		| Last Name          | TEST L                  |
		| Business Email     | John.Taggart@biberk.com |
		| Business Phone     | (123) 123-1321          |
		| Business Website   | test.com                |
		| Want Save Money    | Yes                     |
		| Owner's First Name | TEST FN                 |
		| Owner's Last Name  | TEST LN                 |
		| Owner's Address    | 530 W Stevens Dr        |
		| Owner's Address 2  |                         |
		| Owner's Zip Code   | 60101                   |
		| Owner's City       | Addison                 |
		| Owner's State      | Illinois                |
	Then user verifies the appearance of the Summary page
	Then user clicks continue from the Summary page
	Then user verifies the appearance of the Quote Page
	And user completes their Quote
		| Question           | Answer                                                    |
		| Yearly             | Yes                                                       |
		| Policy Coverages   | $100,000 Combined Single Limit                            |
		| Vehicle 1 Coverage | $500 Comprehensive Deductible / $500 Collision Deductible |
	Then user clicks continue from the Quote page
	Then user verifies the appearance of the Additional Information page
	And user fills out the Additional Information page:
		| VIN               | OLF   | Who Holds Vehicle |
		| 3VWCA21C9XM407107 | Owned | The Business      |
	Then user clicks continue from Additional Information
	Then user goes to purchase a plan using the following information:
		| Payment Plan | Card Type |
		| 12 Monthly   | Visa      |
	Then user clicks purchase