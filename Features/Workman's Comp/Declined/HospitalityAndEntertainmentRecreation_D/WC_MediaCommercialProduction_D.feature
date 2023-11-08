Feature: WC_MediaCommercialProduction_D
Ineligible quote for Keyword: Media Commercial Production
Reason: Heavy exposure from vehicular accidents
Employee option: Various employees - 12
ZIP Code: 35223 
Employee Payroll: 850,000
Entity type: Sub-Chapter Corp
Years in business: Started 10 or more years ago
Included owner officers: 2
Excluded owner officer: 1
EL Limits: 1,000,000/1,000,000/1,000,000
Payment Option: 15% Down + 9 Monthly Installments

@Hospitality @WC @Declined @AL @Regression
Scenario: WC Media Production gets declined because answer Yes to film stunts or chase scenes
	Given user starts a quote with:
		| Industry                    | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Media Commercial Production | 12        | I Own a Property & Lease to Others |              | 35223    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                       |
		| When do you want your policy to start?                                                 |                              |
		| When did you start your business?                                                      | Started 10 years or more ago |
		| How is your business structured?                                                       | Sub-Chapter Corp             |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 850,000                      |
		| Do you make any payments to workers using IRS Form 1099?                               | no                           |
		| Business                                                                               | AL Media                     |
		| Address                                                                                | 2610 Aberdeen Rd;Birmingham  |
		| Fill Contact                                                                           |                              |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 3      |
		| How many owners/officers do you want to cover with this policy? | 2      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll |
		| TestF      | TestL     | yes        | 50000          |
		| TesttFF    | TestLL    | yes        | 55000          |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| First      | Exluded   |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                        | Answer     |
		| Do you use pyrotechnics?                                                        | no         |
		| Do you film choreographed fight scenes?                                         | no         |
		| Do you perform acts with knives, other sharp objects, fire, or live ammunition? | no         |
		| Do you film car, motorcycle, or ATV stunts or chase scenes?                     | yes        |
		| In the past 3 years how many Workers' Compensation claims were reported?        | None       |
		| Do you currently have a Workers' Compensation insurance policy in effect?       | yes        |
		| Do you use any volunteers or donated labor?                                     | no         |
		| Do you have multiple locations in more than one state?                          | no         |
		| Federal Employer Identification Number (FEIN)                                   | 23-2671064 |
	Then user verifies the WC decline page appearance
