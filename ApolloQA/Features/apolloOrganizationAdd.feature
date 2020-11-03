Feature: apolloOrganizationAdd

@background
Scenario: Login biBerk home page with valid credentials
	Given user landed biBerk page with valid URL 
	When user enters username: ApolloTestUserG311@biberk.com and password: ApolloTest12
	And user attempts to login
	Then user login successfully to biBerk page

Scenario: Business Email field is required when adding an organization
	Given user clicks addNew button to add an organization
	Then user verifies Email is required

Scenario: Add business information and save as organization
	Given user enters business information
	| BusinessName | DBA | OrganizationType | TaxIdType | TaxIdNumber | DescriptionOfOperations | BusinessPhoneNumber | BusinessEamil  | BusinessWebsite | Keyword		   | ClassTaxonomy | YearStarted | YearOwned |
	| TheTestOrg   | dba | Non-Profit       | FEIN      | 80-6541032  | DescriptionofOps        | 8021585010          | testorg@me.com | testorg.com     | Turkey Farm     | tax           | 2000        | 2005      |

