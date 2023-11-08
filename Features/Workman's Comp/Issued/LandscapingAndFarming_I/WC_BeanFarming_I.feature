Feature: WC_BeanFarming_I

Issuing a WC Policy for Bean Farming in Massachusetts

@Regression @YourServices @MA @WC @Landscaping @Issued
Scenario: WC Bean Farming issued policy in MA
	Given user starts a quote with:
		| Industry     | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Bean Farming | 2         | I Lease a Space From Others |              | 02301    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                  |
		| When do you want your policy to start?                                                 |                         |
		| When did you start your business?                                                      | Started 9 years ago     |
		| How is your business structured?                                                       | Corporation             |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 440440                  |
		| Do any employees only do general office work and rarely travel?                        | no                      |
		| Is housing provided for any of the workers?                                            | no                      |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                      |
		| Business                                                                               | MA Bean Farming         |
		| Address                                                                                | 701 SE 71st St;Brockton |
		| Fill Contact                                                                           |                         |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                                                       | Answer |
		| How many owners/officers does your business have?                                                                                              | 2      |
		| How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered. | 2      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll | Job Duty         |
		| OneF       | OneL      | yes        | 25000          | Physical Laborer |
		| TwoF       | TwoL      | yes        | 25000          | Physical Laborer |
	Then user continues on from the WC OO page
	Then user verifies the appearance of the WC Your Services Page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer      |
		| Do you have any grain elevators or silos on site?                         | no          |
		| Do you grow any fruit tree or nut tree crops?                             | no          |
		| Do you provide any farm labor contractor services?                        | no          |
		| Do you ever transport six or more workers in the same vehicle?            | no          |
		| Do you deliver any sold livestock or harvested crops?                     | no          |
		| Do you do any logging work?                                               | no          |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None        |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes         |
		| Do you have multiple locations in more than one state?                    | no          |
		| Social Security Number (SSN)                                              | 231-11-1234 |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard multi-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user verifies the appearance of the WC Additional Information page
	Then user begins the WC AI page having the SSN with value 231-11-1234
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | Test                              |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 11                                |
		| CC Expiration Year  | 28                                |
		| Autopay             | No                                |
		| First Name          | FN                                |
		| Last Name           | LN                                |
		| Email               | Test@gmail.com                    |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance