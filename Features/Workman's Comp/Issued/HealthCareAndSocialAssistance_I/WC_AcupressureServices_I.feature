Feature: WC_AcupressureServices_I
Issuing an Acupressure Services policy 
ZIP Code: 55406 (MN)
Additional Info page - Verifying Excluded OO

@OwnerOfficer @Regression @WC @Issued @Health @MN
Scenario: WC Acupressure Services creates issued policy in Minnesota
	Given user starts a quote with:
		| Industry             | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Acupressure Services | 8         | I Own a Property & Lease to Others |              | 55406    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                           |
		| When do you want your policy to start?                                                 |                                  |
		| When did you start your business?                                                      | Started 9 years ago              |
		| How is your business structured?                                                       | Limited Liability Co. (LLC)      |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 440440                           |
		| Business                                                                               | So Much Pressure;Press Your Luck |
		| Address                                                                                | 3110 E Lake St;Minneapolis       |
		| Fill Contact                                                                           |                                  |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                                                       | Answer |
		| How many owners/officers does your business have?                                                                                              | 4      |
		| How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered. | 4      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 payroll | Annual Payroll |
		| Kirst      | Nast      | yes        | 22000          |
		| Mc         | Donald    | yes        | 18000          |
		| Mike       | Madden    | yes        | 25000          |
		| Sunny      | Days      | yes        | 23000          |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                               | Answer      |
		| Do you provide emergency response workers to areas with disease outbreaks, catastrophes, or disasters? | no          |
		| In the past 3 years how many Workers' Compensation claims were reported?                               | None        |
		| Do you currently have a Workers' Compensation insurance policy in effect?                              | yes         |
		| Do you use any volunteers or donated labor?                                                            | no          |
		| Do you have multiple locations in more than one state?                                                 | no          |
		| Social Security Number (SSN)                                                                           | 231-11-1111 |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard multi-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                         |
		| ELL - Each Accident / Total Policy / Each Employee | 1,000,000/1,000,000/1,000,000 |
	Then user begins the WC AI page having the SSN with value 231-11-1111
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 20% Down + 9 Monthly Installments |
		| CC Name             | Funky Chicken-cheese              |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 11                                |
		| CC Expiration Year  | 25                                |
		| Autopay             | No                                |
		| First Name          | Funky                             |
		| Last Name           | Kong                              |
		| Email               | FunkyKong@Cheese.com              |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: PL, BOP