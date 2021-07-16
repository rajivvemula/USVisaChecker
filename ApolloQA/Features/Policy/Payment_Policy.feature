Feature: PolicyPayment
	Checks Policy Payment System For Errors
	Uses All Payment Methods


Scenario Outline: Make a Payment In a Issued Policy 
	Given user is successfully logged into biberk
    When User Navigates to Policy latest issued
	Then User Clicks on Ellipsis and Selects Make A Payment
	When user enters payment information via <paymentMethod>
	And user clicks 'Submit' Button
	Then Toast containing Payment was submitted. is visible 

	Examples: 
	| paymentMethod     |
	| Credit/Debit Card |
	| EFT               |
	| Check             | 