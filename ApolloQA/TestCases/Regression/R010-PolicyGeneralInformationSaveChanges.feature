@reg
Feature: R009-GeneralInformationSaveChanges
	In order to Policy General Information is working as intended
	As any User(defaults to admin)
	I want to confirm that changes made in General Information are saved

Scenario:2 Change Business Type and Confirm Changes Are Saved
	Given User is shown the General Information screen 
	When User changes Business Type
	And Clicks Save Button
	Then User is shown a Toast confirming policy changes are saved
