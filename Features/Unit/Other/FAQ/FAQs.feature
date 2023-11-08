Feature: FAQs

FAQs verification

@Unit @Regression @FAQ @Static
Scenario: BOP FAQ Test
	Given user has navigated to the following URL within the host environment: policyholders/resources/faqs/business-owners-policy
	Then user verifies each FAQ on the BOP page

@Unit @Regression @FAQ @Static
Scenario: PL FAQ Test
	Given user has navigated to the following URL within the host environment: policyholders/resources/faqs/professional-liability
	Then user verifies each FAQ on the PL page

@Unit @Regression @FAQ @Static
Scenario: PolicyHolder FAQ Test
	Given user has navigated to the following URL within the host environment: policyholders/resources/faqs/policyholder
	Then user verifies each FAQ on the Policyholder page

@Unit @Regression @FAQ @Static
Scenario: WorkersComp FAQ Test
	Given user has navigated to the following URL within the host environment: policyholders/resources/faqs/workers-compensation
	Then user verifies each FAQ on the WC page

@Unit @Regression @FAQ @Static
Scenario: CA FAQ Test
	Given user has navigated to the following URL within the host environment: policyholders/resources/faqs/commercial-auto
	Then user verifies each FAQ on the CA page

@Unit @Regression @FAQ @Static 
Scenario: Popular FAQ Test
	Given user has navigated to the following URL within the host environment: policyholders/resources/faqs/popular
	Then user verifies each FAQ on the popular page

@Unit @Regression @FAQ @Static
Scenario: GL FAQ Test
	Given user has navigated to the following URL within the host environment: policyholders/resources/faqs/general-liability
	Then user verifies each FAQ on the GL page

@Unit @Regression @FAQ @Static
Scenario: UM FAQ Test
	Given user has navigated to the following URL within the host environment: policyholders/resources/faqs/umbrella-commercial-excess
	Then user verifies each FAQ on the UM page