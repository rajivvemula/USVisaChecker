Feature: Industries_AB

Page validation for following Industries pages:
- Accounting & Finance
- Advertising & Graphic Design
- Apartments & Other Buildings
- Associations & Clubs
- Auto Services & Dealers
- Bakery

@Industries @Unit @Regression @Static
Scenario Outline: Validate Industries pages A_B
	Given user has navigated to the following URL within the host environment: <url>
	When user validates the <industry> industry page
	Then user validates coverages cards: <coverages>
	And user sees links in the following coverages: <links>

Examples:
	| url                                                | industry                     | coverages                   | links                    |
	| who-we-insure/accounting-finance-insurance         | Accounting & Finance         | WC;GL;BOP;PL;Cyber;Umbrella | GL;BOP;PL;Cyber;Umbrella |
	| who-we-insure/advertising-graphic-design-insurance | Advertising & Graphic Design | GL;BOP;PL;Cyber;CA;Umbrella |                          |
	| who-we-insure/apartments-other-buildings-insurance | Apartments & Other Buildings | WC;BOP;Umbrella             |                          |
	| who-we-insure/advertising-graphic-design-insurance | Advertising & Graphic Design | GL;BOP;PL;Cyber;CA;Umbrella |                          |
	| who-we-insure/associations-clubs-insurance         | Associations & Clubs         | WC;GL;BOP;Cyber;CA;Umbrella |                          |
	| who-we-insure/auto-dealer-insurance                | Auto Dealer                  |                             |                          |
	| who-we-insure/bakery-insurance                     | Bakery                       | WC;GL;BOP;CA;Cyber;Umbrella | WC;GL;BOP;CA;Umbrella    |