Feature: PL_MechanicalEngineeringConsulting_D

Blacklist Declination based on blacklisted phone number or email address
75 Sun Mountain Dr, Monarch, MT 59463

@PL @Declined @Service
Scenario: PL Mechanical Engineering Consulting Declined due to entering a blacklisted phone number into the about you page
	Given user starts a quote with:
		| Industry                          | Employees | Location                    | Own or Lease                                             | ZIP Code | LOB |
		| Mechanical Engineering Consulting | 7         | I Lease a Space From Others | Vehicles;Furniture;Inventory or Stock;Tools or Equipment | 59463    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure       | Name of Business    | Business Address | DBA |
		| Limited Liability Co LLC | Mechincal Engineers | 5012 US-89       | ME  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                   | Answer  |
		| What year was your business started?                                                       | 2019    |
		| What is your estimated gross annual revenue?                                               | 500,000 |
		| Do you use a written contract or statement of work (SOW)?                                  | Always  |
		| Who signs off on the terms & conditions for written contracts or statements of work (SOW)? | Legal   |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| When should your policy start?                                                         |                           |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you do work involving aerospace engineering?                                                                                                                                                                                                        | No     |
		| Do you advise on Geotechnical, Soils, or Structural Engineering?                                                                                                                                                                                       | No     |
		| Do you give advice on nuclear materials?                                                                                                                                                                                                               | No     |
		| Do you design any weapons?                                                                                                                                                                                                                             | No     |
		| Do you directly perform physical work for others?                                                                                                                                                                                                      | No     |
		| Do you design amusement rides or playgrounds?                                                                                                                                                                                                          | No     |
		| Do client deliverables undergo a peer review?                                                                                                                                                                                                          | Always |
		| Do you advise on the contamination risk, presence of, or clean up of any pollutants?                                                                                                                                                                   | No     |
		| Do you offer asbestos evaluation or abatement services?                                                                                                                                                                                                | No     |
		| Do you develop medical diagnostic machines or artificial organs?                                                                                                                                                                                       | No     |
		| Do you provide emergency response services?                                                                                                                                                                                                            | No     |
		| Do you manufacture, sell, or distribute products under your business name?                                                                                                                                                                             | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user fills out About You page with these values:
		| Question               | Answer                        |
		| First Name             | Montgomery                    |
		| Last Name              | Scott                         |
		| Address                | 5012 US-89                    |
		| Apt/Suite              | 1                             |
		| City                   | Monarch                       |
		| Use as Mailing Address | No                            |
		| Mailing Address        | 5012 US-89                    |
		| Mailing Apt/Suite      | 1                             |
		| Mailing ZIP            | 59463                         |
		| Mailing City           | Monarch                       |
		| Email                  | GreatScott@UFoP.net           |
		| Business Phone         | [[BlackListedPhoneNumber]]    |
		| Ext                    | 7777                          |
		| Website/Social         | www.MechanicalEngineering.com |
		| Have Broker            | No                            |
	Then user verifies the PL decline page appearance

@PL @Declined @Service
Scenario: PL_MechanicalEngineeringConsulting_D Declination due to entering a blacklisted email address into the about you page
	Given user starts a quote with:
		| Industry                          | Employees | Location                    | Own or Lease                                             | ZIP Code | LOB |
		| Mechanical Engineering Consulting | 7         | I Lease a Space From Others | Vehicles;Furniture;Inventory or Stock;Tools or Equipment | 59463    | PL  |
	Then user verifies the appearance of the PL A Quick Introduction page
	Then user fills out A Quick Introduction page with these values:
		| Business Structure       | Name of Business    | Business Address    | DBA |
		| Limited Liability Co LLC | Mechincal Engineers | Egg Harbor Township | ME  |
	Then user verifies the appearance of the PL Business Details page
	Then user fills out the PL Business Details page with these values:
		| Question                                                                                   | Answer  |
		| When should your policy start?                                                             |         |
		| What year was your business started?                                                       | 2019    |
		| What is your estimated gross annual revenue?                                               | 500,000 |
		| Do you use a written contract or statement of work (SOW)?                                  | Always  |
		| Who signs off on the terms & conditions for written contracts or statements of work (SOW)? | Legal   |
	Then user verifies the appearance of the PL Coverage Details page
	Then user fills out the PL Coverage Details page with these values:
		| Question                                                                               | Answer                    |
		| Do you currently have a Professional Liability (E&O) policy in effect?                 | Yes                       |
		| Does your current policy have a retroactive date?                                      | No                        |
		| Which option best describes your current professional liability policy?                | This was my first policy. |
		| How many Professional Liability (E&O) claims have you had in the past 3 years, if any? | 0                         |
	Then user fills out the PL Your Services page
		| Question                                                                                                                                                                                                                                               | Answer |
		| Do you do work involving aerospace engineering?                                                                                                                                                                                                        | No     |
		| Do you advise on Geotechnical, Soils, or Structural Engineering?                                                                                                                                                                                       | No     |
		| Do you give advice on nuclear materials?                                                                                                                                                                                                               | No     |
		| Do you design any weapons?                                                                                                                                                                                                                             | No     |
		| Do you directly perform physical work for others?                                                                                                                                                                                                      | No     |
		| Do you design amusement rides or playgrounds?                                                                                                                                                                                                          | No     |
		| Do client deliverables undergo a peer review?                                                                                                                                                                                                          | Always |
		| Do you advise on the contamination risk, presence of, or clean up of any pollutants?                                                                                                                                                                   | No     |
		| Do you offer asbestos evaluation or abatement services?                                                                                                                                                                                                | No     |
		| Do you develop medical diagnostic machines or artificial organs?                                                                                                                                                                                       | No     |
		| Do you provide emergency response services?                                                                                                                                                                                                            | No     |
		| Do you manufacture, sell, or distribute products under your business name?                                                                                                                                                                             | No     |
		| In the past 3 years, has any party threatened or made claims for damages or other legal remedies against you or against any business entity with which you or any other business owner have been associated as owner, principal, officer, or employee? | No     |
	Then user fills out About You page with these values:
		| Question               | Answer                        |
		| First Name             | Montgomery                    |
		| Last Name              | Scott                         |
		| Address                | 75 Sun Mountain Dr            |
		| Apt/Suite              | 1                             |
		| City                   | Monarch                       |
		| Use as Mailing Address | No                            |
		| Mailing Address        | 75 Sun Mountain Dr            |
		| Mailing Apt/Suite      | 1                             |
		| Mailing ZIP            | 59463                         |
		| Mailing City           | Monarch                       |
		| Email                  | [[BlackListedEmail]]          |
		| Business Phone         | 7777777777                    |
		| Ext                    | 7777                          |
		| Website/Social         | www.MechanicalEngineering.com |
		| Have Broker            | No                            |
	Then user verifies the PL decline page appearance