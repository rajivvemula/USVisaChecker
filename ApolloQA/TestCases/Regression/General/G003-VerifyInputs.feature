Feature: G003-VerifyInputs
Test Various Inputs and Select on wether they exist or not


Scenario: Verify Inputs
	Then Verify an input is displayed with label
	| Key | Value        |
	| a   | Date of Loss |
	Then Verify a Select contains value : <Select Name>
	| Key | Value            |
	| a   | DropDown Value 1 |
	Then Verify if the input is required
	| Key | Value     | Required |
	| a   | Something | false    |
	
