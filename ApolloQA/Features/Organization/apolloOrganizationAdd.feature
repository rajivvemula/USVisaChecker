Feature: apolloOrganizationAdd


Scenario: Business Email field is required when adding an organization
	Given user is successfully logged into biberk
	When user clicks Organization Button
	When user clicks  New  Button
	Then user verifies Email is required

Scenario: Add business information and save as organization
	Given user is successfully logged into biberk
	When user clicks Organization Button
	When user clicks  New  Button
	When user enters business information
	| BusinessName | DBA | TaxIdType | TaxIdNumber | DescriptionOfOperations | BusinessPhoneNumber | BusinessEamil  | BusinessWebsite | Keyword	| YearStarted | YearOwned |
	| TheTestOrg   | dba | FEIN      | 80-6541032  | DescriptionofOps        | 8021585010          | testorg@me.com | testorg.com     | S       | 2000        | 2005      |
#	And user clicks  Save  Button
#	Then user asserts for saved organization # cannot save more than one application with given information

Scenario: Add business information and cancel submit
	Given user is successfully logged into biberk
	When user clicks Organization Button
	When user clicks  New  Button
	When user enters business information
	| BusinessName | DBA | TaxIdType | TaxIdNumber | DescriptionOfOperations | BusinessPhoneNumber | BusinessEamil  | BusinessWebsite | Keyword	| YearStarted | YearOwned |
	| TheTestOrg   | dba | FEIN      | 80-6541032  | DescriptionofOps        | 8021585010          | testorg@me.com | testorg.com     | S       | 2000        | 2005      |
	And user clicks  Cancel  Button
	Then user asserts for canceled organization add
