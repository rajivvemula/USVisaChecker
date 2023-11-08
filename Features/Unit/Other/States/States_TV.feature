Feature: States Pages (T-V)

Page validation for the following state pages:
- Tennessee
- Texas
- Utah
- Vermont
- Virginia

@States @Unit @Regression @Static
Scenario Outline: Validate State pages T_V
	Given user has navigated to the following URL within the host environment: <url>
	When user validates the <state> state page
	Then user validates coverages cards: <coverages>
	And user sees links in the following coverages: <links>

Examples:
	| url                                          | state     | coverages                      | links |
	| where-we-insure/tennessee-business-insurance | Tennessee | WC;GL;BOP:PL;CA;Cyber;Umbrella |       |
	| where-we-insure/texas-business-insurance     | Texas     | WC;GL;BOP:PL;CA;Cyber;Umbrella |       |
	| where-we-insure/utah-business-insurance      | Utah      | WC;PL;Cyber                    |       |
	| where-we-insure/vermont-business-insurance   | Vermont   | WC;PL;Cyber                    |       |
	| where-we-insure/virginia-business-insurance  | Virginia  | WC;GL;BOP;PL;Cyber;Umbrella    |       |