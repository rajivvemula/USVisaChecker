Feature: WC_LyftDriver_I
Issuing a Lyft Driver policy
Zipcode:10001

@Transportation @WC @Issued @NY @Regression @YourServices
Scenario: WC Lyft Driver creates an isued policy in NY
	Given user starts a quote with:
		| Industry    | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Lyft Driver | 4         | I Lease a Space From Others |              | 10001    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                 |
		| When do you want your policy to start?                                                 |                        |
		| When did you start your business?                                                      | Started 5 years ago    |
		| How is your business structured?                                                       | Corporation            |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 505000                 |
		| Do any employees do any maintenance, repair, or service on motor vehicles?             | no                     |
		| Do any employees only do general office work and rarely travel?                        | no                     |
		| Business                                                                               | Lyft Driver            |
		| Address                                                                                | 550 W 25th St;New York |
		| Fill Contact                                                                           |                        |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| Tommy      | Oliver    |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                           | Answer                   |
		| How many vehicles do you own that are operated by employees?                                                       | 0                        |
		| Do you lease or rent out any vehicles to any non-employees?                                                        | no                       |
		| In the past 3 years how many Workers' Compensation claims were reported?                                           | None                     |
		| Do you pay any drivers via 1099 that use their own vehicle?                                                        | no                       |
		| Do you review MVRs for all employees with a driving exposure?                                                      | No                       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                          | no                       |
		| When was your last policy in effect?                                                                               | Never no prior insurance |
		| Do the business owner(s) of this business have a combined majority ownership in any other transportation business? | no                       |
		| Do you have multiple locations in more than one state?                                                             | no                       |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a Standard Single-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 23-7177659IV
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|           |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 25% Down + 6 Monthly Installments |
		| CC Name             | Lyft Driver                       |
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
	Then user verifies the WC thank you page appearance
