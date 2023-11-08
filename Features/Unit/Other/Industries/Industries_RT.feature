Feature: Industries_RT

Page validation for following Industries pages:
-Real Estate
-Restaurant
-Retail
-Salons & Spas
-Small Business
-Townhouse Associations
-Transportation
@Industries @Unit @Regression @Static
Scenario Outline: Validate Industries pages R_T
	Given user has navigated to the following URL within the host environment: <url>
	When user validates the <industry> industry page
	Then user validates coverages cards: <coverages>
	And user sees links in the following coverages: <links>

Examples:
	| url                                                | industry                   | coverages                      | links |
	| who-we-insure/real-estate-title-mortgage-insurance | Real Estate Title Mortgage | WC;GL;BOP;PL;CA;Cyber;Umbrella |       |
	| who-we-insure/restaurant-insurance                 | Restaurant                 | WC;GL;BOP;CA;Cyber;Umbrella    |       |
	| who-we-insure/retail-insurance                     | Retail                     | WC;GL;BOP;CA;Cyber;Umbrella    |       |
	| who-we-insure/salons-spas-insurance                | Salons Spas                | WC;GL;BOP;PL;CA;Cyber;Umbrella |       |
	| who-we-insure/small-business-insurance             | Small Business             | WC;GL;BOP;PL;CA;Cyber;Umbrella |       |
	| who-we-insure/hoa-insurance                        | HOA                        | WC;GL;BOP;CA;Cyber;Umbrella    |       |
	| who-we-insure/commercial-truck-insurance           | Commercial Truck           | WC;GL;BOP;CA;Cyber             |       |