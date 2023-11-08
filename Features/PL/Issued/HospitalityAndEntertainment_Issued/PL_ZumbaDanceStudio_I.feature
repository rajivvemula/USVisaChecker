Feature: PL_ZumbaDanceStudio_I

Issuing a policy using the Zumba Dance Studio keyword

@Regression @PL @Education @Issued @MN
Scenario: PL Zumba Dance Studio issued policy in MN
	Given user starts a quote with:
		| Industry           | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Zumba Dance Studio | 10        | I Lease a Space From Others |              | 55082    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address | DBA |
		| Corporation        | Zumba Dancing    | 515 2nd St N     | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer  |
		| What year was your business started?         | 2000    |
		| What is your estimated gross annual revenue? | 777,777 |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer             |
		| Do you sell dietary supplements, vitamins, or performance-enhancing substances?                                                                                                                                                                        | No                 |
		| To whom do you provide training?                                                                                                                                                                                                                       | Group Fitness Only |
		| Do you help train clients for athletic competitions?                                                                                                                                                                                                   | No                 |
		| Do you operate tanning beds?                                                                                                                                                                                                                           | No                 |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                 |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer                  |
		| First Name             | Zumba                   |
		| Last Name              | Instructor              |
		| Address                | 515 2nd St N            |
		| Apt/Suite              |                         |
		| City                   | Stillwater              |
		| Use as Mailing Address | Yes                     |
		| Email                  | ZumbaInstructor@biz.com |
		| Business Phone         | 8887775767              |
		| Ext                    |                         |
		| Website/Social         |                         |
		| Have Broker            | No                      |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | Off                 |
		| CC Name        | Zumba Instructor    |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 07/25               |
		| Street Address | 515 2nd St N        |
		| ZIP Code       | 55082               |
		| City           | Stillwater          |
		| Phone          | 777-777-7777        |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: WC, BOP