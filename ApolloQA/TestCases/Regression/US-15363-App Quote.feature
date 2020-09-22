Feature: US-15363-App Quote
As an underwriter,
I want to create a new Application Quote 
and have the Business Information pre-filled with data captured from the Organization level so that I start the application quote process.

Scenario:1A User is able to login as Admin
	Given User is on Apollo Homepage
	When I enter AdminUsername and AdminPassword 
	Then I should see the Apollo Dashboard as Admin

Scenario:1B User Navigates to Homepage
Given User is on Homepage

Scenario Outline:1C User Interactions With Dashboard Tabs
	When User navigates to <Tab> Tab
	Then Tab navigates to <Tab> URL

Examples:
	| Tab          |  
	| Policy       | 
	| Application  | 
	| Organization | 
	| Home         |

#Also covers TC02 and TC03 and TC 05
#TC 02 - Verify existing Organization name display in search result
#TC 03 -Verify Application Information page and Next should navigate Business Information page
#TC 05 - App Quote - Verify left navigation bar sections
Scenario:1D TC1 - Verify business name is new and Organization has not been created
	Given User is on Homepage
	When User Navigates to Application Insert 
	When User searches ShouldNotExist in Business Name
	Then Search ShouldNotExist displayed is false
	When User creates an Organization
	| Name            | DBA   | OrgType     | TaxType | TaxIDNo | BusPhone     | BusEmail            | BusWeb        | YearStart | YearOwn | Keyword    |
	| Smoke Test10023 | Smoke | Corporation | FEIN    | Random  | 123-456-7890 | smoketest@gmail.com | smoketest.com | 2011      | 2012    | Accountant |
	Then Verify organization is created
	When User Navigates to Application Insert 
	When User searches Smoke Test10023 in Business Name
	Then Search Smoke Test10023 displayed is true
	When User enters Smoke Test10023 in Business Name
	And User clicks appInsertNext button
	Then Business Information page is displayed
	Then Verify sidetab is present
	| Key | Value                   |
	| a   | Application Information |
	| b   | Business Information    |
	| c   | Contacts                |
	| d   | UW Questions            |
	| e   | Policy Coverages        |
	| f   | Drivers                 |
	| g   | Vehicles                |
	| h   | Additional Questions    |
	| i   | Summary                 |