Feature: PL_RealEstateAgent_R

Real Estate Agent Referral via the "This policy is specifically for real estate agent/brokerage services (E&O) and does not cover bodily injury or property damage claims arising from properties you manage." question
134 David Ln, Somerset, PA 15501

@PL @Referred @Service @Regression
Scenario:PL Real Estate Agent Referred
	Given user starts a quote with:
		| Industry          | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Real Estate Agent | 2         | I Lease a Space From Others |              | 15501    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure       | Name of Business       | Business Address | DBA  |
		| Limited Liability Co LLC | Real Cheap Real Estate | 258 Beacon St    | RCRE |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                   | Answer  |
		| What year was your business started?                                                       | 2019    |
		| What is your estimated gross annual revenue?                                               | 500,000 |
		| Do you use a written contract or statement of work (SOW)?                                  | Always  |
		| Who signs off on the terms & conditions for written contracts or statements of work (SOW)? | Legal   |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                     | Answer                    |
		| When should your policy start?                                               |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?       | Yes                       |
		| Does your current policy have a retroactive date?                            | No                        |
		| Which option best describes your current Errors & Omissions policy?          | This was my first policy. |
		| How many Errors & Omissions claims have you had in the past 3 years, if any? | 0                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer                                                |
		| Do you collect private data?                                                                                                                                                                                                                           | No                                                    |
		| What percentage of revenue comes from sales of commercial properties or vacant land?                                                                                                                                                                   | 0%                                                    |
		| What percentage of revenue comes from short sales?                                                                                                                                                                                                     | 0%                                                    |
		| Does your business own any properties?                                                                                                                                                                                                                 | No                                                    |
		| Does your business manage any properties?                                                                                                                                                                                                              | Yes                                                   |
		| This policy is specifically for real estate agent/brokerage services (E&O) and does not cover bodily injury or property damage claims arising from properties you manage.                                                                              | I want a quote to insure the properties I manage also |
		| Do you provide appraisals?                                                                                                                                                                                                                             | No                                                    |
		| Do you provide any title related services such as closing agent, escrow agent, title abstractor, title agent, or title search?                                                                                                                         | No                                                    |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No                                                    |
	Then user fills out About You page with these values:
		| Question               | Answer             |
		| First Name             | Real               |
		| Last Name              | Estate             |
		| Address                | 4174 Glades Pike   |
		| Apt/Suite              | 1                  |
		| City                   | Somerset           |
		| Use as Mailing Address | No                 |
		| Mailing Address        | 4258 Glades Pike   |
		| Mailing Apt/Suite      | 1                  |
		| Mailing ZIP            | 15501              |
		| Mailing City           | Somerset           |
		| Email                  | RealEstate@biz.com |
		| Business Phone         | 7777777777         |
		| Ext                    | 7777               |
		| Website/Social         | www.RealEstate.com |
	When user fills out the PL refer page with these values:
		| Field              | Value                  |
		| Business name      | Real Cheap Real Estate |
		| DBA                | RCRE                   |
		| Contact first name | Real                   |
		| Contact last name  | Estate                 |
		| Email              | RealEstate@biz.com     |
		| Phone              | (777) 777-7777         |
		| Ext                | 7777                   |
		| Business website   | www.RealEstate.com     |
	Then user verifies the PL refer confirmation appearance