Feature: Coverages

Verifying the elements on each coverage page

@BOPCoverage @Coverage @Regression @Static 
Scenario: BOP Coverage Page Verification
	Given user has navigated to the following URL within the host environment: small-business-insurance/business-owners-policy
	Then user validates the static page: BOP Coverage

@CACoverage @Coverage @Regression @Static 
Scenario: CA Coverage Page Verification
	Given user has navigated to the following URL within the host environment: small-business-insurance/commercial-auto-insurance
	Then user validates the static page: CA Coverage

@CyberCoverage @Coverage @Regression @Static
Scenario: Cyber Coverage Page Verification
	Given user has navigated to the following URL within the host environment: small-business-insurance/cyber-insurance
	Then user validates the static page: Cyber Coverage

@GLCoverage @Coverage @Regression @Static
Scenario: GL Coverage Page Verification
	Given user has navigated to the following URL within the host environment: small-business-insurance/general-liability-insurance
	Then user validates the static page: GL Coverage

@PLCoverage @Coverage @Regression @Static
Scenario: PLCoverage Page Verification
	Given user has navigated to the following URL within the host environment: small-business-insurance/professional-liability-insurance
	Then user validates the static page: PL Coverage

@UMCoverage @Coverage @Regression @Static
Scenario: UM Coverage Page Verification
	Given user has navigated to the following URL within the host environment: small-business-insurance/umbrella-insurance
	Then user validates the static page: Umbrella Coverage

@WCCoverage @Coverage @Regression @Static
Scenario: WC Coverage Page Verification
	Given user has navigated to the following URL within the host environment: small-business-insurance/workers-compensation-insurance
	Then user validates the static page: WC Coverage

@EOCoverage @Coverage @Regression @Static
Scenario: EOCoverage Page Verification
	Given user has navigated to the following URL within the host environment: small-business-insurance/errors-omissions-insurance
	Then user validates the static page: EO Coverage