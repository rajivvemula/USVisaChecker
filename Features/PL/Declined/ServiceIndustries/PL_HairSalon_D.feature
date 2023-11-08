Feature: PL_HairSalon_D
declined for Keratin hair-straightening & Brazilian Blowouts

Partial Feature File added for implementing the "Then user verifies the PL purchase page appearance" step logic - US 71967

@Regression @PL @HairSalon @Declined 
Scenario: PL Hair Salon gets Declined 
	Given user starts a quote with:
		| Industry   | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Hair Salon | 10        | I Lease a Space From Others |              | 15206    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business    | Business Address | DBA |
		| Corporation        | Little Mac's Boxing | 6425 Penn Ave    | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer   |
		| What year was your business started?         | 2020     |
		| What is your estimated gross annual revenue? | $500,000 |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer     |
		| When should your policy start?                                                         |            |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes        |
		| Does your current policy have a retroactive date?                                      | Yes        |
		| What is the retroactive date?                                                          | 06/24/2022 |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0          |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you provide body massage services?                                                                                                                                                                                                                  | No     |
		| Do you provide tattoo services?                                                                                                                                                                                                                        | No     |
		| Do you operate tanning beds?                                                                                                                                                                                                                           | No     |
		| Do you do keratin hair-straightening procedures or brazilian blowouts?                                                                                                                                                                                 | Yes    |
		| Do you do body piercings?                                                                                                                                                                                                                              | No     |
		| Do you do any body sculpting or cosmetic medical procedures?                                                                                                                                                                                           | No     |
		| Do you provide acupuncture, facial injection, fillers, or laser treatment services?                                                                                                                                                                    | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user fills out About You page with these values:
		| Question       | Answer          |
		| First Name     | Test            |
		| Last Name      | EJ              |
		| Address        | 7370 Baker St   |
		| Apt/Suite      |                 |
		| City           | Pittsburgh      |
		| Email          | abc@bargain.com |
		| Business Phone | 1231231212      |
	Then user verifies the PL decline page appearance