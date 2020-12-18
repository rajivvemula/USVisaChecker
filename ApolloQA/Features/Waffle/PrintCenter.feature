Feature: Print Center
	As a user I want to be able to verify print center queue and its associated job

#seems to be looking for an unexisting 'Print Center' on that grid, in the pipeline it's running in QA2
@SmokeTest @PrintCenterUI @broken
Scenario: Verify PrintCenter Jobs
	Given user is successfully logged into biberk
	When user navigates to Printcenter Page by accessing Waffle 
	When User Clicks Print Center Link
    Then User should be redirected to Print Center Page 
	And User Clicks on the Last Queue name in Print Center table
	#Then User should see all the job associated to this Queue