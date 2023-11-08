Feature: PL_Lawyer_D
Ineligible Quote - LPL UW Question Decline

@PL @Declined @Service @Regression @Staging 
Scenario: PL Lawyer gets Declined
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Lawyer   | 1         | I Lease a Space From Others |              | 68008    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business    | Business Address   | DBA |
		| Partnership        | Decline Our Lawyers | 1735 S Hwy 30 #101 | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                       | Answer |
		| What year was your business started?                           | 2000   |
		| How many attorneys does your firm have?                        | 2      |
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
		| Question                                                                                                                                                                                                                                               | Answer        |
		| Has your business, or any of its owners/officers been convicted of a felony in the past 5 years?                                                                                                                                                       | No            |
		| Has your business, or any of its owners/officers declared bankruptcy in the past 3 years?                                                                                                                                                              | No            |
		| Do you practice in these areas of law?                                                                                                                                                                                                                 | Environmental |
		| Do you practice in Securities Law (financial transactions)?                                                                                                                                                                                            | Yes           |
		| Have any members of your firm been suspended or disbarred in the past 5 years?                                                                                                                                                                         | No            |
		| Have any members of your firm engaged in mass tort or class action cases in the past 5 years?                                                                                                                                                          | No            |
		| Would you ever serve as a trustee or executor?                                                                                                                                                                                                         | No            |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No            |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question       | Answer         |
		| First Name     | Decline Our    |
		| Last Name      | Lawyers        |
		| Address        | 1454 South St  |
		| City           | Blair          |
		| Email          | lawyer@law.com |
		| Business Phone | (123) 123-1321 |
		| Ext            | 1234           |
		| Have Broker    | No             |
	Then user verifies the PL decline page appearance