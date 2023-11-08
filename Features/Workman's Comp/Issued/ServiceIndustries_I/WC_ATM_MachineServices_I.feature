Feature: WC_ATM_MachineServices_I

Issuing a WC policy for ATM Machine Services in Oregon

@WC @Issued @Service @Regression @YourServices @OR
Scenario: WC ATM Machine Services policy issued in Oregon
	Given user starts a quote with:
		| Industry             | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| ATM Machine Services | 5         | I Work at a Job Site |              | 97301    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 7 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 70000                       |
		| Do any employees only do general office work and rarely travel?                        | no                          |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                          |
		| Business                                                                               | Oregon ATM Services         |
		| Address                                                                                | 1340 State St;Salem         |
		| Contact First Name                                                                     | TestF                       |
		| Contact Last Name                                                                      | TestL                       |
		| Email                                                                                  | Test@Test123.com            |
		| Phone                                                                                  | 2551234587                  |
		| Business website                                                                       |                             |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                       | Answer |
		| How many owners/officers does your business have?                              | 1      |
		| How many owners/officers do you want to cover with this policy?                | 1      |
		| Do any included owners/officers only do general office work and rarely travel? | No     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                | Answer    |
		| Are you engaged in delivery or removal of the machines themselves?                      | yes       |
		| In the past 3 years how many Workers' Compensation claims were reported?                | None      |
		| Do you currently have a Workers' Compensation insurance policy in effect?               | yes       |
		| Do you have multiple locations in more than one state?                                  | no        |
		| Federal Employer Identification Number (FEIN)                                           | 231234567 |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a Standard Multi-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 500,000/500,000/500,000 |
	Then user begins the WC AI page having the FEIN with value 23-2651148
	Then wc user handles 1 excluded oo with these values:
		| Set Name    |
		| NameF NameL |
	And user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 25% Down + 6 Monthly Installments |
		| CC Name             | Joh Doe                           |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 11                                |
		| CC Expiration Year  | 25                                |
		| Autopay             | No                                |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | TestFTestL@Test123.com            |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	And user verifies the WC thank you page appearance