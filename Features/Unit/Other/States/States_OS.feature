Feature: States Pages (O-S)

Page validation for the following state pages:
- Ohio
- Oklahoma
- Oregon
- Pennsylvania
- Rhode Island 
- South Carolina
- South Dakota

@States @Unit @Regression @Static
Scenario Outline: Validate State pages O_S
	Given user has navigated to the following URL within the host environment: <url>
	When user validates the <state> state page
	Then user validates coverages cards: <coverages>
	And user sees links in the following coverages: <links>

Examples:
	| url                                               | state          | coverages                      | links |
	| where-we-insure/ohio-business-insurance           | Ohio           | GL;BOP;PL;CA;Cyber;Umbrella    |       |
	| where-we-insure/oklahoma-business-insurance       | Oklahoma       | WC;PL;                         |       |
	| where-we-insure/oregon-business-insurance         | Oregon         | WC;PL;Cyber;                   |       |
	| where-we-insure/pennsylvania-business-insurance   | Pennsylvania   | WC;GL;BOP;PL;Cyber;Umbrella    |       |
	| where-we-insure/rhode-island-business-insurance   | Rhode Island   | WC;PL;Cyber;                   |       |
	| where-we-insure/south-carolina-business-insurance | South Carolina | WC;GL;BOP;PL;CA;Cyber;Umbrella |       |
	| where-we-insure/south-dakota-business-insurance   | South Dakota   | WC;PL;Cyber;                   |       |