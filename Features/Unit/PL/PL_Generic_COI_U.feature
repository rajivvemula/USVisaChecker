Feature: PL_Generic_COI_U

Task 81972: Staging Regression (PL) | Create Test Case | Provide a generic COI as part of the policy confirmation email in order to improve the customer experience and reduce service engagement

@PL @Unit @Staging
Scenario: PL Generic COI
	Given user starts a quote with:
		| Industry     | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Hair Stylist | 3         | I Lease a Space From Others |              | 60101    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
		Then user fills out A Quick Introduction page with these values:
		| Business Structure         | DBA                                 |
		| Individual/Sole Proprietor | TEST DBA PL - NON-ATTORNEY PURCHASE |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer    |
		| What year was your business started?         | 2016      |
		| What is your estimated gross annual revenue? | 250,000 |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer     |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes        |
		| Does your current policy have a retroactive date?                                      | Yes        |
		| What is the retroactive date?                                                          | 01/01/2021 |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0          |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you provide body massage services?                                                                                                                                                                                                                  | No     |
		| Do you provide tattoo services?                                                                                                                                                                                                                        | No     |
		| Do you operate tanning beds?                                                                                                                                                                                                                           | No     |
		| Do you do keratin hair-straightening procedures or brazilian blowouts?                                                                                                                                                                                 | No     |
		| Do you do body piercings?                                                                                                                                                                                                                              | No     |
		| Do you do any body sculpting or cosmetic medical procedures?                                                                                                                                                                                           | No     |
		| Do you provide acupuncture, facial injection, fillers, or laser treatment services?                                                                                                                                                                    | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user fills out About You page with these values:
		| Question               | Answer            |
		| First Name             | TestF             |
		| Last Name              | TestL             |
		| Address                | 233 N Mill Rd     |
		| Apt/Suite              |                   |
		| City                   | Addison           |
		| Use as Mailing Address | Yes               |
		| Email                  | TestCert@Plan.com |
		| Business Phone         | (123) 123-1321    |
		| Website/Social         |                   |
	Then user verifies the appearance of the PL Summary page
	Then user verifies that the following coverages are displayed in the details of their PL Plus Quote: PL,Cyber
	Then user selects their Yearly - Plus Quote
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | Off                 |
		| CC Name        | TestF TestL         |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 03/30               |
		| Phone          | 1231231321          |
		| Extension      | 1234                |
	

