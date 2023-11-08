Feature: WC_TaxicabMoreThanOneVehicle_R
Ineligible quote: Refer as exposure base is number of vehicles if not using w-2 payroll for the employee drivers. 
Applies in most states, generally it is around $60k but please check state bureaus before calculating actual remuneration., StateLevel-DirectSalesOK=N. .
Keyword: Taxicab company: more than one vehicle
Employee option: Yes Ihave employee
How many employee: 2
Business Operation: I Lease a Space From Others
How many vehicle:6

@Transportation @WC @Referred @NJ @Regression
Scenario: WC Taxicab Company More Than One Vehicle is referred
	Given user starts a quote with:
		| Industry                               | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Taxicab company: more than one vehicle | 2         | I Lease a Space From Others |              | 19808    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 2 years ago         |
		| How is your business structured?                                                       | Corporation                 |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 80000                       |
		| Do any employees only do general office work and rarely travel?                        | no                          |
		| Business                                                                               | Taxicab company             |
		| Address                                                                                | 2106 Walmsley Dr;Wilmington |
		| Contact First Name                                                                     | TestF                       |
		| Contact Last Name                                                                      | TestL                       |
		| Email                                                                                  | Test@Test123.com            |
		| Phone                                                                                  | 1231231321                  |
		| Business website                                                                       | test.com                    |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                       | Answer |
		| How many owners/officers does your business have?                              | 2      |
		| How many owners/officers do you want to cover with this policy?                | 2      |
		| Do any included owners/officers only do general office work and rarely travel? | No     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                           | Answer |
		| How many vehicles do you own that are operated by employees?                                                       | 6      |
		| Do you lease or rent out any vehicles to any non-employees?                                                        | no     |
		| In the past 3 years how many Workers' Compensation claims were reported?                                           | None   |
		| Do you pay any drivers via 1099 that use their own vehicle?                                                        | no     |
		| Do you review MVRs for all employees with a driving exposure?                                                      | No     |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                          | yes    |
		| Do the business owner(s) of this business have a combined majority ownership in any other transportation business? | no     |
		| Do you have multiple locations in more than one state?                                                             | no     |
	Then user begins the WC AI page setting the FEIN with value 63-1212123
	Then wc user handles 2 covered oo
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                   |
		| Business name      | Taxicab company         |
		| Contact first name | TestF                   |
		| Contact last name  | TestL                   |
		| Email              | Test@Test123.com        |
		| Phone              | (123) 123-1321          |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the refer thank you page appears