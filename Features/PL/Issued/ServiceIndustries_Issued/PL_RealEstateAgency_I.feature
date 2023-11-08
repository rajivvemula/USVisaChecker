Feature: PL_RealEstateAgency_I

Verifying the details of the your quote page

@Issued @PL @Regression @Service @PA
Scenario: PL Real Estate Agency verify Your Quote Page
	Given user starts a quote with:
		| Industry           | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Real Estate Agency | 0         | I Lease a Space From Others |              | 17404    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure         | Business Address | DBA                  |
		| Individual/Sole Proprietor | 1060 Church Rd   | Test E&O Multi Limit |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                   | Answer  |
		| What year was your business started?                                                       | 2020    |
		| What is your estimated gross annual revenue?                                               | 3       |
		| Do you use a written contract or statement of work (SOW)?                                  | Always  |
		| Who signs off on the terms & conditions for written contracts or statements of work (SOW)? | Outside |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer       |
		| When should your policy start?                                                         |              |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes          |
		| Does your current policy have a retroactive date?                                      | I Don't Know |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0            |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you collect private data?                                                                                                                                                                                                                           | No     |
		| What percentage of revenue comes from sales of commercial properties or vacant land?                                                                                                                                                                   | 0%     |
		| What percentage of revenue comes from short sales?                                                                                                                                                                                                     | 0%     |
		| Does your business own any properties?                                                                                                                                                                                                                 | No     |
		| Does your business manage any properties?                                                                                                                                                                                                              | No     |
		| Do you provide appraisals?                                                                                                                                                                                                                             | No     |
		| Do you provide any title related services such as closing agent, escrow agent, title abstractor, title agent, or title search?                                                                                                                         | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
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
	Then user verifies the appearance of the PL Summary page
	Then user verifies the following defualt PL quote values: Deductible PO, Limits PO, Limits Agg, Plus Deductible PO, Plus Limits PO, Plus Limits Agg, Plus CL Agg
	Then user verifies that the following coverages are displayed in the details of their PL Plus Quote: E&O,Cyber,Real Estate
	Then user adjusts their Yearly - Standard quote with these values:
		| Question           | Answer     |
		| Deductible PO      | $2,500     |
		| Limits PO          | $1,000,000 |
		| Limits Agg         | $1,000,000 |
		| Plus Deductible PO | $2,500     |
		| Plus Limits PO     | $1,000,000 |
		| Plus Limits Agg    | $1,000,000 |
		| Plus CL Agg        | $250,000   |
	Then user selects their Yearly - Standard Quote
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
	And user verifies that the following LOBs are recommended: BOP