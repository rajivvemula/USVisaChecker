Feature: Industries_CF

Page validation for following Industries pages:
- Cleaning & Janitorial
- Construction & Contractor 
- Consultant
- Cosmetology 
- Electrician 
- Financial Advisor 
- Food Service 

@Industries @Unit @Regression @Static
Scenario Outline: Validate Industries pages C_F
	Given user has navigated to the following URL within the host environment: <url>
	When user validates the <industry> industry page
	Then user validates coverages cards: <coverages>
	And user sees links in the following coverages: <links>

Examples:
	| url                                             | industry                  | coverages                      | links                       |
	| who-we-insure/cleaning-janitorial-insurance     | Cleaning & Janitorial     | WC;GL;BOP;CA;Cyber;Umbrella    |                             |
	| who-we-insure/construction-contractor-insurance | Construction & Contractor | WC;GL;BOP;Cyber;CA;Umbrella    |                             |
	| who-we-insure/consultant-insurance              | Consultant                | WC;GL;BOP;PL;Cyber;Umbrella    | WC;GL;BOP;PL;Cyber;Umbrella |
	| who-we-insure/cosmetology-insurance             | Cosmetology               | WC;GL;BOP;PL;Cyber;CA;Umbrella |                             |
	| who-we-insure/electrician-insurance             | Electrician               | WC;GL;BOP;Cyber;CA;Umbrella    | WC;GL;BOP;Cyber;CA;Umbrella |
	| who-we-insure/financial-advisor-insurance       | Financial Advisor         | WC;GL;BOP;PL;Cyber;CA;Umbrella |                             |
	| who-we-insure/food-service-insurance            | Food Service              | WC;GL;BOP;Cyber;CA;Umbrella    |                             |