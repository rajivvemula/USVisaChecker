Feature: WC_ProfessionalBasketballTeam_D
Ineligible quote for Keyword: Professional Basketball Team
Reason: State MI
Employee option: Various employees - 5
ZIPCode: 48801
Employee Payroll: 500,000
Entity type: Corporation
Years in business: 5 years
Included owner officers: 0

@Hospitality @WC @Declined @MI @Regression
Scenario: WC Professional Basketball Team gets declined due to state being MI
  Given user starts a quote with:
		| Industry                     | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Professional Basketball Team | 5         | I Lease a Space From Others |              | 48801    | WC  |
  Then user verifies the appearance of the WC About You Page
  Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                                |
		| When do you want your policy to start?                                                 |                                       |
		| When did you start your business?                                                      | Started 4 years ago                   |
		| How is your business structured?                                                       | Limited Liability Co. (LLC)           |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 500000                                |
		| Are there any scouts or traveling recruiters on staff?                                 | no                                    |
		| Are there any clerical office staff?                                                   | no                                    |
        | Business                                                                               | Basketball team                       |
		| Address                                                                                | 138 Ely St;Alma                       |
		| Contact First Name                                                                     | TestF                                 |
		| Contact Last Name                                                                      | TestL                                 |
		| Email                                                                                  | Test@Test123.com                      |
		| Phone                                                                                  | 1231231321                            |
  Then user verifies the appearance of the WC Owners and Officers Page		
  Then user handles the WC OO kickoff questions with these values:
        | Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
  Then user continues on from the WC OO page
  Then user fills out the WC Your Services page
		| Question                                                        | Answer |
		| Do you have multiple locations in more than one state?          | no     |
  Then user verifies the WC decline page appearance