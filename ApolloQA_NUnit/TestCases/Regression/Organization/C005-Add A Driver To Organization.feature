Feature: C005-Add A Driver To Organization
Add a Driver to A Given Organization


Scenario: Add a Driver to A Given Organization
	When User adds driver to Organization
	| First | Last | Middle | DOB        | State | Number | Exp        | CDL |
	| Jacob | Seed | J      | 01/02/1975 | AZ    | Random | 01/01/2022 | No  |
	Then Verify driver is added to Organization

