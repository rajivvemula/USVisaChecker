Feature: PL_HairStylist_R

//Task 81859: Staging Regression | Create Test Case | PL | Referral | Grey List

@PL @Service @Regression @Referred @Staging
Scenario: PL HairStylist Referred
	Given user starts a quote with:
		| Industry     | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Hair Stylist | 0         | I Lease a Space From Others |              | 57007    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business    | Business Address | DBA |
		| Partnership        | TEST PL API CASE 18 | 11               | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer    |
		| What year was your business started?         | 2019      |
		| What is your estimated gross annual revenue? | 2,750,000 |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer     |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes        |
		| Does your current policy have a retroactive date?                                      | Yes        |
		| What is the retroactive date?                                                          | 11/01/2017 |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0          |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you provide body massage services?                                                                                                                                                                                                                  | No     |
		| Do you provide tattoo services?                                                                                                                                                                                                                        | Yes    |
		| Do you operate tanning beds?                                                                                                                                                                                                                           | No     |
		| Do you do keratin hair-straightening procedures or brazilian blowouts?                                                                                                                                                                                 | No     |
		| Do you do body piercings?                                                                                                                                                                                                                              | Yes    |
		| Do you do any body sculpting or cosmetic medical procedures?                                                                                                                                                                                           | No     |
		| Do you provide acupuncture, facial injection, fillers, or laser treatment services?                                                                                                                                                                    | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user fills out About You page with these values:
		| Question               | Answer                  |
		| First Name             | TEST PL API             |
		| Last Name              | TEST CASE 18            |
		| Address                | 2021 3rd St             |
		| Apt/Suite              |                         |
		| City                   | Brookings               |
		| Use as Mailing Address | Yes                     |
		| Email                  | TestCert@Plan.com       |
		| Business Phone         | (123) 123-1231          |
		| Website/Social         | www.TestPartnerCert.com |
		| Have Broker            | No                      |
	When user fills out the PL refer page with these values:
		| Field              | Value                   |
		| Business name      | TEST PL API CASE 18     |
		| Contact first name | TEST PL API             |
		| Contact last name  | TEST CASE 18            |
		| Email              | TestCert@Plan.com       |
		| Phone              | (123) 123-1231          |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the PL refer confirmation appearance
