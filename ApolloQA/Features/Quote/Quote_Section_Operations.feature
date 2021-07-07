Feature: Quote_Section_Operations
	Testing Operations section for Specific questions given a specific Keyword


Scenario Outline: Operation Questions Exist for given Keywords
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks 'New' Button
	When User Selects Name Insured from dropdown
	And user selects dropdown Organization Type option equaling LLC
	And user selects dropdown Tax ID Type option equaling FEIN
	And user enters tax Id number
	And user enters abcTest@example.com into Business Email Address field
	And user enters 4843668104 into Business Phone No field
	And user enters <Keyword> into Keyword field
	And user selects dropdown Keyword option equaling <Keyword>
	And user enters 2001 into Year Business Started field
	And user enters 2003 into Year Ownership Started field
	And user sets Orgnaization Address
	And user clicks 'Next' Button
	Then A new Quote should successfully be created	
	When user clicks 'Operations' Sidetab
	And user verifies Operations questions


	Examples: 
	| Keyword                                              |
	| Trucking: Local Hauling: less than 300 miles         |
	| Towing Services                                      |
	| Trucking: Long Distance Hauling: more than 300 miles |
	| Limousine Company                                    |
	| Brine Hauling: Under 300 Miles                       |
	| Bus Company                                          |