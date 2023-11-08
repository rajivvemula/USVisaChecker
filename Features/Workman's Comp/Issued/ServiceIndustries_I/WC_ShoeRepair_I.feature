Feature: WC_ShoeRepair_I

Issuing a policy for Keyword: Shoe Repair for US 94210 Negative testing scenario
Industry = 'Service Industries' and Subindustry = 'Installation/Repair'
Do You have employee: 3 employees
Business Operation: I Lease a Space From Others
When did you start your business: Started 2 year ago

@WC @Regression @Issued @Cali
Scenario: WC Shoe Repair creates issued policy in California
	Given user starts a quote with:
		| Industry    | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Shoe Repair | 3         | I Lease a Space From Others |              | 90012    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 2 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 100,000                     |
		| Do any employees only do general office work and do not work a cash register?          | no                          |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                          |
		| Business                                                                               | WC Shoe Repair              |
		| Address                                                                                | 100 S Main St;Los Angeles   |
		| Contact First Name                                                                     | TestF                       |
		| Contact Last Name                                                                      | TestL                       |
		| Email                                                                                  | Test@Test123.com            |
		| Phone                                                                                  | 1231231321                  |
		| Business website                                                                       |                             |
	And user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None   |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes    |
		| Do you have multiple locations in more than one state?                    | no     |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a Standard Single-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization |
		| N/A           |
	Then user begins the WC AI page setting the SSN with value 325-64-9484
	Then wc user handles 1 excluded oo with these values:
		| Set Name  |
		| Jon Right |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | Test Test                         |
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
	Then user verifies that these LOBs are recommended: BOP