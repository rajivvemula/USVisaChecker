Feature: PL_LawyerPolicy_I

@PL @Service @Regression @Issued @HI
Scenario: PL Lawyer Policy issued in HI
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Lawyer   | 2         | I Lease a Space From Others |              | 96815    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address  | DBA |
		| Corporation        | Lawyers R Us     | 2365 Kalākaua Ave | LRU |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                         | Answer |
		| What year was your business started?                             | 2000   |
		| How many attorneys does your firm have?                          | 3      |
		| Do you use any of counsel or independent contractor attorneys?   | Yes    |
		| Number of full-time of counsel/independent contractor attorneys: | 2      |
		| Number of part-time of counsel/independent contractor attorneys: | 1      |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer     |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes        |
		| Does your current policy have a retroactive date?                                      | Yes        |
		| What is the retroactive date?                                                          | 06/17/2022 |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0          |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer                                                           |
		| Has your business, or any of its owners/officers been convicted of a felony in the past 5 years?                                                                                                                                                       | No                                                               |
		| Has your business, or any of its owners/officers declared bankruptcy in the past 3 years?                                                                                                                                                              | No                                                               |
		| Do you practice in these areas of law?                                                                                                                                                                                                                 | Intellectual Property (copyright/patent/trademark);Environmental |
		| Do you file patents on behalf of clients?                                                                                                                                                                                                              | No                                                               |
		| Do you practice in Securities Law (financial transactions)?                                                                                                                                                                                            | No                                                               |
		| Have any members of your firm been suspended or disbarred in the past 5 years?                                                                                                                                                                         | No                                                               |
		| Have any members of your firm engaged in mass tort or class action cases in the past 5 years?                                                                                                                                                          | No                                                               |
		| Would you ever serve as a trustee or executor?                                                                                                                                                                                                         | No                                                               |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                                                               |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question       | Answer            |
		| First Name     | TEST LAWYER FIRST |
		| Last Name      | TEST LAWYER LAST  |
		| Address        | 2365 Kalākaua Ave |
		| Apt/Suite      |                   |
		| City           | Honolulu          |
		| Email          | Lawer@gmail.com   |
		| Business Phone | 1231231321        |
		| Ext            | 1234              |
		| Website/Social | TestLawyer.com    |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value                              |
		| Autopay        | On                                 |
		| CC Name        | TEST LAWYER FIRST TEST LAWYER LAST |
		| CC Number      | 4111 1111 1111 1111                |
		| CC Expiration  | 03/30                              |
		| Street Address | 2365 Kalākaua Ave                  |
		| ZIP Code       | 96815                              |
		| City           | Honolulu                           |
		| Phone          | 1231231321                         |
		| Extension      | 1234                               |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: WC