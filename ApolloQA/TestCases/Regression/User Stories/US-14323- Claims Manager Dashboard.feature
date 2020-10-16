Feature: US-14323- Claims Manager Dashboard
	As a claims manager, 
	I will be able to view my dashboard which will allow me to view my work as well as a snapshot of my employees work.


Scenario:TC01 Verify Adjusters Claim Grid FNOL
	Given User is on Apollo Homepage
	Given User opens Waffle Menu
	When User navigates to Claims Tab
	Then Tab navigates to Claims URL
	Then Grid column label is displayed
	| Key | Value             |
	| a   | Date Reported     |
	| b   | FNOL Number       |
	| c   | Claimant          |
	| d   | Occurrence Number |
	| e   | FNOL Status       |
	| f   | Policy Code       |
	| g   | Date of Loss      |

Scenario: TC02 Verify Adjusters Claim Grid Statistics
	Then Grid column label is displayed
	| Key | Value            |
	| a   | Adjuster         |
	| b   | Line of Business |
	| c   | Prior Month      |
	| d   | Open             |
	| e   | Reopen           |
	| f   | Closed           |
	| g   | Current Pending  |