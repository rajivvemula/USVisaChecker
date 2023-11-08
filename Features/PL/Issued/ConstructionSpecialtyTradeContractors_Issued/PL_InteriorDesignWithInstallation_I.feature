Feature: PL_InteriorDesignWithInstallation_I

Issuing a policy using the Interior Design: With Installation keyword

@Regression @PL @Construction @CO @Issued
Scenario: PL Interior Design With Installation issued in CO
	Given user starts a quote with:
		| Industry                           | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Interior Design: With Installation | 10        | I Lease a Space From Others |              | 80823    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business   | Business Address   | DBA |
		| Corporation        | Interior Designers | 28905 County Rd S  | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                   | Answer  |
		| What year was your business started?                                                       | 2000    |
		| What is your estimated gross annual revenue?                                               | 777,777 |
		| Do you use a written contract or statement of work (SOW)?                                  | Always  |
		| Who signs off on the terms & conditions for written contracts or statements of work (SOW)? | Legal   |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer              |
		| Do you advise on building or moving load-bearing walls?                                                                                                                                                                                                | No                  |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                  |
		| Do you want to save up to 35% with a soft credit check?                                                                                                                                                                                                | Yes                 |
		| Soft credit check info name                                                                                                                                                                                                                            | First Lastname      |
		| Soft credit check info address                                                                                                                                                                                                                         | 123 Test St;Apt #99 |
		| Soft credit check info zip                                                                                                                                                                                                                             | 83338               |
		| Soft credit check info city                                                                                                                                                                                                                            | Falls City          |
		| Soft credit check info state                                                                                                                                                                                                                           | Idaho               |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer                   |
		| First Name             | Interior                 |
		| Last Name              | Designer                 |
		| Address                | 1633 Page St             |
		| Apt/Suite              |                          |
		| City                   | Karval                   |
		| Use as Mailing Address | Yes                      |
		| Email                  | InteriorDesigner@biz.com |
		| Business Phone         | 8407673450               |
		| Ext                    |                          |
		| Website/Social         |                          |
		| Have Broker            | No                       |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | Off                 |
		| CC Name        | Interior Designer   |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 07/25               |
		| Street Address | 1633 Page St        |
		| ZIP Code       | 80823               |
		| City           | Karval              |
		| Phone          | 840-767-3450        |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: CA, WC, BOP