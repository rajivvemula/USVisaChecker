Feature: PL_BusTours_I

Issuing a Bus tours policy to a customer in NE

@Regression @PL @Transportation @Issued @NE
Scenario: PL Bus Tours issued policy in NE
	Given user starts a quote with:
		| Industry  | Employees | Location                    | Own or Lease                | ZIP Code | LOB |
		| Bus Tours | 7         | I Lease a Space From Others | Vehicles;Tools or Equipment | 68130    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business  | Business Address  | DBA |
		| Corporation        | Pacific Bus Tours | 17810 W Center Rd | No  |
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
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you collect private data?                                                                                                                                                                                                                           | No     |
		| Do you operate tour buses or boats?                                                                                                                                                                                                                    | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer           |
		| First Name             | Bus              |
		| Last Name              | Driver           |
		| Address                | 16909 Pacific St |
		| Apt/Suite              |                  |
		| City                   | Omaha            |
		| Use as Mailing Address | Yes              |
		| Email                  | BusTours@biz.com |
		| Business Phone         | 8887775767       |
		| Ext                    |                  |
		| Website/Social         |                  |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | On                  |
		| CC Name        | Pacific Bus Tours   |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 07/24               |
		| Street Address | 16909 Pacific St    |
		| ZIP Code       | 68130               |
		| City           | Omaha               |
		| Phone          | 888-777-5767        |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: WC