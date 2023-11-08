Feature: MakeAPayment_ForgotPhoneNumber

User navigates to the Make A Payment page and enters "Forgot Phone Number".  The emails created will then be manually verified.

@Staging @Regression @Unit
Scenario Outline: Make A Payment - Forgot Phone Number
	Given user navigates to the Make a Payment page
	Then user verifies landing on Make a Payment login page
	Then user interacts with Forgot Phone Number modal using <policyId>

	Examples: 
		| LOB | policyId      |
		| PL  | N9PL088725    |
		| CA  | 0011004-01-CA |
		| BOP | N9BP809821    |
		| GL  | N9BP811011    |
		| UM  | N9UM700002    |
		| CX  | N9CX835261    |