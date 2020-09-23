Feature: US-21891-View an Issued Policy with Left Navigation Stepper
	As an underwriter, 
	I want to be able to view an issued Policy 
	with the Left Navigation stepper.

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

Scenario:1D Verify Policy Left Nav Exists
	Given User is on Homepage
	When User navigates to policy ID 10562
	Then Verify sidetab is present
	| Key | Value                 |
	| a   | Business Information |
	| b   | Contacts              |
	| c   | UW Questions          |
	| d   | Additional Questions  |
	| e   | Drivers               |
	| f   | Vehicles              |
	| g   | Additional Interests  |
	| h   | Coverages List Test   |
	| i   | Rating Worksheet      |
	| j   | Documents             |
	| k   | Activities            |
	| l   | Loss History          |
	| m   | Policy History        |
	| n   | Summary               |

Scenario Outline:1E Verify each tab within policy left nav is working
	When User navigates to <Tab> SideTab
	Then <Tab> page is displayed

Examples: 
	| Key | Tab                  |
	| a   | Business Information |
	| b   | Contacts             |
	| c   | UW Questions         |
	| d   | Additional Questions |
	| e   | Drivers              |
	| f   | Vehicles             |
	| g   | Additional Interests |
	| h   | Coverages List Test  |
	| i   | Rating Worksheet     |
	| j   | Documents            |
	| k   | Activities           |
	| m   | Policy History       |
	#| l   | Loss History          | not implemented yet
	#add summary once the summary bug is fixed
