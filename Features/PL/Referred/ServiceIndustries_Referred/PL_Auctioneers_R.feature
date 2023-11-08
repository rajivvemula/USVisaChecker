Feature: PL_Auctioneers_R

Verifying the Auctioneers keyword triggers a referral when using the "Do you auction airplanes, cars, boats, or real estate?" question is answered in the affirmative.

@PL @Referred @Service @Regression
Scenario: PL Auctioneers Referred
	Given user starts a quote with:
		| Industry    | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Auctioneers | 7         | I Lease a Space From Others |              | 03884    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure       | Name of Business                | Business Address   | DBA |
		| Limited Liability Co LLC | SpeedyMcSpeaker's Auctioneering | 242 Willey Pond Rd | SA  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                   | Answer  |
		| What year was your business started?                                                       | 2019    |
		| What is your estimated gross annual revenue?                                               | 500,000 |
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
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you auction airplanes, cars, boats, or real estate?                                                                                                                                                                                                 | Yes    |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user fills out About You page with these values:
		| Question               | Answer          |
		| First Name             | Speedy          |
		| Last Name              | McSpeaker       |
		| Address                | 527 Province Rd |
		| Apt/Suite              | 1               |
		| City                   | Strafford       |
		| Use as Mailing Address | No              |
		| Mailing Address        | 432 Main st     |
		| Mailing Apt/Suite      | 1213            |
		| Mailing ZIP            | 03884           |
		| Mailing City           | Strafford       |
		| Email                  | test@biz.com    |
		| Business Phone         | 7777777777      |
		| Ext                    | 7777            |
		| Website/Social         | www.test.com    |
		| Have Broker            | No              |
	When user fills out the PL refer page with these values:
		| Field              | Value                           |
		| Business name      | SpeedyMcSpeaker's Auctioneering |
		| DBA                | SA                              |
		| Contact first name | Speedy                          |
		| Contact last name  | McSpeaker                       |
		| Email              | test@biz.com                    |
		| Phone              | (777) 777-7777                  |
		| Ext                | 7777                            |
		| Business website   | www.test.com                    |
	Then user verifies the PL refer confirmation appearance