Feature: PL_Lawyer_I


@Regression @PL @Service @Issued @IL
Scenario: PL Lawyer issued policy in IL
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Lawyer   | 2         | I Lease a Space From Others |              | 60606    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address | DBA |
		| Corporation        | Lawyers R Us     | 15872 Co Rd 29   | LRU |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                         | Answer |
		| What year was your business started?                             | 2000   |
		| How many attorneys does your firm have?                          | 1      |
		| Do you use any of counsel or independent contractor attorneys?   | Yes    |
		| Number of full-time of counsel/independent contractor attorneys: | 2      |
		| Number of part-time of counsel/independent contractor attorneys: | 2      |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer |
		| When should your policy start?                                                         |        |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes    |
		| Does your current policy have a retroactive date?                                      | Yes    |
		| What is the retroactive date?                                                          |        |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0      |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer                                                                       |
		| Has your business, or any of its owners/officers been convicted of a felony in the past 5 years?                                                                                                                                                       | No                                                                           |
		| Has your business, or any of its owners/officers declared bankruptcy in the past 3 years?                                                                                                                                                              | No                                                                           |
		| Do you practice in these areas of law?                                                                                                                                                                                                                 | Intellectual Property (copyright/patent/trademark);Environmental;Real Estate |
		| Do you file patents on behalf of clients?                                                                                                                                                                                                              | No                                                                           |
		| Does your business own a Title Agency?                                                                                                                                                                                                                 | Yes                                                                          |
		| Do you practice in Securities Law (financial transactions)?                                                                                                                                                                                            | No                                                                           |
		| Have any members of your firm been suspended or disbarred in the past 5 years?                                                                                                                                                                         | No                                                                           |
		| Have any members of your firm engaged in mass tort or class action cases in the past 5 years?                                                                                                                                                          | No                                                                           |
		| Would you ever serve as a trustee or executor?                                                                                                                                                                                                         | No                                                                           |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                                                                           |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer         |
		| First Name             | Teddy          |
		| Last Name              | Treebark       |
		| Address                | 123 Fake St    |
		| Apt/Suite              | 23             |
		| City                   | Haymarket      |
		| Use as Mailing Address | Yes            |
		| Email                  | test@biz.com   |
		| Business Phone         | 4321234423     |
		| Ext                    | 3123           |
		| Website/Social         | www.test.com   |
		| Have Broker            | Yes            |
		| Manager First Name     | Yum            |
		| Manager Last Name      | Yo             |
		| Manager Phone Number   | (909) 565-9999 |
		| Manager Phone Ext      | 778            |
		| Manager Email          | dfgfdg@ff.lol  |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the appearance of the PL Attorneys - Almost Done page with these values:
		| Question     | Answer                |
		| Attorney     | D'Andre Hopkins-Ceely |
		| FT           | Paula Abdul           |
		| FT           | The Grinch            |
		| PT           | Thebees Knees         |
		| PT           | Laura Lu              |
		| Title Agency | Titles Are Cool       |
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value                 |
		| Autopay        | On                    |
		| CC Name        | Little Mac            |
		| CC Number      | 4111 1111 1111 1111   |
		| CC Expiration  | 07/25                 |
		| Street Address | 1101 Fort Street Mall |
		| ZIP Code       | 96813                 |
		| City           | Honolulu              |
		| Phone          | 777-777-7777          |
		| Extension      |                       |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: GL,CA,WC