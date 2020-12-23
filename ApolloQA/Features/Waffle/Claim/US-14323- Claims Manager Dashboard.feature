@demo
Feature: US-14323- Claims Manager Dashboard
	As a claims manager, 
	I will be able to view my dashboard which will allow me to view my work as well as a snapshot of my employees work.

@broken
Scenario:TC01 Verify Adjusters Claim Grid FNOL
	Given user is successfully logged into biberk
	When user clicks ' apps ' icon button
	When user clicks Claim right menu button
	Then Grid column label is displayed
	| Key | Value             |
	| 1   | Date Reported     |
	| 2   | FNOL Number       |
	| 3   | Claimant          |
	| 4   | Occurrence Number |
	| 5   | FNOL Status       |
	| 6   | Policy No.        |
	| 7   | Date of Loss      |

#scenario is not mutually exclusive
@broken
Scenario: TC02 Verify Adjusters Claim Grid Statistics
	Then Grid column label is displayed
	| Key | Value            |
	| 1   | Adjuster         |
	| 2   | Line of Business |
	| 3   | Prior Month      |
	| 4   | Open             |
	| 5   | Reopen           |
	| 6   | Closed           |
	| 7   | Current Pending  |