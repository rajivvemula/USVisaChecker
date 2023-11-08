Feature: WC_CharterBusService_I

Issuing a Charter Bus Service policy

@Transportation @WC @Issued @MT @Regression @YourServices
Scenario: WC Charter Bus Service creates issued policy in Montana
	Given user starts a quote with:
		| Industry            | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Charter Bus Service | 10        | I Work at a Job Site |              | 59901    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                   |
		| When do you want your policy to start?                                                 |                          |
		| When did you start your business?                                                      | Started 4 years ago      |
		| How is your business structured?                                                       | Partnership              |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 250000                   |
		| Do any employees do any maintenance, repair, or service on motor vehicles?             | no                       |
		| Do any employees only do general office work and rarely travel?                        | no                       |
		| Business                                                                               | Git'U'Dere               |
		| Address                                                                                | 1004 6th Ave W;Kalispell |
		| Contact First Name                                                                     | TestF                    |
		| Contact Last Name                                                                      | TestL                    |
		| Email                                                                                  | Test@Test123.com         |
		| Phone                                                                                  | 1231233333               |
		| Business website                                                                       | test.com                 |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                               | Answer |
		| How many owners/officers does your business have?                                      | 2      |
		| How many owners/officers do you want to cover with this policy?                        | 2      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name    | W2 payroll | Annual Payroll | Job Duty              |
		| Kaladin    | Stormblessed | yes        | 22000          | Driver or Mechanic    |
		| Shallan    | Davar        | yes        | 25000          | General Office Worker |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                           | Answer       |
		| What is the furthest any of your vehicles travel in any one direction from their home base?                        | 0 - 50 miles |
		| In the past 3 years how many Workers' Compensation claims were reported?                                           | None         |
		| Do you review MVRs for all employees with a driving exposure?                                                      | No           |
		| Do drivers assist any handicapped passengers with entering or exiting the vehicle?                                 | no           |
		| Are your employees engaged in the unloading/loading of any passenger luggage?                                      | yes          |
		| Do you mainly transport customers to, from, or within an airport such as a shuttle service?                        | yes          |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                          | yes          |
		| Do the business owner(s) of this business have a combined majority ownership in any other transportation business? | no           |
		| Do you have multiple locations in more than one state?                                                             | no           |
		| Federal Employer Identification Number (FEIN)                                                                      | 832803691    |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 83-2803691
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                              |
		| Payment Option      | 10% Down + 10 Monthly Installments |
		| CC Name             | Funky Chicken-cheese               |
		| CC Number           | 4111111111111111                   |
		| CC Expiration Month | 11                                 |
		| CC Expiration Year  | 25                                 |
		| Autopay             | No                                 |
		| First Name          | TestF                              |
		| Last Name           | TestL                              |
		| Email               | Test@Test123.com                   |
		| Phone               | 1231233333                         |
		| Same Billing Info?  | Yes                                |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance