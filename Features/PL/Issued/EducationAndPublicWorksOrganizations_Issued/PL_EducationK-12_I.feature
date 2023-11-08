Feature: EducationK-12

Issuing a PL Policy using the Education: K-12 keyword

@Regression @PL @Education @ME @Issued
Scenario: PL Education: K-12 issued plicy in ME
	Given user starts a quote with:
		| Industry        | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Education: K-12 | 7         | I Lease a Space From Others |              | 04660    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address | DBA |
		| Corporation        | Educators        | 12 Brendun Ln    | No  |
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
		| Question                                                                                                                                                                                                                                               | Answer |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer           |
		| First Name             | K-12             |
		| Last Name              | Educator         |
		| Address                | 10 Abels Ln      |
		| Apt/Suite              |                  |
		| City                   | Mt Desert        |
		| Use as Mailing Address | Yes              |
		| Email                  | Educator@biz.com |
		| Business Phone         | 8887775767       |
		| Ext                    |                  |
		| Website/Social         |                  |
		| Have Broker            | No               |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | Off                 |
		| CC Name        | K-12 Educator       |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 07/25               |
		| Street Address | 10 Abels Ln         |
		| ZIP Code       | 04660               |
		| City           | Mt Desert           |
		| Phone          | 888-777-5767        |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: WC