Feature: R002_AdminPrivileges
	In order navigate Apollo with ease
	As a Admin
	I want to have appropriate privileges

@reg
Scenario: Verify Admin Privileges
	Given User is on Dashboard
	When User is logged in as Admin
	Then Admin should have Appropriate User Roles

