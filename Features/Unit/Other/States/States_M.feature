Feature: States Pages (M)

Page validation for the following state pages:
- Maine
- Maryland
- Massachusetts
- Michigan
- Minnesota
- Mississippi
- Missouri
- Montana

@States @Unit @Regression @Static
Scenario Outline: Validate State pages M
	Given user has navigated to the following URL within the host environment: <url>
	When user validates the <state> state page
	Then user validates coverages cards: <coverages>
	And user sees links in the following coverages: <links>

Examples:
	| url                                              | state         | coverages                      | links |
	| where-we-insure/maine-business-insurance         | Maine         | WC;PL;Cyber                    |       |
	| where-we-insure/maryland-business-insurance      | Maryland      | WC;GL;BOP;PL;Cyber;Umbrella    |       |
	| where-we-insure/massachusetts-business-insurance | Massachusetts | WC;GL;BOP;PL;Cyber;Umbrella    |       |
	| where-we-insure/michigan-business-insurance      | Michigan      | WC;GL;BOP;PL;Umbrella          |       |
	| where-we-insure/minnesota-business-insurance     | Minnesota     | WC;GL;BOP;Cyber;Umbrella       |       |
	| where-we-insure/mississippi-business-insurance   | Mississippi   | WC;GL;BOP;PL;Cyber;Umbrella    |       |
	| where-we-insure/missouri-business-insurance      | Missouri      | WC;GL;BOP;PL;CA;Cyber;Umbrella |       |
	| where-we-insure/montana-business-insurance       | Montana       | WC;PL;Cyber                    |       |