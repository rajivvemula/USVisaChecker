﻿Feature: Quote_Modifiers

#Combined Scenario
Scenario Outline: Screen Test For Policy Modifiers Page
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks 'New' Button
	When User create a new Org with <State>
	And User enters quote details on Quote Page
	When user clicks 'Next' Button
	When user clicks 'Modifiers' Sidetab
	Then User Verifies all inputs are interactable
	Then User verifies the Modifier Total percentage is correct
	Then User verifies the Upper Boundaries for <State>
	Then User verifies the Lower Boundaries for <State>
	Then User verifies the percentage values are displayed correctly
	Then User verifies unable to click next when past max percentage boundary


	Examples:
	| State | 
	| IL    |


Scenario Outline: Test Modifiers page Values Are Saved
	Given user is successfully logged into biberk
	When user navigates to Quote Page
	And user clicks 'New' Button
	When User create a new Org with <State>
	And User enters quote details on Quote Page
	When user clicks 'Next' Button
	When user clicks 'Modifiers' Sidetab
	Then User enters max values for each modifier
	When user clicks 'Save' Button
	When user clicks 'Next' Button
	When user clicks 'Modifiers' Sidetab
	Then User verifies max values are retained for each modifier

	Examples:
	| State | 
	| IL    |