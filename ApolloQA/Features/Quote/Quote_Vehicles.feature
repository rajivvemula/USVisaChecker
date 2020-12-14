Feature: Quote_Vehicles


Scenario: TC 26825 : Quote - vehicle section : vehicle owned
	Given user is successfully logged into biberk
	When user clicks Quote Button
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks  Vehicles  Sidetab
	When user clicks  Vehicle  Button
	And user waits for spinner to load
	When user selects Owned Button
	When user clicks  The Business  Button
	And user verifies owner input is visible
	When user clicks  One or more of the Business Owner(s)  Button
	And user verifies owner input is visible
	When user clicks  Someone else  Button
	And user verifies owner input is visible
	Then user adds Address

Scenario: TC 26826 : Quote - vehicle section : vehicle financed
	Given user is successfully logged into biberk
	When user clicks Quote Button
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks  Vehicles  Sidetab
	When user clicks  Vehicle  Button
	And user waits for spinner to load
	When user selects Financed Button
	And user enters Lienholder info
	Then user adds Address

Scenario: TC 26827 : Quote - vehicle section : vehicle leased
	Given user is successfully logged into biberk
	When user clicks Quote Button
	When User Navigates to Quote latest
	And user waits for spinner to load
	When user clicks  Vehicles  Sidetab
	When user clicks  Vehicle  Button
	And user waits for spinner to load
	When user selects Leased Button
	And user enters Lessor info
	Then user adds Address
