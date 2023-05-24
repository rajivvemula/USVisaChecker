@NoBrowser
Feature: TestPlans

Scenario: Create TestPlan suite structure
	Given enforce desired folder structure in test plan '96142' and parent suite '96143'

Scenario: Upsert Test Cases in ADO
	Given Test Cases are gathered from current solution
	Then Test Cases are upserted into ADO

