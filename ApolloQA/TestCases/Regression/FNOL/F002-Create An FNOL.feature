Feature: F002-Create An FNOL
Singular workflow to create a FNOL 


Scenario: Create a FNOL
	When User creates a FNOL 
	| Received | Related | First  | Last | Suffix | Email                | PhoneType | PhoneNumber | ClaimCategory | LossDesc    | Police | PoliceName | PoliceNumber | Fire | FireName | FireNumber |
	| Phone    | No      | Joseph | Seed | Mr     | josephseed@gmail.com | Mobile    | 5452156532  | Option 1      | Sample Desc | Yes    | PAPD       | 1234         | Yes  | PAFD     | 4567       |
	Then Verify FNOL is created