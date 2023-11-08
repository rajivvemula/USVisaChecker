Feature: States Pages (N)

Page validation for the following state pages:
- Nebraska
- Nevada
- New Hampshire
- New Jersey 
- New Mexico 
- New York 
- North Carolina 
- North Dakota 

@States @Unit @Regression @Static
Scenario Outline: Validate State pages N
	Given user has navigated to the following URL within the host environment: <url>
	When user validates the <state> state page
	Then user validates coverages cards: <coverages>
	And user sees links in the following coverages: <links>

Examples:
	| url                                               | state          | coverages                      | links |
	| where-we-insure/nebraska-business-insurance       | Nebraska       | WC;GL;BOP;PL;Cyber;Umbrella    |       |
	| where-we-insure/nevada-business-insurance         | Nevada         | WC;GL;BOP;PL;CA;Cyber;Umbrella |       |
	| where-we-insure/new-hampshire-business-insurance  | New Hampshire  | WC;GL;BOP;PL;Cyber;Umbrella    |       |
	| where-we-insure/new-jersey-business-insurance     | New Jersey     | WC;GL;BOP;PL;Cyber;Umbrella    |       |
	| where-we-insure/new-mexico-business-insurance     | New Mexico     | WC;PL;Cyber;                   |       |
	| where-we-insure/new-york-business-insurance       | New York       | WC;GL;BOP;PL;Cyber;Umbrella    |       |
	| where-we-insure/north-carolina-business-insurance | North Carolina | WC;GL;BOP;PL;Umbrella          |       |
	| where-we-insure/north-dakota-business-insurance   | North Dakota   | PL;Cyber                       |       |