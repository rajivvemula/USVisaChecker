@navigation @smoketest @organization
Feature: C003-Save Changes To A Organization
Save Changes To an Organization With a created organization or specific one


Scenario: Save Changes To An Organization
	Given User is on organization Created
	When User changes dropdown busInfoOrgType to LLC
	When User clicks orgInsertSave button
	Then Verify correct toast "was saved." is displayed


	