Feature: PL_HomeInspection_D

Declined Policy For Home Inspection In NJ, handles soft credit score question section.

@Regression @PL @HealthCare @Declined @NJ 
Scenario: PL Home Inspection Declined Policy In New Jersey
	Given user starts a quote with:
		| Industry        | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Home Inspection | 1         | I Lease a Space From Others |              | 08401    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address | DBA |
		| Corporation        | HA               | 1900 Pacific Ave | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                   | Answer  |
		| What year was your business started?                                                       | 2010    |
		| What is your estimated gross annual revenue?                                               | 400,000 |
		| Do you use a written contract or statement of work (SOW)?                                  | Always  |
		| Who signs off on the terms & conditions for written contracts or statements of work (SOW)? | Legal   |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 1                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you inspect commercial buildings?                                                                                                                                                                                                                   | No     |
		| Do you directly perform physical work for others?                                                                                                                                                                                                      | No     |
		| Do you advise on the contamination risk, presence of, or clean up of mold or any pollutants?                                                                                                                                                           | No     |
		| Do you offer asbestos evaluation or abatement services?                                                                                                                                                                                                | No     |
		| Do you provide emergency response services?                                                                                                                                                                                                            | No     |
		| Do you inspect for termites or any other pests?                                                                                                                                                                                                        | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
		| Do you want to save up to 35% with a soft credit check?                                                                                                                                                                                                | No     |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer           |
		| First Name             | Tester           |
		| Last Name              | EJ               |
		| Address                | 1900 Pacific Ave |
		| Apt/Suite              |                  |
		| City                   | Atlantic City    |
		| Use as Mailing Address | Yes              |
		| Email                  | abc@tester.com   |
		| Business Phone         | 3213213211       |
		| Ext                    |                  |
		| Website/Social         |                  |
		| Have Broker            | No               |
	Then user verifies the PL decline page appearance

