#none of these scenarios are working on QA2
Feature: Print Center
	As a user I want to be able to verify print center queue and its associated job
# Pre Conditions since we don't have UI to create these data: 
# Make sure to have Printer Queue SQL table has queue name [system].[PrinterQueue], 
# Take the Queue ID and use it for API End Point Body printerQueueId, 
# Login to Azure Portal, Navigate to Document entitiy in cosmos and take ID which has hash value and use it for documentId

@SmokeTest @PrintCenterUI
# US 21816 - Print Center Functions (4 Test cases)
#TODO
Scenario: Post API Call to make Print Center Queue data and make sure it has been added to the grid
	Given user is successfully logged into biberk
	When  User adds data to printcenter queue
	
Scenario: TC04 Verify PrintCenter - Schedule for last item on the dashboard
	Given user is successfully logged into biberk
	When user navigates to Printcenter Page by accessing Waffle 
	When User Clicks Print Center Link
    Then User should be redirected to Print Center Page 
	Then User Clicks on the Last Queue name in Print Center table
	Then User should see all the job associated to this Queue
	And User clicks Dashboard
	Then User clicks Schedule link from the last queue name
	And User Enter time on schedule pop-up
	And User Click Schedule button
	Then User Verifies the notes

Scenario: TC04 Verify PrintCenter - Cancel Schedule for last item on the dashboard
	Given user is successfully logged into biberk
	When user navigates to Printcenter Page by accessing Waffle 
	When User Clicks Print Center Link
    Then User should be redirected to Print Center Page 
	Then User clicks Cancel Schedule link from the last queue name

Scenario: TC02 Verify PrintCenter Job - Hold and Stop Hold for last item on the job queue
	Given user is successfully logged into biberk
	When user navigates to Printcenter Page by accessing Waffle 
	When User Clicks Print Center Link
    Then User should be redirected to Print Center Page 
	And User Clicks on the Last Queue name in Print Center table
	Then User should see all the job associated to this Queue
	And User Clicks Hold link
	Then User verifies link renamed to Stop Hold
	And User clicks Dashboard
	Then User Clicks on the Last Queue name in Print Center table
	And User clicks Stop Hold link
	Then User Verifies link renamed to Hold
	And User clicks Dashboard

Scenario: TC03 Verify PrintCenter - Delete for last item on the job queue
	Given user is successfully logged into biberk
	When user navigates to Printcenter Page by accessing Waffle 
	When User Clicks Print Center Link
    Then User should be redirected to Print Center Page 
	And User Clicks on the Last Queue name in Print Center table
	Then User should see all the job associated to this Queue
	Then User Click Delete button from the last queue name
	 
Scenario: TC01 Verify PrintCenter - Release for last item on the job queue
	Given user is successfully logged into biberk
	When  User adds data to printcenter queue
	When user navigates to Printcenter Page by accessing Waffle 
	When User Clicks Print Center Link
    Then User should be redirected to Print Center Page 
	And User Clicks on the Last Queue name in Print Center table
	Then User should see all the job associated to this Queue
	Then User clicks Release button from the last queue name 



