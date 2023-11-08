Feature: WC_Freight_Securement_No_Transport_NE_I

Zip code: 68516
Issued Policy on WC Freight Securement No transport
Scenario for Third party transport and half of business goods done by own business

@NE @Regression @YourServices @WC @Transportation
Scenario: WC Freight Securement No Transport creates issued policy in Nebraska
	Given user starts a quote with:
		| Industry                         | Employees | Location             | Own or Lease | ZIP Code | LOB |
		| Freight Securement: No Transport | 2         | I Work at a Job Site |              | 68516    | WC  |
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                       |
		| When do you want your policy to start?                                                 |                              |
		| When did you start your business?                                                      | Started 10 years or more ago |
		| How is your business structured?                                                       | Partnership                  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 50,000                       |
		| Do any employees only do general office work and rarely travel?                        | no                           |
		| Do you provide any staffing services?                                                  | no                           |
		| Business                                                                               | Shadaloo                     |
		| Address                                                                                | 1823 Test Rd;Lincoln         |
		| Fill Contact                                                                           |                              |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 2      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | Job Duty           |
		| Vega       | Bison     | Driver or Mechanic |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| Ken        | Masters   |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                    | Answer                                |
		| Is your business in charge of getting any goods to their final destination? | Yes - we may hire 3rd party transport |
		| How much goods transportation is directly done by your business?            | Half or more                          |
		| Do you load or unload any goods?                                            | no                                    |
		| In the past 3 years how many Workers' Compensation claims were reported?    | None                                  |
		| Do you transport any hazardous materials?                                   | no                                    |
		| Do you currently have a Workers' Compensation insurance policy in effect?   | yes                                   |
		| Do you have multiple locations in more than one state?                      | no                                    |
		| Federal Employer Identification Number (FEIN)                               | 23-7177659                            |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard multi-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                |
		| Payment Option      | One Pay Plan         |
		| CC Name             | Funky Chicken-cheese |
		| CC Number           | 4111111111111111     |
		| CC Expiration Month | 11                   |
		| CC Expiration Year  | 25                   |
		| Autopay             | No                   |
		| First Name          | Funky                |
		| Last Name           | Kong                 |
		| Email               | FunkyKong@Cheese.com |
		| Phone               | 7777777777           |
		| Same Billing Info?  | Yes                  |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	



