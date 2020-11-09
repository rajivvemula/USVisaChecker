Feature: CaseyTest

Scenario: 1 First test example
	Given user is successfully logged into biberk
	When user clicks Organization tab
	And user clicks New button
	And user enters following values
	| Display Name              | Field Type   | Value                                                  |
	| Business Name             | Input        | Casey Test Org 1109-1                                  |
	| Organization Type         | Dropdown     | Corporation                                            |
	| Tax ID Type               | Dropdown     | FEIN                                                   |
	| Tax ID No                 | Input        | 12-3123111                                             |
	| Description of Operations | Input        | Sample text.                                           |
	| Business Phone No         | Input        | 249-213-1518                                           |
	| Business Email Address    | Input        | business@email.com                                     |
	| Business Website          | Input        | business.com                                           |
	| Keyword                   | Autocomplete | Pizza - Restaurant - no deep frying - no table service |
	| Year Business Started     | Input        | 2017                                                   |
	| Year Ownership Started    | Input        | 2018                                                   |