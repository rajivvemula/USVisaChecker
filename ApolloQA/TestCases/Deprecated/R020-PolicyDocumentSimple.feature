
Feature: R020-PolicyDocumentSimple
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario: 1 User Can Navigate To Documents
	When User Click on Documents
	Then User is shown the Documents screen for that policy

Scenario: 2 User is able to upload a document
	When User user clicks on New File 
	And user uploads a txt file
	Then User sees the file upload succesfully