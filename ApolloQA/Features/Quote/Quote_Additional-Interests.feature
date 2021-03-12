Feature: Quote_Additional-Interests
	Feature to test Additional Interests

Scenario Outline: Add Policy Additional Interest to Qute - Individual
	Given user is successfully logged into biberk
	When user clicks 'Quote' Button
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks 'Policy Addl Interests' Sidetab
	And user waits for spinner to load
	And user clicks 'Additional Interest' Button
	And User selects Additional <InterestType>
	And User selects Party Type 'Individual'
	And user completes address section
	And user completes contact info and description
	When user clicks 'Save' Button
	Then user verifies Additional Interest Add successful

		Examples: 
	| InterestType				     |
	| Additional Insured - Blanket   |
	| Additional Insured Endorsement |
	| Certificate Holder             |


	Scenario Outline: Add Policy Additional Interest to Qute - Organization
	Given user is successfully logged into biberk
	When user clicks 'Quote' Button
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks 'Policy Addl Interests' Sidetab
	And user waits for spinner to load
	And user clicks 'Additional Interest' Button
	And User selects Additional <InterestType>
	And User selects Party Type 'Organization'
	And user completes address section
	And user completes contact info and description
	When user clicks 'Save' Button
	Then user verifies Additional Interest Add successful

		Examples: 
	| InterestType				     |
	| Additional Insured - Blanket   |
	| Additional Insured Endorsement |
	| Certificate Holder             |

