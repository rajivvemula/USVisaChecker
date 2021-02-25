@broken
#TODO
Feature: LossDetails


@broken
#Searching for FNOL didn't return anything?
Scenario: User able to complete loss details on Pending FNOL
Given user is successfully logged into biberk
	When user clicks 'apps' icon Button
	When user clicks Claim right menu button
	And user selects pending FNOL
	And user waits for spinner to load
	And user navigates to Loss Details
	And user completes loss details section
	And user completes Other Insurer Info
	And user completes Vehicle damage section
	And user completes additional information section
	Then user assert for Loss Details save 

