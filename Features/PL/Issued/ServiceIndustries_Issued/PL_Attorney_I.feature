﻿Feature: PL_Attorney_I

Attorney with a title agency purchse.

@PL @Staging @Regression @Service @Issued
Scenario: PL Attorney Only Title Agent issued policy in PA
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Attorney | 7         | I Lease a Space From Others |              | 17404    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business                | Business Address | DBA      |
		| Partnership        | Test LPL Quote Only Title Agent | 1060 Church Rd   | TLPLQOTA |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                       | Answer |
		| What year was your business started?                           | 2020   |
		| How many attorneys does your firm have?                        | 6      |
		| Do you use any of counsel or independent contractor attorneys? | No     |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer     |
		| When should your policy start?                                                         |            |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes        |
		| Does your current policy have a retroactive date?                                      | Yes        |
		| What is the retroactive date?                                                          | 01/01/2022 |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0          |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer      |
		| Has your business, or any of its owners/officers been convicted of a felony in the past 5 years?                                                                                                                                                       | No          |
		| Has your business, or any of its owners/officers declared bankruptcy in the past 3 years?                                                                                                                                                              | No          |
		| Do you practice in these areas of law?                                                                                                                                                                                                                 | Real Estate |
		| Does your business own a Title Agency?                                                                                                                                                                                                                 | Yes         |
		| Do you practice in Securities Law (financial transactions)?                                                                                                                                                                                            | No          |
		| Have any members of your firm been suspended or disbarred in the past 5 years?                                                                                                                                                                         | No          |
		| Have any members of your firm engaged in mass tort or class action cases in the past 5 years?                                                                                                                                                          | No          |
		| Would you ever serve as a trustee or executor?                                                                                                                                                                                                         | No          |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No          |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer          |
		| First Name             | TestF           |
		| Last Name              | TestL           |
		| Address                | 100 Test Road   |
		| Apt/Suite              |                 |
		| City                   | York            |
		| Use as Mailing Address | Yes             |
		| Email                  | Test@biBERK.com |
		| Business Phone         | 1231231321      |
		| Ext                    | 1234            |
		| Website/Social         |                 |
		| Have Broker            | No              |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the appearance of the PL Attorneys - Almost Done page with these values:
		| Question     | Answer            |
		| Title Agency | Test Title Agency |
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | Off                 |
		| CC Name        | Off The Hook Calls  |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 07/24               |
		| Street Address | 20112 US441         |
		| ZIP Code       | 32643               |
		| City           | High Springs        |
		| Phone          | 7777777777          |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: WC, BP