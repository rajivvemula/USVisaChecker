Feature: R060-NewApplication
	In order to test application creation
	As an authorized user
	I want to be able to create an application

Scenario: 1 Create new application
	When I attempt to create an application with Casey Test Org 904, Commercial Auto, 09/15/2020
	#parameters in above When step are stored in FeatureContext, then used to validate correct data is displayed in below Then step
	Then an application is successfully created with the proper values
	#Then step also saves the application number to FeatureContext for later use
	

Scenario: 2 Business Information tab 
	When I update mailing address to existing address 123 Test Address, Forty Fort, PA, 18704
	#above step stores new mailing address in FeatureContext
	Then The Mailing Address is successfully updated
	#validates displayed mailing address against the one stored in FeatureContext
	