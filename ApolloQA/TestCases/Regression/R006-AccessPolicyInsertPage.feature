Feature: R006-PolicyInsertScreenFromPolicyList
	
	As any User(defaults to admin)
	I want to access policy insert screen from policy list page and via URL


Scenario:1Access Insert Policy Page From Policy List Page 
	Given User clicks Policy Tab on navigation
	Then User is shown the Policy List
	When User clicks on New Button
	Then User is shown the Insert Policy Page


Scenario:2Access Insert Policy Page Via URL
	When User Navigates to Insert Policy Page Via URL
	Then User is shown the Insert Policy Page


Scenario:3Access Policy List Page By Cancelling a Policy Being Created
	Given User is on Insert Policy Page
	When User Click on the cancel button
	Then User is shown the Policy List