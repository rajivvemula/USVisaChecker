﻿
Feature: D001-Navigating To Application Insert
	Navigate To Organization Insert


Scenario: 1 Navigate to Application Insert Page
	Given User is on Homepage
	When User navigates to Application Tab
	Then Tab navigates to Application URL
	When User clicks appGridNew button
	Then Verify correct page appInsert is displayed

Scenario: Navigate to Application Insert Page(Single Step)
	When User Navigates to Application Insert 