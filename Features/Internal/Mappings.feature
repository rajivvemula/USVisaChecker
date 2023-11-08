Feature: Mappings

Test to ensure no broken mappings

@Internal @Mappings @Build @NoSelenium
Scenario: Test CA mappings
	Given this is a mapping test
    Then the CA Additional Info mapping should compile
	And the CA Contact Details mapping should compile
	And the CA Incidents mapping should compile
	And the CA Drivers mapping should compile
	And the CA Quick Intro mapping should compile
	And the CA Operations mapping should compile
	And the CA Let's Start Your Quote mapping should compile
	And the CA Proposal Email mapping should compile
	And the CA Purchase Page mapping should compile
	And the CA Summary mapping should compile
	And the CA Reusable mapping should compile
	And the CA Save for Later mapping should compile
	And the CA Your Quote mapping should compile
	And the CA Terms and Conditions mapping should compile
	And the CA Thank You mapping should compile
	And the CA Vehicles mapping should compile
	And the Coming Soon mapping should compile
	And the CA Coverage Details mapping should compile
	And the CA Decline mapping should compile
	And the CA Referral Confirm mapping should compile
	And the CA Referral mapping should compile
