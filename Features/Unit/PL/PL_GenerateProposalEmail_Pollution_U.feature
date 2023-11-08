Feature: PL_GenerateProposalEmail_Pollution_U

User Story 81901: Staging Regression | Create Test Case | PL | Generate Proposal Email | Pollution

@Unit @Regression @PL @Staging @PA
Scenario: PL Generate Proposal Email Pollution
	Given user starts a quote with:
		| Industry                  | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Environmental Engineering | 3         | I Lease a Space From Others |              | 17404    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure          | Name of Business  | Business Address | DBA |
		| Limited Liability Co. (LLC) | Test PL Pollution | 1060 Church Rd   | No  |
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
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes          |
		| Does your current policy have a retroactive date?                                      | I Don't Know |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0            |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you do work involving aerospace engineering?                                                                                                                                                                                                        | No     |
		| Do you advise on Geotechnical, Soils, or Structural Engineering?                                                                                                                                                                                       | No     |
		| Do you give advice on nuclear materials?                                                                                                                                                                                                               | No     |
		| Do you design any weapons?                                                                                                                                                                                                                             | No     |
		| Do you directly perform physical work for others?                                                                                                                                                                                                      | No     |
		| Do client deliverables undergo a peer review?                                                                                                                                                                                                          | Never  |
		| Do you advise on the contamination risk, presence of, or clean up of any pollutants?                                                                                                                                                                   | No     |
		| Do you offer asbestos evaluation or abatement services?                                                                                                                                                                                                | No     |
		| Do you provide emergency response services?                                                                                                                                                                                                            | No     |
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
	Then user adjusts their  -  quote with these values:
		| Question      | Answer     |
		| Deductible PO | $2,500     |
		| Limits PO     | $300,000   |
		| Limits Agg    | $500,000   |
		| Plus PL Agg   | $1,000,000 |
	Then user verifies the PL Email Your Quote modal appears