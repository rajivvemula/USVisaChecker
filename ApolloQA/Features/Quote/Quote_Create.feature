@broken
Feature: Quote Create
	As a user I want to be able to create a new quote

@SmokeTest @Quote
Scenario: Create New Quote Existing Organization
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks New Button
	And user Selects Business Name as random
	And user Selects Line of Business as Commercial Auto
	And user Selects Policy Effective Date as Tomorrow
	And user clicks Next Button
	Then A new Quote should successfully be created
	And User should be redirected to the newly created Quote Business Information Section
	And Quote header should contain correct values


@SmokeTest @Quote 
Scenario: Create New Quote New Organization 
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks New Button
	And user clicks Create New Organization Button
	And user enters business information
		| BusinessName     | DBA      | TaxIdType | TaxIdNumber | DescriptionOfOperations | BusinessPhoneNumber | BusinessEamil  | BusinessWebsite | Keyword | YearStarted | YearOwned |
		| Create New Quote | dba test | FEIN      | 80-6541032  | DescriptionofOps        | 8021585010          | testorg@me.com | testorg.com     | a       | 2000        | 2005      |
	And user clicks Save Button
	And user waits for spinner to load
	Then user should be redirected to the newly created organization

	When user navigates to Quote Page
	And user clicks New Button
	Then previously created organization should be part of the Business Name Dropdown

	When user Selects Line of Business as Commercial Auto
	And user Selects Policy Effective Date as Tomorrow
	And user clicks Next Button
	Then A new Quote should successfully be created
	And User should be redirected to the newly created Quote Business Information Section
	And Quote header should contain correct values





	
