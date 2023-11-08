Feature: COI_ForgotPhoneNumber

User navigates to the COI page and enters "Forgot Phone Number".  The emails created will then be manually verified.

@Staging @Regression @COI @Unit @LinkChangeTest
Scenario Outline: COI - Forgot Phone Number
	Given user navigates to the COI page
	Then user verifies landing on Get a Certificate of Insurance login page
	Then user interacts with Forgot Phone Number modal using <policyId>

	Examples: 
		| LOB | policyId      |
		| PL  | N9PL686470    |
		| CA  | 0011004-01-CA |
		| BOP | N9BP809821    |
		| GL  | N9BP811011    |
		| UM  | N9UM849114    |
		| CX  | N9CX157189    |