Feature: WC_CarWashSelfService_D
Ineligible quote - response to carrier question;
Prior customer relationship N9WC959936, Previous Customer - In Collections based on  Email.
Keyword: Car Wash: Self Service
Employee Option: Yes I have
Number of employees : 6
Business Operation: I Own a Property & Lease to Others
Included Officer: 1
Business started year : Started 1 years ago
Business Structured: Corporation
Payroll: 400000
Email: ironboundtaxes@gmail.com

@Auto @WC @Declined @KY @Regression
Scenario: WC Car Wash Self Service gets declined due to customer's email listed in collections
	Given user starts a quote with:
		| Industry               | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Car Wash: Self Service | 6         | I Own a Property & Lease to Others | Vehicles     | 40004    | WC  |
	Then user verifies the appearance of the WC About You Page
	And user fills out the WC About You page with these values:
		| Question                                                                               | Answer                           |
		| When do you want your policy to start?                                                 |                                  |
		| When did you start your business?                                                      | Started 5 years ago              |
		| How is your business structured?                                                       | Corporation                      |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40000                            |
		| Do any employees only do clerical office tasks and does not write up repair estimates? | no                               |
		| Business                                                                               | Credit score linked to SSN refer |
		| Address                                                                                | 701 SE 71st St;Bardstown         |
		| Contact First Name                                                                     | TestF                            |
		| Contact Last Name                                                                      | TestL                            |
		| Email                                                                                  | ironboundtaxes@gmail.com         |
		| Phone                                                                                  | 1231233212                       |
	And user verifies the Wage Calculator page
	And user clicks continue from the Wage Calculator
	Then user verifies the appearance of the WC Owners and Officers Page
	And user handles the WC OO kickoff questions with these values:
		| Question                                                                                       | Answer  |
		| How many owners/officers does your business have?                                              | 1       |
		| How many owners/officers do you want to cover with this policy?                                | 1       |
		| Do any included owners/officers only do general office work never writing up repair estimates? | Yes - 1 |
	Then user continues on from the WC OO page
	And user fills out the WC Your Services page
		| Question                                                                                 | Answer    |
		| Do you provide towing or roadside assistance?                                            | No        |
		| Do you engage in the repossession of vehicles?                                           | no        |
		| In the past 3 years how many Workers' Compensation claims were reported?                 | None      |
		| Do you sell or service large commercial vehicles, motorcycles, or recreational vehicles? | no        |
		| Do you currently have a Workers' Compensation insurance policy in effect?                | yes       |
		| Do you have multiple locations in more than one state?                                   | no        |
		| Social Security Number (SSN)                                                             | 832803691 |
	Then user verifies the WC decline page appearance