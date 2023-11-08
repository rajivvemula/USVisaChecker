Feature: States Pages (I-L)

Page validation for the following state pages:
- Idaho
- Illinois
- Indiana
- Iowa
- Kansas
- Kentucky
- Louisiana

@States @Unit @Regression @Static
Scenario Outline: Validate State pages I_L
	Given user has navigated to the following URL within the host environment: <url>
	When user validates the <state> state page
	Then user validates coverages cards: <coverages>
	And user sees links in the following coverages: <links>

Examples:
	| url                                          | state     | coverages                      | links |
	| where-we-insure/idaho-business-insurance     | Idaho     | WC;PL;Cyber                    |       |
	| where-we-insure/illinois-business-insurance  | Illinois  | WC;GL;BOP;PL;CA;Cyber;Umbrella |       |
	| where-we-insure/indiana-business-insurance   | Indiana   | WC;GL;BOP;PL;CA;Cyber          |       |
	| where-we-insure/iowa-business-insurance      | Iowa      | WC;GL;BOP;PL;Cyber;Umbrella    |       |
	| where-we-insure/kansas-business-insurance    | Kansas    | WC;GL;BOP;PL;Cyber;Umbrella    |       |
	| where-we-insure/kentucky-business-insurance  | Kentucky  | WC;PL;Cyber;                   |       |
	| where-we-insure/louisiana-business-insurance | Louisiana | WC;PL;Cyber;                   |       |