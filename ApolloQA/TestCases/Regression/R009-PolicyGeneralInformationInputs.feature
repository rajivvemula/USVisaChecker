@reg @pol
Feature: R009-PolicyGeneralInformationInputs
	
	As any User(defaults to admin)
	I want to confirm all inputs and their functionality is present


Scenario:1 Check all labels of Inputs are as expected
	Given User is shown the General Information screen 
	Then Expected input labels are there

Scenario:2 Change Business Type and Confirm Changes Are Saved
	Given User is shown the General Information screen 
	When User changes Business Type
	And Clicks Save Button
	Then User is shown a Toast confirming policy changes are saved