Feature: Quote



Scenario: Creating a new quote
	Given user is successfully logged into biberk
	When user navigates to 'Quote' Page
	And user clicks 'New' Button
	And user enters the following field values on 'quote'
	| FieldName              | Value           |
	| Line of Business       | Commercial Auto |
	| Named Insured          | ui-automation   |
	| Organization Type      | Corporation     |
	| Tax ID Type            | SSN             |
	| Tax ID No              | 855 55 5555     |
	| Business Phone No      | 201 555 5589    |
	| Business Email Address | ui@biberk.com   |
	| Keyword                | Accountant      |
	| Year Business Started  | 2018            |
	And user clicks 'Add Address' Button
	And user fills out UI form with an address from '<StateCode>'
	And user clicks 'Save' Button
	And user navigates to 'Business Information' section
	Then user asserts the following 'quote' fields

     Examples:
	| StateCode |
	| IL        |