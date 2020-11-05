Feature: apolloOrganizationAdd


Scenario: Business Email field is required when adding an organization
	Given user is successfully logged into biberk
	When user clicks addNew button to add an organization
	Then user verifies Email is required

Scenario: Add business information and save as organization
	Given user is successfully logged into biberk
	When user clicks addNew button to add an organization
	When user enters business information
	| BusinessName | DBA | TaxIdType | TaxIdNumber | DescriptionOfOperations | BusinessPhoneNumber | BusinessEamil  | BusinessWebsite | Keyword	| YearStarted | YearOwned |
	| TheTestOrg   | dba | FEIN      | 80-6541032  | DescriptionofOps        | 8021585010          | testorg@me.com | testorg.com     | S       | 2000        | 2005      |
	Then user clicks 'Cancel' button to save/cancel organization addition
