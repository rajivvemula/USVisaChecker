@reg @pol
Feature: R014-PolicyContacts
	In order to Policy Contacts is working as intended
	As any User(defaults to admin)
	I want to be able to add, delete Contacts



Scenario: 1A User Can Navigate To Contacts
	When User Click on Contacts
	Then User is shown the Contacts screen for that policy


Scenario: 1B User Can Click Add New Contact Button
	When User Click Add New Contact Button
	Then User is shown the Contact Insert Screen

Scenario:1C Check all labels of Inputs For Contact Insert are as expected
	Given User is shown the Contact Insert screen 
	Then Expected input labels for Contact Insert are there

Scenario:1D Verify Contact Party Role
	When User selects the contact party role dropdown
	Then Contact party role select is a required value
	Then User is shown all the values for Contact Party Role dropdown

Scenario:1E Verify First Name Input
	When User inputs value in First Name
	Then First Name Input accepts the value
	And First Name input is a required value

Scenario:1F Verify Middle Name Input
	When User inputs value in Middle Name
	Then Middle Name Input accepts the value

Scenario:1G Verify Last Name Input
	When User inputs value in Last Name
	Then Last Name Input accepts the value
	And Last Name input is a required value

Scenario:1H Verify Suffix Name Input
	When User inputs value in Suffix Name
	Then Suffix Name Input accepts the value

Scenario:1I Verify Email Name Input
	When User inputs value in Email Name
	Then Email Name Input accepts the value
	And Email Name input is a required value

Scenario:1J Verify Email Input Requires Valid Email
	When User inputs value in non valid Email Name
	Then Email is invalid error is shown

Scenario:1K Verify Job Title Input
	When User inputs value in Job Title
	Then Job Title Input accepts the value

Scenario:1L Verify Company Input
	When User inputs value in Company
	Then Company Input accepts the value

Scenario:1M Verify Internet Address Input
	When User inputs value in Internet Address
	Then Internet Address Input accepts the value

Scenario:1N Verify Remarks Input
	When User inputs value in Remarks 
	Then Remarks Input accepts the value

Scenario:1O Verify Phone Type
	When User selects the contact Phone Type dropdown
	Then User is shown all the values for Phone Type dropdown
	And Verify Phone Type select is a required value

Scenario:1P Verify Phone Number Input
	When User inputs value in Phone Number
	Then Phone Number Input accepts the value

Scenario:1Q Phone Number Input Requires Numbers only
	When User inputs value in a letter in Phone Number Input
	Then Phone Number Input is blank

Scenario:1R User is able to cancel inserting a contact
	When User clicks on cancel Button in Insert Contact
	Then User is shown the Navigating Away Alert
	When User clicks continue anyway
	Then User is shown the Contacts screen for that policy