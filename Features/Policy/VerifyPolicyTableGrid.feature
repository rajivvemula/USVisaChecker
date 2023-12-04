Feature: VerifyPolicyTableGrid

Verifying the columns of the Policy Table Grid columns and their formats for the first row data

@Policy
Scenario: Verify Policy Table Grid Column Names and formats
	Given user is successfully logged into Apollo
	Then user see the Apollo HomePage
	When user clicks on Policy button on the header
	Then user verifies the Policy table grid column names
	And user verifies the Policy table row 1 has the correct format for fields
