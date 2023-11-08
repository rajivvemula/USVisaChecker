Feature: States Pages (A-C)

Page validation for the following state pages:
- Alabama
- Alaska
- Arizona
- Arkansas
- California
- Colorado
- Connecticut

@States @Unit @Regression @Static
Scenario Outline: Validate State pages A_C
	Given user has navigated to the following URL within the host environment: <url>
	When user validates the <state> state page
	Then user validates coverages cards: <coverages>
	And user sees links in the following coverages: <links>

Examples:
	| url                                            | state       | coverages                      | links |
	| where-we-insure/alabama-business-insurance     | Alabama     | WC;PL;Cyber                    | WC    |
	| where-we-insure/alaska-business-insurance      | Alaska      | WC;PL;Cyber                    |       |
	| where-we-insure/arizona-business-insurance     | Arizona     | WC;GL;BOP;PL;CA;Cyber;Umbrella |       |
	| where-we-insure/arkansas-business-insurance    | Arkansas    | WC;PL;Cyber                    |       |
	| where-we-insure/california-business-insurance  | California  | WC;GL;BOP;PL;CA;Cyber;Umbrella |       |
	| where-we-insure/colorado-business-insurance    | Colorado    | WC;GL;BOP;PL;CA;Cyber;Umbrella |       |
	| where-we-insure/connecticut-business-insurance | Connecticut | WC;GL;BOP;PL;Cyber;Umbrella    |       |