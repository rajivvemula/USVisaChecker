Feature: WorkersCompAudit

 Verifies Forgot Phone Number Functionality for WC Audit

@Staging @Regression @WC @Ignore
Scenario: Forgot Number for WC Audit
	Given user has navigated to the following URL within the host environment: policyholders/audit/wc
	Then user verifies WC Audit page
	Then user clicks Forgot Phone Number button
	Then user validates Forgot Phone Number modal
	Then user fills out Forgot Phone Number modal with following values:
		| Question      | Answer     |
		| Policy Number | N9WC606830 |
	Then user validates that the Policy Details Have Been Emailed toast appears



