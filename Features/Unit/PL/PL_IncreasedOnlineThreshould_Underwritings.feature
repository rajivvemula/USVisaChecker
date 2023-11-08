Feature: PL_IncreasedOnlineThreshould_Underwritings

Verify the increased Online threshold for Underwritings for PL - US110277
PL -> Premium increased from $25000 to $30000
PL -> Revenue increased from $6 million to $7.5 million

@Regression @PL @Referred @PA
Scenario: PL Quote gets Referred when premium is more than $30000
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Attorney | 12        | I Lease a Space From Others |              | 17404    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business                | Business Address | DBA      |
		| Partnership        | Test LPL Quote Only Title Agent | 1060 Church Rd   | TLPLQOTA |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                         | Answer |
		| What year was your business started?                             | 2020   |
		| How many attorneys does your firm have?                          | 12     |
		| Do you use any of counsel or independent contractor attorneys?   | Yes    |
		| Number of full-time of counsel/independent contractor attorneys: | 8      |
		| Number of part-time of counsel/independent contractor attorneys: | 0      |
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
		| Do you want to save up to 35% with a soft credit check?                                                                                                                                                                                                | No          |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer            |
		| First Name             | TestF             |
		| Last Name              | TestL             |
		| Address                | 60 Lincoln Street |
		| Apt/Suite              |                   |
		| City                   | York              |
		| Use as Mailing Address | Yes               |
		| Email                  | Test@biBERK.com   |
		| Business Phone         | 1231231321        |
		| Ext                    | 1234              |
		| Website/Social         |                   |
		| Have Broker            | No                |
	Then user verifies the appearance of the PL Attorneys - Nearly Finished page with these values:
		| Question     | Answer            |
		| Title Agency | Test Title Agency |
	When user fills out the PL refer page with these values:
		| Field              | Value             |
		| Business name      | Whitestone Titles |
		| DBA                | ROL               |
		| Contact first name | Marty             |
		| Contact last name  | Mailbox           |
		| Email              | test@biz.com      |
		| Phone              | (317) 249-1913    |
	Then user verifies the PL refer confirmation appearance

@Regression @PL @Issued @OK
Scenario: PL Quote gets Issued when premium is more than $25000 and less than $30000
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Lawyer   | 10        | I Lease a Space From Others |              | 74110    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address | DBA |
		| Corporation        | Lawyers R Us     | 15872 Co Rd 29   | LRU |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                         | Answer |
		| What year was your business started?                             | 2000   |
		| How many attorneys does your firm have?                          | 10     |
		| Do you use any of counsel or independent contractor attorneys?   | Yes    |
		| Number of full-time of counsel/independent contractor attorneys: | 5      |
		| Number of part-time of counsel/independent contractor attorneys: | 0      |
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
		| Do you want to save up to 35% with a soft credit check?                                                                                                                                                                                                | No                                                                           |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer             |
		| First Name             | Teddy              |
		| Last Name              | Treebark           |
		| Address                | 4123 S Harvard Ave |
		| Apt/Suite              |                    |
		| City                   | Tulsa              |
		| Use as Mailing Address | Yes                |
		| Email                  | test@biz.com       |
		| Business Phone         | 4321234423         |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the appearance of the PL Attorneys - Almost Done page with these values:
		| Question     | Answer            |
		| Title Agency | Test Title Agency |
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | On                  |
		| CC Name        | TestF TestL         |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 03/30               |
		| Street Address | 4123 S Harvard Ave  |
		| ZIP Code       | 17404               |
		| City           | York                |
		| Phone          | 1231231321          |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance

@Regression @PL @Referred @IL
Scenario: PL Quote gets Referred when Revenue is greater than $7.5 million
	Given user starts a quote with:
		| Industry   | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Accountant | 2         | I Lease a Space From Others |              | 60606    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address | DBA |
		| Corporation        | Accountants R Us | 15872 Co Rd 29   | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                   | Answer   |
		| What year was your business started?                                                       | 2000     |
		| What is your estimated gross annual revenue?                                               | 770,7700 |
		| Do you use a written contract or statement of work (SOW)?                                  | Always   |
		| Who signs off on the terms & conditions for written contracts or statements of work (SOW)? | Outside  |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer     |
		| When should your policy start?                                                         |            |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes        |
		| Does your current policy have a retroactive date?                                      | Yes        |
		| What is the retroactive date?                                                          | 06/24/2022 |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0          |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer                              |
		| Do you provide financial investment advice?                                                                                                                                                                                                            | No                                  |
		| Do you provide forensic accounting including litigation support or investigative services?                                                                                                                                                             | No                                  |
		| Do you provide tax services?                                                                                                                                                                                                                           | Business and Individual – No Estate |
		| Do you serve as a trustee or executor?                                                                                                                                                                                                                 | No                                  |
		| Do you provide business valuations or aid in mergers & acquisitions?                                                                                                                                                                                   | No                                  |
		| Do you help set up tax shelters or Limited Partnerships?                                                                                                                                                                                               | No                                  |
		| Do you perform auditing/attestation services?                                                                                                                                                                                                          | No                                  |
		| Do you do any work that requires licensed engineers?                                                                                                                                                                                                   | No                                  |
		| Do you audit or consult on workplace safety for occupational hazards?                                                                                                                                                                                  | No                                  |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                                  |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer             |
		| First Name             | Teddy              |
		| Last Name              | Treebark           |
		| Address                | 4100 S Ashland Ave |
		| Apt/Suite              |                    |
		| City                   | Chicago            |
		| Use as Mailing Address | Yes                |
		| Email                  | accountant@biz.com |
		| Business Phone         | 9198857474         |
		| Ext                    |                    |
		| Website/Social         |                    |
		| Have Broker            | No                 |
	When user fills out the PL refer page with these values:
		| Field              | Value             |
		| Business name      | Whitestone Titles |
		| DBA                | ROL               |
		| Contact first name | Marty             |
		| Contact last name  | Mailbox           |
		| Email              | test@biz.com      |
		| Phone              | (317) 249-1913    |
	Then user verifies the PL refer confirmation appearance

@Regression @PL @Issued @PA
Scenario: PL Quote gets Issued when Revenue is greater than $6 million and less than $7.5 million
	Given user starts a quote with:
		| Industry     | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Hair Stylist | 0         | I Lease a Space From Others |              | 17404    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure          | Name of Business | Business Address | DBA |
		| Limited Liability Co. (LLC) | Test             | 15872 Co Rd 29   | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                     | Answer    |
		| What year was your business started?         | 2000      |
		| What is your estimated gross annual revenue? | 7,499,999 |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer     |
		| When should your policy start?                                                         |            |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes        |
		| Does your current policy have a retroactive date?                                      | Yes        |
		| What is the retroactive date?                                                          | 06/24/2022 |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0          |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you provide body massage services?                                                                                                                                                                                                                  | No     |
		| Do you provide tattoo services?                                                                                                                                                                                                                        | No     |
		| Do you operate tanning beds?                                                                                                                                                                                                                           | No     |
		| Do you do keratin hair-straightening procedures or brazilian blowouts?                                                                                                                                                                                 | No     |
		| Do you do body piercings?                                                                                                                                                                                                                              | No     |
		| Do you do any body sculpting or cosmetic medical procedures?                                                                                                                                                                                           | No     |
		| Do you provide acupuncture, facial injection, fillers, or laser treatment services?                                                                                                                                                                    | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer                |
		| First Name             | TestF                 |
		| Last Name              | TestL                 |
		| Address                | 60 Lincoln Street     |
		| Apt/Suite              |                       |
		| City                   | York                  |
		| Use as Mailing Address | Yes                   |
		| Email                  | Automation@biBERK.com |
		| Business Phone         | 1231231321            |
		| Ext                    | 1234                  |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Plus Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | On                  |
		| CC Name        | TestF TestL         |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 03/30               |
		| Street Address | 60 Lincoln Street   |
		| ZIP Code       | 17404               |
		| City           | York                |
		| Phone          | 1231231321          |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: WC, BP

@Regression @PL @Issued @PA
Scenario: PL Quote gets Issued when Revenue is equal to $7.5 million
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Etailer  | 0         | I Lease a Space From Others |              | 17404    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure         | Insured First Name | Insured Last Name | Business Address | DBA                         |
		| Individual/Sole Proprietor | TestF              | TestL             | 1060 Church Rd   | Test PL Quote Double Bundle |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                   | Answer    |
		| What year was your business started?                                                       | 2020      |
		| What is your estimated gross annual revenue?                                               | 7,500,000 |
		| Do you use a written contract or statement of work (SOW)?                                  | Always    |
		| Who signs off on the terms & conditions for written contracts or statements of work (SOW)? | Outside   |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer       |
		| When should your policy start?                                                         |              |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes          |
		| Does your current policy have a retroactive date?                                      | I Don't Know |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0            |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Can users upload content to websites you own or operate?                                                                                                                                                                                               | No     |
		| Do you develop software that provides or assists with medical diagnoses?                                                                                                                                                                               | No     |
		| Do you develop software that aids architects or engineers in product design?                                                                                                                                                                           | No     |
		| Do you electronically store private data?                                                                                                                                                                                                              | No     |
		| Do you design, integrate, or maintain networks for clients?                                                                                                                                                                                            | No     |
		| Do you provide website hosting or domain registration?                                                                                                                                                                                                 | No     |
		| Do you design any hardware?                                                                                                                                                                                                                            | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user fills out About You page with these values:
		| Question               | Answer                |
		| First Name             | TestF                 |
		| Last Name              | TestL                 |
		| Address                | 225 E Princess St     |
		| Apt/Suite              |                       |
		| City                   | York                  |
		| Use as Mailing Address | Yes                   |
		| Email                  | Automation@biBERK.com |
		| Business Phone         | 1231231321            |
		| Ext                    | 1234                  |
	Then user verifies the appearance of the PL Summary page
	Then user verifies that the following coverages are displayed in the details of their PL Plus Quote: PL,Cyber,Copyright Plus
	Then user selects their Yearly - Plus Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | Off                 |
		| CC Name        | TestF TestL         |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 03/30               |
		| Street Address | 225 E Princess St   |
		| ZIP Code       | 17403               |
		| City           | York                |
		| Phone          | 1231231321          |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: BOP