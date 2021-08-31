Feature: Quote_Summary

Smoke Automation : Quote - Summary
Task 39589

Scenario: Verify correct Data is displayed in Quote Summary
	Given user is successfully logged into biberk
	When User creates a Quote using Entity Package 
	When user clicks 'Business Information' Sidetab
	When user clicks 'Summary' Sidetab
	Then User verifies correct rating package is selected
	Then User verifies Premium Details grid is displayed 
	Then User verifies correct amount of vehicles are listed in the premium
	Then User verifies Coverage Summary grid is displayed
	Then User verifies correct coverages are listed
	Then User verifies Vehicle grid is displayed 
	Then User verifies correct amount of vehicles in vehicles Grid
	Then User verifies vehicle grid can be expanded and VIN is listed
	Then User verifies Trailers grid is displayed 
	Then User verifies correct amount of trailers in trailers Grid
	Then User verifies Trailers grid can be expanded and VIN is listed