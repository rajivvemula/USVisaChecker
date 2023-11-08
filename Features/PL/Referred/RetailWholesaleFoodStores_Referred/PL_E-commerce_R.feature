Feature: PL_E-commerce_R

Referred due to saying "No" to Do you provide ecommerce/online sales services for others? in a certain state (TX).

#@PL @Referred @Service @Regression
Scenario: PL E-commerce gets referred
	Given user starts a quote with:
		| Industry   | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| E-commerce | 2         | I Lease a Space From Others |              | 77590    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | DBA |
		| Corporation        | Team Sellers     | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                  | Answer |
		| What year was your business started?                      | 2010   |
		| What is your estimated gross annual revenue?              | 50000  |
		| Do you use a written contract or statement of work (SOW)? | Never  |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer     |
		| When should your policy start?                                                         |            |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes        |
		| Does your current policy have a retroactive date?                                      | Yes        |
		| What is the retroactive date?                                                          | 07/25/2022 |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0          |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Can users upload content to websites you own or operate?                                                                                                                                                                                               | No     |
		| Do you electronically store private data?                                                                                                                                                                                                              | No     |
		| Do you provide website hosting or domain registration?                                                                                                                                                                                                 | No     |
		| Do you provide ecommerce/online sales services for others?                                                                                                                                                                                             | No     |
		| Do you design any hardware?                                                                                                                                                                                                                            | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user fills out About You page with these values:
		| Question               | Answer          |
		| First Name             | Test            |
		| Last Name              | EJ              |
		| Address                | 3545 Palmer Hwy |
		| Apt/Suite              | 3               |
		| City                   | Meskill         |
		| Use as Mailing Address | No              |
		| Mailing Address        | 12 East St      |
		| Mailing Apt/Suite      |                 |
		| Mailing ZIP            | 77590           |
		| Mailing City           | Texas City      |
		| Email                  | abc@bargain.com |
		| Business Phone         | 1231231212      |
		| Ext                    | 123             |
		| Website/Social         | www.Tester.com  |
	When user fills out the PL refer page with these values:
		| Field              | Value           |
		| Business name      | Team Sellers    |
		| Contact first name | Test            |
		| Contact last name  | EJ              |
		| Email              | abc@bargain.com |
		| Phone              | (123) 123-1231  |
		| Ext                | 1234            |
		| Business website   | www.Tester.com  |
	Then user verifies the PL refer confirmation appearance