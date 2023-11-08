Feature: Industries_LM

Page validation for following Industries pages:
- Landlord
- Laundry Business
- Lawn Care & Landscaping 
- Lawyers
- Liquor Store
- Manufacturers
- Medical Malpractice

@Industries @Unit @Regression @Static
Scenario Outline: Validate Industries pages L_M
	Given user has navigated to the following URL within the host environment: <url>
	When user validates the <industry> industry page
	Then user validates coverages cards: <coverages>
	And user sees links in the following coverages: <links>

Examples:
	| url                                         | industry            | coverages                      | links |
	| who-we-insure/landlord-insurance            | Landlord            | WC;BOP;CA;Cyber;Umbrella       |       |
	| who-we-insure/laundry-businesses-insurance  | Laundry Businesses  | WC;GL;BOP;CA;Cyber;Umbrella    |       |
	| who-we-insure/lawyers-insurance             | Lawyers             | WC;GL;BOP;PL;Cyber;CA;Umbrella |       |
	| who-we-insure/liquor-store-insurance        | Liquor Store        | WC;GL;BOP;Cyber;CA;Umbrella    |       |
	| who-we-insure/manufacturers-insurance       | Manufacturers       |                                |       |
	| who-we-insure/medical-malpractice-insurance | Medical Malpractice | WC;GL;BOP;PL;CA;Cyber;Umbrella |       |