Feature: WC_Arborist_I

Issuing a Arborist Policy in LA

@WC @Issued @Regression @Landscaping @LA 
Scenario: WC Arborist Services policy gets Issued for LA state
	Given user starts a quote with:
		| Industry | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Arborist | 3         | I Work at a Job Site |              | 70006    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 7 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 70000                       |
		| Are there any cost estimators on staff that wouldn't do any direct physical work?      | no                          |
		| Do any employees only do general office work and rarely travel?                        | no                          |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                          |
		| Business                                                                               | Test refer                  |
		| Address                                                                                | 4900 SAINT MARY ST;Metairie |
		| Contact First Name                                                                     | TestF                       |
		| Contact Last Name                                                                      | TestL                       |
		| Email                                                                                  | Test@Test123.com            |
		| Phone                                                                                  | 2551234587                  |
		| Business website                                                                       | test.com                    |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                                                       | Answer |
		| How many owners/officers does your business have?                                                                                              | 2      |
		| How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered. | 2      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | job duty         |
		| Kirst      | Nast      | Physical Laborer |
		| Mc         | Donald    | Physical Laborer |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                | Answer     |
		| How are trees most commonly reached to inspect, spray, or trim?                         | Ladders    |
		| Do you do any roofing work?                                                             | no         |
		| Do you ever transport six or more workers in the same vehicle?                          | no         |
		| Do you do any work higher than 40 feet above ground?                                    | no         |
		| Do you do any construction work such as carpentry, decking, handyman jobs, or painting? | no         |
		| Do you provide any lot or land clearing services?                                       | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?                | None       |
		| Do you currently have a Workers' Compensation insurance policy in effect?               | yes        |
		| Do you have multiple locations in more than one state?                                  | no         |
		| Federal Employer Identification Number (FEIN)                                           | 23-1326967 |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 23-1326965
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