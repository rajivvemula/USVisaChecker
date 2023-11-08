Feature: States Pages (W)

Page validation for the following state pages:
- Washington
- Washington DC
- West Virginia 
- Wisconsin 
- Wyoming 

@States @Unit @Regression @Static
Scenario Outline: Validate State pages W
	Given user has navigated to the following URL within the host environment: <url>
	When user validates the <state> state page
	Then user validates coverages cards: <coverages>
	And user sees links in the following coverages: <links>

Examples:
	| url                                              | state         | coverages                | links |
	| where-we-insure/washington-business-insurance    | Washington    | GL;BOP;PL;Cyber;Umbrella |       |
	| where-we-insure/washington-dc-business-insurance | Washington DC | WC;PL;Cyber              |       |
	| where-we-insure/west-virginia-business-insurance | West Virginia | WC;PL;Cyber              |       |
	| where-we-insure/wisconsin-business-insurance     | Wisconsin     | WC;PL;CA;Cyber           |       |
	| where-we-insure/wyoming-business-insurance       | Wyoming       | PL;Cyber                 |       |