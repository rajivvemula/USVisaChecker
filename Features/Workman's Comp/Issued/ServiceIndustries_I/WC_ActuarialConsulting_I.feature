Feature: WC_ActuarialConsulting_I

Issuing an Actuarial Consulting policy

@Service @WC @Issued @Regression @CO @YourServices
Scenario: WC Actuarial Consulting gets Issued for Colorado state
	Given user starts a quote with:
		| Industry             | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Actuarial Consulting | 3         | I Work at a Job Site |              | 80229    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 7 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 70000                       |
		| Do any employees travel frequently for sales, consultation, or auditing?               | no                          |
		| Do you provide any staffing services?                                                  | no                          |
		| Business                                                                               | Test refer                  |
		| Address                                                                                | 1040 E 71st Ave;Denver      |
		| Contact First Name                                                                     | TestF                       |
		| Contact Last Name                                                                      | TestL                       |
		| Email                                                                                  | Test@Test123.com            |
		| Phone                                                                                  | 2551234587                  |
		| Business website                                                                       | test.com                    |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                | Answer |
		| How many owners/officers does your business have?                                       | 2      |
		| How many owners/officers do you want to cover with this policy?                         | 2      |
		| Do any included owners/officers travel frequently for sales, consultation, or auditing? | No     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                               | Answer |
		| Do you do any direct physical work such as construction, landscaping, or farming?                      | no     |
		| Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters? | no     |
		| In the past 3 years how many Workers' Compensation claims were reported?                               | None   |
		| Do you have multiple locations in more than one state?                                                 | no     |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-1326965
	And wc user handles 2 covered oo
	And user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                  |
		| CC Name             | Funky Chicken-cheese   |
		| CC Number           | 4111111111111111       |
		| CC Expiration Month | 11                     |
		| CC Expiration Year  | 25                     |
		| Autopay             | N/A                    |
		| First Name          | TestF                  |
		| Last Name           | TestL                  |
		| Email               | TestFTestL@Test123.com |
		| Phone               | 7777777777             |
		| Same Billing Info?  | Yes                    |
	Then user verifies the WC how would you rate our service modal
	And user verifies the WC thank you page appearance
	And user verifies that these LOBs are recommended: PL