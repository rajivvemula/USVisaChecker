Feature: WC_GreenhouseGrower_D
Ineligible Quote for Keyword: Greenhouse Grower
Reason: Decline due to unacceptable severity exposure from grain entrapment
Answer Yes to grain elevator or silo on site
Yes I have Employee
Number of employee : 20
Business Operation: I Run My Business From Property I Own
ZIP Code: 85321
Included Officer: 3
Business started year : Started 10 years or more ago
Business Structured: Corporation

@WC @Landscaping @Declined @AZ @Regression
Scenario: WC Greenhouse Grower declined due to severity exposure from grain entrapment
	Given user starts a quote with:
		| Industry          | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Greenhouse Grower | 20        | I Run My Business From Property I Own |              | 85321    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                       |
		| When do you want your policy to start?                                                 |                              |
		| When did you start your business?                                                      | Started 10 years or more ago |
		| How is your business structured?                                                       | Corporation                  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 950000                       |
		| Do any employees only do general office work and rarely travel?                        | no                           |
		| Is housing provided for any of the workers?                                            | no                           |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                           |
		| Business                                                                               | Greenhouse Grower            |
		| Address                                                                                | 140 W Arroyo Ave;Ajo         |
		| Contact First Name                                                                     | TestF                        |
		| Contact Last Name                                                                      | TestL                        |
		| Email                                                                                  | Test@Test123.com             |
		| Phone                                                                                  | 1231231321                   |
		| Business website                                                                       | test.com                     |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                               | Answer |
		| How many owners/officers does your business have?                                      | 3      |
		| How many owners have less than 50% ownership? State law requires that they be covered. | 1      |
		| How many owners/officers do you want to cover with this policy?                        | 3      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | % Ownership | W2 payroll | Annual Payroll | Job Duty              |
		| OneF       | OneL      | yes         | yes        | 50000          | General Office Worker |
		| TwoF       | TwoL      | no          | yes        | 51000          | General Office Worker |
		| ThreeF     | ThreeL    | no          | yes        | 52000          | General Office Worker |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                   | Answer     |
		| Do you have any grain elevators or silos on site?                          | yes        |
		| Do you grow any fruit tree or nut tree crops?                              | no         |
		| Do you provide any farm labor contractor services?                         | no         |
		| Do you deliver any sold livestock or harvested crops?                      | no         |
		| Do you ever transport six or more workers in the same vehicle?             | no         |
		| Do you do any logging work?                                                | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?   | None       |
		| Do you currently have a Workers' Compensation insurance policy in effect?  | yes        |
		| Do you have multiple locations in more than one state?                     | no         |
		| Federal Employer Identification Number (FEIN)                              | 23-1234567 |
		| Do you ever transport six or more workers in the same vehicle?             | no         |
	Then user verifies the WC decline page appearance