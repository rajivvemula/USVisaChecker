Feature: PL_PublicRelationsAgencies_R
US 80522 [Refactor] General Referral Refactor

@PL @Referred @Service @Regression
Scenario: PL Public Relations Agencies gets referred
	Given user starts a quote with:
		| Industry                  | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Public Relations Agencies | 2         | I Lease a Space From Others |              | 60606    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure | Name of Business | Business Address | DBA |
		| Corporation        | PR Agency        | 15872 Co Rd 29   | No  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                   | Answer   |
		| What year was your business started?                                                       | 2000     |
		| What is your estimated gross annual revenue?                                               | 770,770  |
		| Do you use a written contract or statement of work (SOW)?                                  | Always   |
		| Who signs off on the terms & conditions for written contracts or statements of work (SOW)? | In House |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer   |
		| When should your policy start?                                                         |          |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes      |
		| Does your current policy have a retroactive date?                                      | Yes      |
		| What is the retroactive date?                                                          |          |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0        |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you provide financial investment advice?                                                                                                                                                                                                            | No     |
		| Do you have attorneys on staff that provide legal advice to others?                                                                                                                                                                                    | No     |
		| Do you create advertisements or provide brand advice for your clients?                                                                                                                                                                                 | No     |
		| Do you provide advice or services that require a Certified Public Accountant?                                                                                                                                                                          | No     |
		| Do you provide architectural or engineering advice?                                                                                                                                                                                                    | Yes    |
		| Do you do work involving aerospace engineering?                                                                                                                                                                                                        | No     |
		| Do you advise on Geotechnical, Soils, or Structural Engineering?                                                                                                                                                                                       | No     |
		| Do you give advice on nuclear materials?                                                                                                                                                                                                               | No     |
		| Do you design any weapons?                                                                                                                                                                                                                             | No     |
		| Do you directly perform physical work for others?                                                                                                                                                                                                      | Yes    |
		| Do you design amusement rides or playgrounds?                                                                                                                                                                                                          | No     |
		| Do client deliverables undergo a peer review?                                                                                                                                                                                                          | Always |
		| Do you advise on the contamination risk, presence of, or clean up of any pollutants?                                                                                                                                                                   | No     |
		| Do you provide staffing services?                                                                                                                                                                                                                      | No     |
		| Do you offer asbestos evaluation or abatement services?                                                                                                                                                                                                | No     |
		| Do you develop medical diagnostic machines or artificial organs?                                                                                                                                                                                       | No     |
		| Do you design bridges?                                                                                                                                                                                                                                 | No     |
		| Do you provide emergency response services?                                                                                                                                                                                                            | No     |
		| Do you manufacture, sell, or distribute products under your business name?                                                                                                                                                                             | No     |
		| Do you do Human Resources (HR) consulting or management for clients?                                                                                                                                                                                   | No     |
		| Do you do workplace safety consulting for occupational hazards?                                                                                                                                                                                        | No     |
		| Do you provide health care services or advice that requires a licensed health care professional?                                                                                                                                                       | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user verifies the appearance of the PL About You Page
	Then user fills out About You page with these values:
		| Question       | Answer         |
		| First Name     | Teddy          |
		| Last Name      | Roosevelt      |
		| Address        | 123 Fake St    |
		| City           | Haymarket      |
		| Email          | test@biz.com   |
		| Business Phone | (432) 123-4423 |
		| Have Broker    | No             |
	When user fills out the PL refer page with these values:
		| Field              | Value          |
		| Business name      | PR Agency      |
		| Contact first name | Teddy          |
		| Contact last name  | Roosevelt      |
		| Email              | test@biz.com   |
		| Phone              | (432) 123-4423 |
	Then user verifies the PL refer confirmation appearance