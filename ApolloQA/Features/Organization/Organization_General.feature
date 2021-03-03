Feature: Organization General

Scenario: Organization Create New
	Given user is successfully logged into biberk
	When user clicks 'Organization' Button
	When user clicks 'New' Button
	And user waits for spinner to load
	When user enters business information
	| BusinessName | DBA | TaxIdType | TaxIdNumber | DescriptionOfOperations | BusinessPhoneNumber | BusinessEamil  | BusinessWebsite | Keyword    | YearStarted | YearOwned |
	| TheTestOrg   | dba | FEIN      | 81-6541234  | DescriptionofOps        | 8021585010          | testorg@me.com | testorg.com     | Accounting | 2000        | 2005      |
	And user clicks 'Save' Button
	And user waits for spinner to load
	When user asserts for saved organization

Scenario: Organization Cancel Creation
	Given user is successfully logged into biberk 
	When user clicks 'Organization' Button
	When user clicks 'New' Button
	And user waits for spinner to load
	When user enters business information
	| BusinessName | DBA | TaxIdType | TaxIdNumber | DescriptionOfOperations | BusinessPhoneNumber | BusinessEamil  | BusinessWebsite | Keyword    | YearStarted | YearOwned |
	| TheTestOrg   | dba | FEIN      | 81-6541865  | DescriptionofOps        | 8021585010          | testorg@me.com | testorg.com     | Accounting | 2000        | 2005      |
	And user clicks 'Cancel' Button
	When user clicks 'Continue anyway' Button
	Then user asserts for canceled organization add
