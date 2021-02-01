@demo
Feature: US-9314 - Create an Application Quote with Left Navigation Stepper
	In order to test application navigation
	As an authorized user
	I want to verify the application tabs are present and clickable

Scenario: TC01 Create new application
	Given user is successfully logged into biberk
	When user clicks Quote Button
	When user clicks New Button
	When user enters following values
	| Display Name     | Field Type   | Value                   |
	| Business Name    | Autocomplete | Automation Test Org New |
	| Line of Business | Dropdown     | Commercial Auto         |
	| Agent            | Dropdown     | Thurston Howell         |
	When user clicks Next Button
	And user waits for spinner to load
	Then URL contains /section/9000

@ignore
#TODO
Scenario Outline: TC02 Check Application tabs are present and clickable
	When user clicks <Tab Name> sidetab
	Then <Tab Name> sidetab is active

Examples:
	| Tab Name             |
	| Quote Information    |
	| Business Information |
	| Contacts             |
	| UW Questions         |
	| Additional Questions |
	| Drivers              |
	| Vehicles             |
	| Trailers             |
	| Additional Questions |
	| Policy Coverages     |
	| Additional Interests |
	| Summary              |
	| Underwriting Results |