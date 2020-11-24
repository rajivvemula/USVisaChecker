Feature: apolloOrganization

Scenario: Add business information and save as organization
	Given user is successfully logged into biberk
	When user clicks Organization Button
	When user clicks  New  Button
	And user waits for spinner to load
	When user enters business information
	| BusinessName | DBA | TaxIdType | TaxIdNumber | DescriptionOfOperations | BusinessPhoneNumber | BusinessEamil  | BusinessWebsite | Keyword	| YearStarted | YearOwned |
	| TheTestOrg   | dba | FEIN      | 81-6541000  | DescriptionofOps        | 8021585010          | testorg@me.com | testorg.com     | S       | 2000        | 2005      |
	And user clicks  Save  Button
	And user waits for spinner to load
#	When user asserts for saved organization - issue with toastr : returning blank
	Then user deletes created test organization

Scenario: Add business information and cancel submit
	Given user is successfully logged into biberk 
	When user clicks Organization Button
	When user clicks  New  Button
	And user waits for spinner to load
	When user enters business information
	| BusinessName | DBA | TaxIdType | TaxIdNumber | DescriptionOfOperations | BusinessPhoneNumber | BusinessEamil  | BusinessWebsite | Keyword	| YearStarted | YearOwned |
	| TheTestOrg   | dba | FEIN      | 81-6541000  | DescriptionofOps        | 8021585010          | testorg@me.com | testorg.com     | S       | 2000        | 2005      |
	And user clicks  Cancel  Button
	When user clicks Continue anyway Button
	Then user asserts for canceled organization add
