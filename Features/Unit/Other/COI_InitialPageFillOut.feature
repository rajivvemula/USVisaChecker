Feature: COI_InitialPageFillOut

User navigates to the COI Initial page and enters "Policy Number" and "Phone" number. 

@Staging @Regression @COI @Unit
Scenario Outline: COI Initial Page Fill Out
	Given user navigates to the COI page
	Then user fills in the COI Page with these values:
	| Policy Number | Phone      |
	| N9PL821244    | 3213213211 |