Feature: PL_HedgeFund_D

User Story 81873: Staging Regression | Create Test Case | PL | Decline | Blacklist
Declined reason: Prior customer relationship , Previous Customer – High Risk based on  Email.

@Regression @PL @HedgeFund @Declined @Staging @OH 
Scenario: PL HedgeFund gets Declined
	Given user starts a quote with:
		| Industry   | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Hedge Fund | 0         | I Lease a Space From Others |              | 44444    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address  | DBA |
		| Corporation        | HedgeFund        | 2745 Grandview Rd | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                   | Answer     |
		| What year was your business started?                                                       | 2015       |
		| What is your estimated gross annual revenue?                                               | $2,800,000 |
		| Do you use a written contract or statement of work (SOW)?                                  | Sometimes  |
		| Who signs off on the terms & conditions for written contracts or statements of work (SOW)? | In House   |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer     |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes        |
		| Does your current policy have a retroactive date?                                      | Yes        |
		| What is the retroactive date?                                                          | 11/01/2010 |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0          |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer                  |
		| Do you place clients' funds in any options or leveraged ETFs?                                                                                                                                                                                          | No                      |
		| Do you offer any products that guarantee a minimum return on investment?                                                                                                                                                                               | Yes                     |
		| Which products that have a guarantee return do you offer?                                                                                                                                                                                              | Fixed Indexed Annuities |
		| Do you place clients' funds in any cryptocurrency?                                                                                                                                                                                                     | No                      |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                      |
	Then user fills out About You page with these values:
		| Question       | Answer                   |
		| First Name     | TEST PL API              |
		| Last Name      | TEST CASE 22             |
		| Address        | 25 E Franklin St         |
		| Apt/Suite      |                          |
		| City           | Braceville               |
		| Email          | ironboundtaxes@gmail.com |
		| Business Phone | 1231231321               |
		| Website/Social | TestPartnerCert.com      |
		| Ext            | 1234                     |
	Then user verifies the PL decline page appearance