Feature: WC_Ridesharing_R

Reason for referral: answered yes to "Do you lease or rent out any vehicles to any non-employees?"

@Referred @Regression @NJ @WC @Transportation
Scenario: WC Ridesharing gets referred due to renting vehicles to any non-employees
	Given user starts a quote with:
		| Industry    | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Ridesharing | 2         | I Run My Business From Property I Own | Vehicles     | 08046    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                       |
		| When do you want your policy to start?                                                 |                              |
		| When did you start your business?                                                      | Started 10 years or more ago |
		| How is your business structured?                                                       | Corporation                  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 50000                        |
		| Do any employees do any maintenance, repair, or service on motor vehicles?             | no                           |
		| Do any employees only do general office work and rarely travel?                        | no                           |
		| Business                                                                               | RideSharing                  |
		| Address                                                                                | 77 Evergreen Dr;Willingboro  |
		| Contact First Name                                                                     | TestF                        |
		| Contact Last Name                                                                      | TestL                        |
		| Email                                                                                  | Test@Test123.com             |
		| Phone                                                                                  | 1231233212                   |
		| Business website                                                                       | test.com                     |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                          | Answer |
		| How many owners/officers does your business have? | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 Payroll | Annual Payroll | Job Duty           |
		| OneF       | OneL      | yes        | 50000          | Driver or Mechanic |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                           | Answer                               |
		| How many vehicles do you own that are operated by employees?                                                       | 1                                    |
		| Do you lease or rent out any vehicles to any non-employees?                                                        | yes                                  |
		| How many vehicles do you lease or rent out to non-employees?                                                       | 1                                    |
		| In the past 3 years how many Workers' Compensation claims were reported?                                           | None                                 |
		| Do you pay any drivers via 1099 that use their own vehicle?                                                        | no                                   |
		| Do you review MVRs for all employees with a driving exposure?                                                      | Yes at the time of hire and annually |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                          | yes                                  |
		| Do the business owner(s) of this business have a combined majority ownership in any other transportation business? | no                                   |
		| Do you have multiple locations in more than one state?                                                             | no                                   |
	Then user begins the WC AI page setting the FEIN with value 23-1516789
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                   |
		| Business name      | RideSharing             |
		| Contact first name | TestF                   |
		| Contact last name  | TestL                   |
		| Email              | Test@Test123.com        |
		| Phone              | 1231233212              |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the refer thank you page appears