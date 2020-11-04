Feature: Business Infomration Section
	As a user I want to make sure Business Information section is working correctly

@SmokeTest @Quote
Scenario: Business Information Load
	Given user is successfully logged into biberk
	When User Navigates to Quote latest
	And User Navigates to Business Infomration Section
	Then The following Organization Fields should be displayed
	| Display Name              | Field Type |
	| Business Name             | Input      |
	| DBA                       | Input      |
	| Organization Type         | Dropdown   |
	| Tax ID Type               | Input      |
	| Tax ID No                 | Input      |
	| Description of Operations | Input      |
	| Business Phone No         | Input      |
	| Business Email Address    | Input      |
	| Business Website          | Input      |
	| Keyword                   | Input      |
	| Class Taxonomy            | Input      |
	| Year Business Started     | Input      |
	| Year Ownership Started    | Input      |



