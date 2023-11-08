Feature: PL_UFCGym_R
UFC gym PL Referral due to having 2 claims

@PL @Hospitality @Regression @Referred @Staging @Ignore
Scenario: PL UFC Gym gets referred
	Given user starts a quote with:
		| Industry | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| UFC Gym  | 2         | I Run My Business From Property I Own |              | 29209    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | DBA      |
		| Corporation        | UFC Gym          | UFC Bust |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer |
		| What year was your business started?         | 2000   |
		| What is your estimated gross annual revenue? | 500000 |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer |
		| When should your policy start?                                                         |        |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | No     |
		| Have you had a Professional Liability (E&O) policy in the last 3 years?                | Yes    |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 1      |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer             |
		| Do you sell dietary supplements, vitamins, or performance-enhancing substances?                                                                                                                                                                        | No                 |
		| To whom do you provide training?                                                                                                                                                                                                                       | Group Fitness Only |
		| Do you help train clients for athletic competitions?                                                                                                                                                                                                   | Yes                |
		| Describe the athletic competitions:                                                                                                                                                                                                                    | They always win    |
		| Do you train professional athletes?                                                                                                                                                                                                                    | No                 |
		| What training do you provide?                                                                                                                                                                                                                          | Weight Training    |
		| Do you operate tanning beds?                                                                                                                                                                                                                           | No                 |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                 |
	Then user fills out About You page with these values:
		| Question               | Answer                |
		| First Name             | Marty                 |
		| Last Name              | Mailbox               |
		| Address                | 7501 Garners Ferry Rd |
		| City                   | Columbia              |
		| Use as Mailing Address | Yes                   |
		| Email                  | test@biz.com          |
		| Business Phone         | 3172491913            |
	When user fills out the PL refer page with these values:
		| Field              | Value                            |
		| Business name      | Test PL API Test Case 16         |
		| DBA                | UFC Bust                         |
		| Contact first name | Test PL API                      |
		| Contact last name  | Test Case 16                     |
		| Email              | TestCert@Plan.com                |
		| Phone              | (123) 123-1231                   |
		| Ext                | 1234                             |
		| Business website   | www.MixedMartialArtsTraining.com |
	Then user verifies the PL refer confirmation appearance