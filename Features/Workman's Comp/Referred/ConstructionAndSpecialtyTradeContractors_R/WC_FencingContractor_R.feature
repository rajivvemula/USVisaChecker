Feature: WC_FencingContractor_R

Referred due to the average employee wage being too low

@Construction @WC @Referred @NE @Regression
Scenario: WC Fencing Contractor employee gets referred due to wage being too low
	Given user starts a quote with:
		| Industry           | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Fencing Contractor | 25        | I Lease a Space From Others |              | 18706    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                        |
		| When do you want your policy to start?                                                 |                               |
		| When did you start your business?                                                      | Started 6 years ago           |
		| How is your business structured?                                                       | Corporation                   |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 4                             |
		| Are there any employees that never travel to job sites or do any construction work?    | no                            |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                            |
		| Business                                                                               | Fencing Contractor            |
		| Address                                                                                | 44 Betsy Ross Dr;Wilkes Barre |
		| Contact First Name                                                                     | TestF                         |
		| Contact Last Name                                                                      | TestL                         |
		| Email                                                                                  | Test@Test123.com              |
		| Phone                                                                                  | 1231231321                    |
		| Business website                                                                       | test.com                      |
	And user verifies the Wage Calculator page
	Then user fills out the Wage Calculator with these values:
		| Average Employee Wage | Number of Employees | Hours per Week |
		| 10                    | 25                  | 5              |
	And user clicks continue from the Wage Calculator
	And user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                           | Answer |
		| How many owners/officers does your business have?                                                  | 1      |
		| How many owners/officers do you want to cover with this policy?                                    | 1      |
		| Are there any included owners/officers that never travel to job sites or do any construction work? | No     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                                                                   | Answer     |
		| Do you ever transport six or more workers in the same vehicle?                                                                                             | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?                                                                                   | None       |
		| Do you perform any work over 30 feet above ground level?                                                                                                   | no         |
		| Do you do any demolition or wrecking of entire buildings or homes?                                                                                         | no         |
		| Do the business owner(s) of this business have a combined majority ownership in any other construction business?                                           | no         |
		| Do you do any construction work in New York?                                                                                                               | no         |
		| Does any work involve the handling of barbed wire?                                                                                                         | no         |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                                                                  | yes        |
		| Do you agree to submit proof of insurance claims history, also called loss runs, for the prior 3 years within 30 days of the effective date of the policy? | yes        |
		| Do you have multiple locations in more than one state?                                                                                                     | no         |
		| Federal Employer Identification Number (FEIN)                                                                                                              | 63-1212123 |
	Then user begins the WC AI page having the FEIN with value 63-1212123
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                   |
		| Business name      | Test Auto XMOD          |
		| Contact first name | TestF                   |
		| Contact last name  | TestL                   |
		| Email              | TestCert@Plan.com       |
		| Phone              | (123) 123-1321          |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the refer thank you page appears