﻿Feature: Billing
	in order to issue a quote, user should make a payment



Scenario: Administration - Billing
	Given user is successfully logged into biberk
	And user navigates to Administration Billing
	When user selects a valid quote to make a payment
	Then Named Insured field should be disabled and have valid value
	And Total Premium field should be disabled and have valid value
	And Payment Plan can be updated successfully
	And Make Payment Method form is displayed correctly
	| Method            | field1 | field2          | field3              | field4            | field5   | field6 |
	| Credit/Debit Card | Amount | Name on Card    | Card Number         | Exp. Date (MM/YY) | CVC      |        |
	| EFT               | Amount | Name on Account | Bank Routing Number | Account Number    | Checking | Saving |
	| Check             | Amount | Check Number    | Date                |                   |          |        |


Scenario: Make a payment - Quote Issuance
	Given user is successfully logged into biberk
	And user navigates to Administration Billing
	When user selects a valid quote to make a payment
	And user selects payment plan <payment plan>
	And user enters payment information with <method>
	And user clicks 'Submit' Button
	And user waits for spinner to load
	Then Toast containing Policy Issuance is complete for ratable object is visible
	When user waits '30' seconds
	And user clicks 'Documents' Sidetab
	Then table should have 3 entries



	Examples:
	| payment plan        | method            |
	| 12 Monthly Payments | Credit/Debit Card |
	| Pay in Full         | EFT               |
	| 12 Monthly Payments | Check             |


	