Feature: WC_BreedingFarmHorse_R

Referred for operating stables at race tracks

@WC @Landscaping @Referred @Cali @Yourservices @Regression 
Scenario: WC Breeding Farm: Horse referred for operating stables at race tracks
	Given user starts a quote with:
		| Industry             | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Breeding Farm: Horse | 10        | I Lease a Space From Others |              | 95503    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                   |
		| When do you want your policy to start?                                                 |                          |
		| When did you start your business?                                                      | Started 2 years ago      |
		| How is your business structured?                                                       | Corporation              |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 40000                    |
		| Do any employees only do general office work and rarely travel?                        | no                       |
		| Is housing provided for any of the workers?                                            | no                       |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                       |
		| Business                                                                               | Race Track Referral      |
		| Address                                                                                | 455 Freshwater Rd;Eureka |
		| Contact First Name                                                                     | TestF                    |
		| Contact Last Name                                                                      | TestL                    |
		| Email                                                                                  | Test@Test123.com         |
		| Phone                                                                                  | 1231231321               |
		| Business website                                                                       | test.com                 |
	And user verifies the Wage Calculator page
	And user clicks continue from the Wage Calculator
	And user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                       | Answer |
		| How many owners/officers does your business have?                              | 2      |
		| How many owners/officers do you want to cover with this policy?                | 2      |
		| Do any included owners/officers only do general office work and rarely travel? | No     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| Do you have any grain elevators or silos on site?                         | no     |
		| Do you provide any farm labor contractor services?                        | no     |
		| Do you operate any stables at race tracks?                                | yes    |
		| How many horse stalls are occupied per year?                              | 5      |
		| Do you pay any jockeys on a per race basis?                               | yes    |
		| How many races do you do per year?                                        | 15     |
		| Do you ever transport six or more workers in the same vehicle?            | no     |
		| Do you deliver any sold livestock or harvested crops?                     | no     |
		| Do you engage in any show jumping training or hunting activities?         | no     |
		| Do you do any logging work?                                               | no     |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 1 excluded oo with these values:
		| Set Name     |
		| Link Jehu    |
		| Malon Lonlon |
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                   |
		| Business name      | Race Track Referral     |
		| Contact first name | TestF                   |
		| Contact last name  | TestL                   |
		| Email              | Test@Test123.com        |
		| Phone              | (123) 123-1321          |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the refer thank you page appears