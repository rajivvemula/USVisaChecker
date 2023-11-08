Feature: Industries_HI

Page validation for following Industries pages:
- Handyman
- Healthcare
- Home Inspectors 
- Hotel
- Information Technology 
- Insurance Agents 

@Industries @Unit @Regression @Static
Scenario Outline: Validate Industries pages H_I
	Given user has navigated to the following URL within the host environment: <url>
	When user validates the <industry> industry page
	Then user validates coverages cards: <coverages>
	And user sees links in the following coverages: <links>

Examples:
	| url                                            | industry               | coverages                      | links                      |
	| who-we-insure/handyman-insurance               | Handyman               | WC;GL;BOP;CA;Cyber;Umbrella    |                            |
	| who-we-insure/healthcare-insurance             | Healthcare             | WC;GL;PL;BOP;CA;Cyber;Umbrella | WC;GL;PL;CA;Cyber;Umbrella |
	| who-we-insure/home-inspectors-insurance        | Home Inspectors        | WC;GL;BOP;PL;Cyber;CA;Umbrella |                            |
	| who-we-insure/hotel-insurance                  | Hotel                  | WC;GL;BOP;Cyber;CA;Umbrella    |                            |
	| who-we-insure/information-technology-insurance | Information Technology | WC;GL;BOP;PL;Cyber;CA;Umbrella |                            |
	| who-we-insure/insurance-agents-insurance       | Insurance Agents       | WC;GL;BOP;PL;CA;Umbrella       |                            |