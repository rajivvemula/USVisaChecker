Feature: COI_Email_Cert

A short summary of the feature

@Regression @COI @Unit
Scenario: COI_EmailCertificateofInsurance
	Given user navigates to the COI page
	Then user verifies landing on Get a Certificate of Insurance login page
	Then user enters a policy number with a phone number
	| Policy Number | Phone          |
	| N9PL573614    | (843) 621-0348 |
	Then user fills out the COI form with the following values:
	| Question                                                             | Answer                   |
	| Do you need a certificate for a subcontractor or third-party vendor? | Yes                      |
	| Do you want a certificate for all of your insurance policies?        | No                       |
	| Subcontractor/Third-Party Business Name                              | Test                     |
	| Subcontractor/Third-Party Business Street Address                    | 100 Test Rd              |
	| Subcontractor/Third-Party Business Apt/Suite                         | 308                      |
	| ZIP Code                                                             | 29582                    |
	| Email                                                                | mark.maclaren@biberk.com |
	Then user verifies the appearance of the certificate confirmation page