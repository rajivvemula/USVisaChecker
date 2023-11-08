Feature: PL_Accountant_I

@Regression @PL @Service 
Scenario: PL Accountant issued policy in IL
	Given user starts a quote with:
		| Industry   | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Accountant | 2         | I Lease a Space From Others |              | 60606    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business  | Business Address | DBA |
		| Corporation        | Accountants R Us  | 15872 Co Rd 29   | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                   | Answer  |
		| What year was your business started?                                                       | 2000    |
		| What is your estimated gross annual revenue?                                               | 770,770 |
		| Do you use a written contract or statement of work (SOW)?                                  | Always  |
		| Who signs off on the terms & conditions for written contracts or statements of work (SOW)? | Outside |
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
		| Do you provide forensic accounting including litigation support or investigative services?                                                                                                                                                              | No                                  |
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
		| Address                | 225 S Canal St     |
		| Apt/Suite              |                    |
		| City                   | Chicago            |
		| Use as Mailing Address | Yes                |
		| Email                  | accountant@biz.com |
		| Business Phone         | 9198857474         |
		| Ext                    |                    |
		| Website/Social         |                    |
		| Have Broker            | No                 |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Standard Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | On                  |
		| CC Name        | Accountants R Us    |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 07/24               |
		| Street Address | 225 S Canal St      |
		| ZIP Code       | 60606               |
		| City           | Chicago             |
		| Phone          | 9198857474          |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: WC, BP