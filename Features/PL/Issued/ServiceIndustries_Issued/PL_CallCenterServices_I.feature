Feature: PL_CallCenterServices_I

Issuing a Call Center Services PL policy to a customer in Florida.

@Regression @PL @Service @Issued @FL
Scenario: PL Call Center Services issued policy in FL
	Given user starts a quote with:
		| Industry             | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Call Center Services | 7         | I Lease a Space From Others |              | 32643    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business   | Business Address | DBA |
		| Corporation        | Off The Hook Calls | 5529 NE 52nd Pl  | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                   | Answer   |
		| What year was your business started?                                                       | 2010     |
		| What is your estimated gross annual revenue?                                               | $500,000 |
		| Do you use a written contract or statement of work (SOW)?                                  | Always   |
		| Who signs off on the terms & conditions for written contracts or statements of work (SOW)? | Legal    |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer                                     |
		| Do you collect private data?                                                                                                                                                                                                                           | No                                         |
		| Do you record all calls with customers?                                                                                                                                                                                                                | Yes we keep the records for 1 year or less |
		| Do you comply with applicable "Do Not Call" laws/regulations?                                                                                                                                                                                          | Yes                                        |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                                         |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer             |
		| First Name             | TestF              |
		| Last Name              | TestLast           |
		| Address                | 20112 US441        |
		| Apt/Suite              |                    |
		| City                   | High Springs       |
		| Use as Mailing Address | Yes                |
		| Email                  | CallCenter@biz.com |
		| Business Phone         | 9198857474         |
		| Ext                    |                    |
		| Website/Social         |                    |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | Off                 |
		| CC Name        | Off The Hook Calls  |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 07/24               |
		| Street Address | 20112 US441         |
		| ZIP Code       | 32643               |
		| City           | High Springs        |
		| Phone          | 7777777777          |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: CA, WC, BP