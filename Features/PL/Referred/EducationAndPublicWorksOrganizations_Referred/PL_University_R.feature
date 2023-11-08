Feature: PL_University_R

Feature File that verifies certain classes automatically result in a referral

@PL @Referred @Service @Regression @Staging @PL_University_R
Scenario: PL University class referred
	Given user starts a quote with:
		| Industry   | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| University | 10        | I Lease a Space From Others |              | 80011    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business    | Business Address | DBA |
		| Corporation        | TEST PL API CASE 17 | 1250 Chambers Rd | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer |
		| What year was your business started?         | 2021   |
		| What is your estimated gross annual revenue? | 50000  |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer |
		| When should your policy start?                                                         |        |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | No     |
		| Have you had a Professional Liability (E&O) policy in the last 3 years?                | Yes    |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0      |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer                  |
		| Describe the type of training/education provided:                                                                                                                                                                                                      | TEST UNIVERSITY CASE 17 |
		| Do you provide medical training?                                                                                                                                                                                                                       | No                      |
		| Do you provide driving or flying instruction?                                                                                                                                                                                                          | No                      |
		| Do you provide law enforcement or security guard services or training?                                                                                                                                                                                 | No                      |
		| Do you train animals?                                                                                                                                                                                                                                  | No                      |
		| Do you have nurses on staff?                                                                                                                                                                                                                           | No                      |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                      |
	Then user fills out About You page with these values:
		| Question               | Answer              |
		| First Name             | TEST PL API         |
		| Last Name              | TEST CASE 17        |
		| Address                | 3475 N Salida St    |
		| City                   | Aurora              |
		| Use as Mailing Address | Yes                 |
		| Email                  | TestCert@Plan.com   |
		| Business Phone         | (123) 123-1321      |
		| Ext                    | 1234                |
		| Website/Social         | TestPartnerCert.com |
	When user fills out the PL refer page with these values:
		| Field              | Value                   |
		| Business name      | TEST PL API CASE 17     |
		| Contact first name | Test PL API             |
		| Contact last name  | TEST CASE 17            |
		| Email              | TestCert@Plan.com       |
		| Phone              | (123) 123-1231          |
		| Ext                | 1234                    |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the PL refer confirmation appearance