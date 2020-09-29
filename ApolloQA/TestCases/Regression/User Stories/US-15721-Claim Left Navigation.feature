Feature: US-15721-Claim Left Navigation 
	As a claims adjuster property damage, 
	claims adjuster bodily injury, claims manager and claims representative 
	I will be able to navigate to various claims screen using the left navigation.  

Scenario:1D Verify Policy Left Nav Exists
	Given User is on Homepage
	When User navigates to claim ID recent
	Then Verify sidetab is present
	| Key | Value             |
	| a   | Occurence         |
	| b   | Loss Details      |
	| c   | Contacts          |
	| d   | Documents         |
	| e   | Supervisor Review |

Scenario Outline:1E Verify each tab within policy left nav is working
	When User navigates to <Tab> SideTab
	Then <Tab> page is displayed

Examples: 
	| Key | Tab               |
	| a   | Occurence         |
	| b   | Loss Details      |
	| c   | Contacts          |
	| d   | Documents         |
	| e   | Supervisor Review |