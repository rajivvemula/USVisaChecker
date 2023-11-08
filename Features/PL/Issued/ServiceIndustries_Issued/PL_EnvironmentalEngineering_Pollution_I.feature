Feature: PL_EnviromentalEngineering_I

US 71963 - PL Plus Yearly policy with Pollution coverage issued in Illinois
@Regression @PL @Service @IL @Issued
Scenario: PL Enviromental Engineering with pollution coverage issued in Illinois
	Given user starts a quote with:
		| Industry                  | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Environmental Engineering | 7         | I Lease a Space From Others |              | 62701    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | DBA |
		| Corporation        | Test             | No  |
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
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you do work involving aerospace engineering?                                                                                                                                                                                                        | No     |
		| Do you advise on Geotechnical, Soils, or Structural Engineering?                                                                                                                                                                                       | No     |
		| Do you give advice on nuclear materials?                                                                                                                                                                                                               | No     |
		| Do you design any weapons?                                                                                                                                                                                                                             | No     |
		| Do you directly perform physical work for others?                                                                                                                                                                                                      | No     |
		| Do client deliverables undergo a peer review?                                                                                                                                                                                                          | Always |
		| Do you advise on the contamination risk, presence of, or clean up of any pollutants?                                                                                                                                                                   | Yes    |
		| Do you offer asbestos evaluation or abatement services?                                                                                                                                                                                                | No     |
		| Do you provide emergency response services?                                                                                                                                                                                                            | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question               | Answer             |
		| First Name             | Teddy              |
		| Last Name              | Treebark           |
		| Address                | 401 S. 2nd St      |
		| Apt/Suite              |                    |
		| City                   | Springfield        |
		| Use as Mailing Address | Yes                |
		| Email                  | accountant@biz.com |
		| Business Phone         | 9198857474         |
		| Ext                    |                    |
		| Website/Social         |                    |
		| Have Broker            | No                 |
	Then user verifies the appearance of the PL Summary page
	Then user selects their Yearly - Plus Quote
	Then user verifies the PL purchase page appearance
	When user fills out the PL purchase page with these values:
		| Field          | Value               |
		| Autopay        | On                  |
		| CC Name        | TestF TestL         |
		| CC Number      | 4111 1111 1111 1111 |
		| CC Expiration  | 03/30               |
		| Street Address | 100 Test Road       |
		| ZIP Code       | 17404               |
		| City           | York                |
		| Phone          | 1231231321          |
		| Extension      |                     |
	Then user verifies the PL how would you rate our service? page appearance
	Then user verifies the PL thank you page appearance
	And user verifies that the following LOBs are recommended: WC, BP