@broken 
# Needs updates
Feature: Billing
	in order to issue a quote, user should make a payment


@tc:34155
Scenario: Administration - Billing
	Given user is successfully logged into biberk
	And user navigates to Administration Billing
	When user selects a valid quote to make a payment
	Then Named Insured field should be disabled and have valid value
	And Total Premium field should be disabled and have valid value
	#And Payment Plan can be updated successfully
	And Make Payment Method form is displayed correctly
	| Method            | field1 | field2          | field3              | field4            | field5   | field6 |
	| Credit/Debit Card | Amount | Name on Card    | Card Number         | Exp. Date (MM/YY) | CVC      |        |
	| EFT               | Amount | Name on Account | Bank Routing Number | Account Number    | Checking | Saving |
	| Check             | Amount | Check Number    | Date                |                   |          |        |

@tc:34156 @tc:34187
Scenario: Make a payment - Quote Issuance
	Given user is successfully logged into biberk
	And user navigates to Administration Billing
	When user selects a valid quote to make a payment
	#needs to be selected in quote object itself
	#And user selects payment plan <payment plan>
	And user enters payment information with <method>
	And user clicks 'Submit' Button
	And user waits for spinner to load
	Then user waits for Policy Issuance
	Examples:
	| payment plan        | method            |
	| 12 Monthly Payments | Credit/Debit Card |
	| Pay in Full         | EFT               |
	| 12 Monthly Payments | Check             |

@tc:34157
	Scenario: Document Generation upon policy issuance
	Given user is successfully logged into biberk
	And user navigates to Administration Billing
	When user selects a valid quote to make a payment
	#And user selects payment plan 12 Monthly Payments
	And user enters payment information with Check
	And user clicks 'Submit' Button
	And user waits for spinner to load
	Then user waits for Policy Issuance
	When user waits '30' seconds
	And user clicks 'Documents' Sidetab
	Then table should have entries