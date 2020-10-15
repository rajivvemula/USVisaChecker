Feature: US-13044-First Notice of Loss Initial Entry
	As a Claims User 
	I need the ability to enter First Notice of Loss (FNOL) information into Apollo 
	so that all information necessary to begin a claim is available.

Scenario: 1 Navigate to FNOL Insert Page
	Given User is on Homepage
	Given User opens Waffle Menu
	When User navigates to Claims Tab
	Then Tab navigates to Claims URL
	When User clicks fnolGridNew button
	Then Verify correct page fnolInsert is displayed

Scenario: TC01 Create a New FNOL
	Then Verify an input is displayed with label
	| Key | Value                         |
	| a   | Date of Loss                  |
	| b   | Time of Loss (HH:MM AM/PM)    |
	| c   | How was the Notice Received   |
	| d   | Date Reported                 |
	| e   | Time Reported (HH:MM AM/PM)   |
	| f   | Related to an Existing Claim? |
	| g   | Policy Number                 |
	| h   | First Name                    |
	| i   | Middle Name                   |
	| j   | Last Name                     |
	| k   | Suffix                        |
	| l   | Email                         |
	| m   | Phone Type                    |
	| n   | CAT Field                     |
	| o   | Description of Loss           |
	| p   | Police Involved?              |
	| q   | Fire Department Involved?     |
	
Scenario: TC03 Date of Loss Negative Test
	Then Verify Date of Loss - cannot be a future date.

Scenario: TC04 Time of Loss Negative Test
	Then Verify Time of Loss - default time

#US 14299
Scenario: TC05 How Notice Receieved Negative Test
	Then Verify How Received contains phone - email - carrier pigeon

Scenario: TC06 Date Reported Negative Test
	Then Verify Date Reported - defaults to today

Scenario: TC07 CAT Negative Test
	Then Verify CAT defaults to None and has option1 and option2