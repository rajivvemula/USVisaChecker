Feature: PL_CustomTailoring_I

Issued PL Policy for Custom Tailoring with Cyber Liability Aggregate Limit - Single Limit

@PL @Issued @Service @Staging @Regression @PA
Scenario: PL Custom Tailoring Issued Policy in PA
	Given user starts a quote with:
		| Industry         | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Custom Tailoring | 1         | I Lease a Space From Others |              | 17404    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business           | Business Address | DBA      |
		| Corporation        | Test PL Cyber Single Limit | 1060 Church Rd   | Test DBA |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer  |
		| What year was your business started?         | 2016    |
		| What is your estimated gross annual revenue? | 250,000 |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer       |
		| When should your policy start?                                                         |              |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes          |
		| Does your current policy have a retroactive date?                                      | I Don't Know |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0            |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user fills out About You page with these values:
		| Question               | Answer                |
		| First Name             | TestF                 |
		| Last Name              | TestL                 |
		| Address                | 100 Test Road         |
		| Apt/Suite              |                       |
		| City                   | York                  |
		| Use as Mailing Address | Yes                   |
		| Email                  | Automation@biBERK.com |
		| Business Phone         | 1231231321            |
		| Ext                    | 1234                  |
	Then user verifies the appearance of the PL Summary page
	Then user verifies that the following coverages are displayed in the details of their PL Plus Quote: PL,Cyber
	Then user selects their Monthly - Plus Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | Mandatory           |
		| CC Name        | TestF TestL         |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 03/30               |
		| Street Address | 100 Test Road       |
		| ZIP Code       | 17404               |
		| City           | York                |
		| Phone          | 1231231321          |
		| Extension      | 1234                |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: WC