Feature: PL_BoxingGym_I

Partial Feature File added for implementing the "Then user verifies the PL purchase page appearance" step logic - US 71967

@Regression @PL @Hospitality @Issued @HI @Ignore
Scenario: PL Boxing Gym Issued policy in HI
	Given user starts a quote with:
		| Industry   | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Boxing Gym | 7         | I Lease a Space From Others |              | 96815    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business    | Business Address  | DBA |
		| Corporation        | Little Mac's Boxing | 2365 Kalākaua Ave | LMB |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer   |
		| What year was your business started?         | 2020     |
		| What is your estimated gross annual revenue? | $500,000 |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer |
		| When should your policy start?                                                         |        |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes    |
		| Does your current policy have a retroactive date?                                      | Yes    |
		| What is the retroactive date?                                                          |        |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0      |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer             |
		| Do you sell dietary supplements, vitamins, or performance-enhancing substances?                                                                                                                                                                        | No                 |
		| To whom do you provide training?                                                                                                                                                                                                                       | Group Fitness Only |
		| Do you help train clients for athletic competitions?                                                                                                                                                                                                   | No                 |
		| What training do you provide?                                                                                                                                                                                                                          | Zumba              |
		| Do you operate tanning beds?                                                                                                                                                                                                                           | No                 |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                 |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer             |
		| First Name             | Teddy              |
		| Last Name              | Treebark           |
		| Address                | 2365 Kalākaua Avel |
		| Apt/Suite              |                    |
		| City                   | Honolulu           |
		| Use as Mailing Address | Yes                |
		| Email                  | test@biz.com       |
		| Business Phone         | 9198857474         |
		| Ext                    |                    |
		| Website/Social         |                    |
		| Have Broker            | No                 |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | On                  |
		| CC Name        | Little Mac          |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 07/25               |
		| Street Address | 2365 Kalākaua Ave   |
		| ZIP Code       | 96815               |
		| City           | Honolulu            |
		| Phone          | 777-777-7777        |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: WC