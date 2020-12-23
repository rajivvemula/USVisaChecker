
Feature: Organization_Create


Scenario: 1 Test Create Org
	Given user is successfully logged into biberk
	When user clicks Organization tab
	When user clicks New Button
	Then URL contains organization/insert
	When user enters following values
	| Display Name              | Field Type   | Value                                                  |
	| Business Name             | Input        | Automation Test Org New                                |
	| Organization Type         | Dropdown     | Corporation                                            |
	| Tax ID Type               | Dropdown     | FEIN                                                   |
	| Tax ID No                 | Input        | 12-3123111                                             |
	| Description Of Operations | Input        | Sample text.                                           |
	| Business Phone No.        | Input        | 249-213-1518                                           |
	| Business Email Address    | Input        | business@email.com                                     |
	| Business Website          | Input        | business.com                                           |
	| Keyword                   | Autocomplete | Pizza - Restaurant - no deep frying - no table service |
	| Year Business Started     | Input        | 2017                                                   |
	| Year Ownership Started    | Input        | 2018                                                   |
	Then the following fields have values
	| Display Name   | Field Type | Value |
	| Class Taxonomy | Input      | Any   |
	And Save button is enabled
	When user clicks Save Button
	Then URL contains /organization/
	And Business Information sidetab is active
	And the following fields have values
	| Display Name              | Field Type   | Value                                                  |
	| Business Name             | Input        | Automation Test Org 1218                               |
	| Organization Type         | Dropdown     | Corporation                                            |
	| Tax ID Type               | Dropdown     | FEIN                                                   |
	| Tax ID No                 | Input        | 12-3123111                                             |
	| Description Of Operations | Input        | Sample text.                                           |
	#| Business Phone No.        | Input        | 249-213-1518                                           |
	#| Business Email Address    | Input        | business@email.com                                     |
	#| Business Website          | Input        | business.com                                           |
	| Keyword                   | Autocomplete | Pizza - Restaurant - no deep frying - no table service |
	#| Class Taxonomy            | Input        | Hospitality\Restaurants\All Other                      |
	| Year Business Started     | Input        | 2017                                                   |
	| Year Ownership Started    | Input        | 2018                                                   |