Feature: US-14816- Add Adjuster and Complexity to FNOL
	As a claim user
	I will be able to assign an adjuster and complexity to the FNOL/Claim details.  


Scenario: TC01 Verify Claim Type
	Given User is on Homepage
	When User creates a FNOL 
	| Received | Related | First  | Last | Suffix | Email                | PhoneType | PhoneNumber | ClaimCategory | LossDesc    | Police | PoliceName | PoliceNumber | Fire | FireName | FireNumber |
	| Phone    | No      | Joseph | Seed | Mr     | josephseed@gmail.com | Mobile    | 5452156532  | Option 1      | Sample Desc | Yes    | PAPD       | 1234         | Yes  | PAFD     | 4567       |
	Then Verify FNOL is created
	Then Verify Radio Option is present : Property Damage
	Then Verify Radio Option is present : Bodily Injury

Scenario: TC02 Verify Complexity Type
	Then Verify a Select contains value : complexityId
	| Key | Value    |
	| a   | Complex  |
	| b   | Fastrack |


Scenario: TC03 Verify Clicking Cancel
	When User clicks buttonCancel button
	Then fnol-dashboard page is displayed