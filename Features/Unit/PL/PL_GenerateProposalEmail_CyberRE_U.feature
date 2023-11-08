Feature: PL_GenerateProposalEmail_CyberRE_U

User Story 81898: Staging Regression | Create Test Case | PL | Generate Proposal Email | Cyber + Real Estate

@Cyber @RealEstate @Issued @Regression @PL @Service @Staging @PA
Scenario: PL Generate Proposal Email Cyber Real Estate issued
	Given user starts a quote with:
		| Industry          | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Real Estate Agent | 3         | I Lease a Space From Others |              | 17404    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business              | Business Address | DBA             | LLC |
		| Partnership        | Test PL Cyber and Real Estate | 1060 Church Rd   | Test LLC in DBA | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                   | Answer  |
		| What year was your business started?                                                       | 2020    |
		| What is your estimated gross annual revenue?                                               | 400,000 |
		| Do you use a written contract or statement of work (SOW)?                                  | Always  |
		| Who signs off on the terms & conditions for written contracts or statements of work (SOW)? | Outside |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer       |
		| When should your policy start?                                                         |              |
		| Do you currently have an Errors & Omissions policy in effect?                          | Yes          |
		| Does your current policy have a retroactive date?                                      | I Don't Know |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0            |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you collect private data?                                                                                                                                                                                                                           | No     |
		| What percentage of revenue comes from sales of commercial properties or vacant land?                                                                                                                                                                   | 1%-49% |
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
		| Business Phone         | (123)123-1321   |
		| Ext                    | 1234            |
		| Website/Social         |                 |
	Then user verifies the appearance of the PL Summary page
	Then user verifies the following defualt PL quote values: Deductible PO, Limits PO, Limits Agg, Plus Deductible PO, Plus Limits PO, Plus Limits Agg, Plus CL Agg
	Then user verifies that the following coverages are displayed in the details of their PL Plus Quote: E&O,Cyber,Real Estate
	Then user adjusts their  -  quote with these values:
		| Question      | Answer     |
		| Deductible PO | $5,000     |
		| Limits PO     | $300,000   |
		| Limits Agg    | $500,000   |
		| Plus CL Agg   | $1,000,000 |
	Then user verifies the PL Email Your Quote modal appears
	Then user selects their Yearly - Plus Quote