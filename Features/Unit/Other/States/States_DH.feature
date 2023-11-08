Feature: States Pages (D-H)

Page validation for the following state pages:
- Delaware
- Florida
- Georgia
- Hawaii

@States @Unit @Regression @Static
Scenario Outline: Validate State pages D_H
	Given user has navigated to the following URL within the host environment: <url>
	When user validates the <state> state page
	Then user validates coverages cards: <coverages>
	And user sees links in the following coverages: <links>

Examples:
	| url                                         | state    | coverages                      | links |
	| where-we-insure/delaware-business-insurance | Delaware | WC;PL;Cyber                    |       |
	| where-we-insure/florida-business-insurance  | Florida  | WC;GL;BOP;PL;CA;Cyber;Umbrella |       |
	| where-we-insure/georgia-business-insurance  | Georgia  | WC;GL;BOP;PL;CA;Cyber;Umbrella |       |
	| where-we-insure/hawaii-business-insurance   | Hawaii   | WC;PL;Cyber                    |       |