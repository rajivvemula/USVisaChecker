  @broken 
Feature: Quote Section Business Information
	As a user I want to make sure Business Information section is working correctly

  #TODO :
 #Error when retrieving Property
@SmokeTest @Quote
Scenario: Business Information Section Loads successfully
	Given user is successfully logged into biberk
	When User Navigates to Quote latest
	And User Navigates to Business Information Section
	Then The following Organization Fields should be displayed
	| Display Name              | Field Type |
	| Named Insured             | Input      |
	| DBA                       | Input      |
	| Organization Type         | Dropdown   |
	| Tax ID Type               | Dropdown   |
	| Tax ID No                 | Input      |
	| Business Phone No         | Input      |
	| Business Email Address    | Input      |
	| Business Website          | Input      |
	| Keyword                   | Input      |
	| Class Taxonomy            | Input      |
	| Year Business Started     | Input      |
	| Year Ownership Started    | Input      |
	And Physical Address field should be blank
	And National Credit Score should be displayed


	@SmokeTest @Quote
	@broken 
	# duplicate addresses error 
Scenario: Business Information Add Address Functionality
	Given user is successfully logged into biberk
	When User Navigates to Quote latest
	And User Navigates to Business Information Section
	And user clicks Physical Address Dropdown
	And user clicks 'Add Address' Button
	And user saves current Business Addresses
	And user enters the following address
	| Field Display Name        | Field Type | Field Value     |
	| Street Address Line 1     | Input      | 720 E Laurel St |
	| Street Address Line 2     | Input      |                 |
	| City                      | Input      | Springfield     |
	| State / Region            | Dropdown   | IL              |
	| Zip / Postal Code         | Input      | 62703           |
	| Country                   | Dropdown   | United States   |
	And user saves the address
	Then Dropdown should contain the previously entered address 

