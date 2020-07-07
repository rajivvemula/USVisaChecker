Feature: R009-GeneralInformationSaveChanges
	In order to Policy General Information is working as intended
	As any User(defaults to admin)
	I want to confirm that changes made in General Information are saved

@mytag
Scenario: Change Business Type and Confirm Change
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
