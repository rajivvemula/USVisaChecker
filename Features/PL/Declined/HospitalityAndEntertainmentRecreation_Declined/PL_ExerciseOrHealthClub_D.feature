Feature: PL_ExerciseOrHealthClub_D
Exercise or Health Club: What training do you provide?

@Regression @PL
Scenario: PL Exercise Or HealthClub gets declined
	Given user starts a quote with:
		| Industry                | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Exercise or Health Club | 2         | I Lease a Space From Others |              | 08234    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address  | DBA |
		| Corporation        | Healthclub       | 7017 Fernwood Ave | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer |
		| What year was your business started?         | 2010   |
		| What is your estimated gross annual revenue? | 50000  |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                | Answer |
		| When should your policy start?                                          |        |
		| Do you currently have a Professional Liability (E&O) policy in effect?  | No     |
		| Have you had a Professional Liability (E&O) policy in the last 3 years? | No     |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer             |
		| Do you sell dietary supplements, vitamins, or performance-enhancing substances?                                                                                                                                                                        | No                 |
		| To whom do you provide training?                                                                                                                                                                                                                       | Group Fitness Only |
		| Do you help train clients for athletic competitions?                                                                                                                                                                                                   | No                 |
		| What training do you provide?                                                                                                                                                                                                                          | Rock Climbing      |
		| Do you operate tanning beds?                                                                                                                                                                                                                           | No                 |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                 |
	Then user fills out About You page with these values:
		| Question               | Answer              |
		| First Name             | Test                |
		| Last Name              | EJ                  |
		| Address                | 7017 Fernwood Ave   |
		| Apt/Suite              | 3                   |
		| City                   | Egg Harbor Township |
		| Use as Mailing Address | No                  |
		| Mailing Address        | 7017 Fernwood Ave   |
		| Mailing Apt/Suite      | 3                   |
		| Mailing ZIP            | 08234               |
		| Mailing City           | Egg Harbor Township |
		| Email                  | abc@bargain.com     |
		| Business Phone         | 1231231212          |
		| Ext                    | 123                 |
		| Website/Social         | www.tester.com      |
	Then user verifies the PL decline page appearance