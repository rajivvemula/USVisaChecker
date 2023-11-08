Feature: PL_LawFirm_R

Referral due to full prior acts coverage being indicated as a Law Firm

@PL @Referred @Service @Regression @Staging
Scenario: PL Law Firm Full Prior Acts Coverage referred
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Law Firm | 1         | I Lease a Space From Others |              | 18702    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business     | Business Address | DBA |
		| Sub-Chapter Corp   | Full Prior Acts Firm | 91 Parrish St    | FPA |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                       | Answer |
		| What year was your business started?                           | 2020   |
		| How many attorneys does your firm have?                        | 6      |
		| Do you use any of counsel or independent contractor attorneys? | No     |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer                  |
		| Has your business, or any of its owners/officers been convicted of a felony in the past 5 years?                                                                                                                                                       | No                      |
		| Has your business, or any of its owners/officers declared bankruptcy in the past 3 years?                                                                                                                                                              | No                      |
		| Do you practice in these areas of law?                                                                                                                                                                                                                 | Corporate;Environmental |
		| Do you help handle Mergers & Acquisitions?                                                                                                                                                                                                             | Yes                     |
		| Do you practice in Securities Law (financial transactions)?                                                                                                                                                                                            | No                      |
		| Have any members of your firm been suspended or disbarred in the past 5 years?                                                                                                                                                                         | No                      |
		| Have any members of your firm engaged in mass tort or class action cases in the past 5 years?                                                                                                                                                          | No                      |
		| Would you ever serve as a trustee or executor?                                                                                                                                                                                                         | No                      |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                      |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question       | Answer              |
		| First Name     | TEST PL API CASE 15 |
		| Last Name      | TEST PL API         |
		| Address        | 100 N Main St       |
		| City           | Wilkes-Barre        |
		| Email          | TestCert@Plan.com   |
		| Business Phone | (123) 123-1321      |
		| Ext            | 1234                |
		| Website/Social | TestPartnerCert.com |
		| Have Broker    | No                  |
	When user fills out the PL refer page with these values:
		| Field              | Value                |
		| Business name      | Full Prior Acts Firm |
		| Contact first name | TEST PL API CASE 15  |
		| Contact last name  | TEST PL API          |
		| Email              | TestCert@Plan.com    |
		| Phone              | (123) 123-1321       |
		| Ext                | 1234                 |
		| Business website   | TestPartnerCert.com  |
	Then user verifies the PL refer confirmation appearance