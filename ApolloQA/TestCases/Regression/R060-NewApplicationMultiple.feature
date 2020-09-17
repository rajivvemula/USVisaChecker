Feature: R060-NewApplicationMultiple
	In order to test application creation
	As an authorized user
	I want to be able to create an application

# This is more of a full workflow just covering required values, rather than a thorough test of the individual pages. 
# To do - add page tags to steps to identify which page they belong to (e.g. @Application-BusinessInformation)



Scenario Outline: 1 Create new application
	#creates and stores ApplicationObjects in list
	When I create a new application with values <Business Name>, <LOB>, <Effective Date> as Application Index <Application Index>
	#validates expected values stored in object against actual values on webpage
	Then an application is successfully created with the proper values for Application Index <Application Index>

Examples: 
	| Application Index | Business Name      | LOB             | Effective Date |
	| 0                 | Casey Test Org 904 | Commercial Auto | 10/01/2020     |
	| 1                 | Casey Test Org 916 | Commercial Auto | 10/15/2020     |



Scenario Outline: 2 Business Information - Select Mailing
	#Given I am on the application's Business Information tab
	When I update mailing address to existing address <Existing Address> for Application Index <Application Index>
	Then The Mailing Address is successfully updated for Application Index <Application Index>

Examples:
	| Application Index | Existing Address                        |
	| 0                 | 123 Test Address, Forty Fort, PA, 18704 |
	| 1                 | 345 Existing Address, Plains, PA, 18705 |


	
#Scenario Outline: 3 Contacts - Add Contacts
#	#Given I am on the application's Contacts tab
#	When I add contact XYZ
#	Then the contact is displayed on the application contacts page
#
#Examples: 
#	| First Name | Last Name | Primary Phone | Email | 