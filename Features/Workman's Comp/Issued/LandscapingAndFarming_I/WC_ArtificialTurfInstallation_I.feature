Feature: WC_ArtificialTurfInstallation_I

 Issuing a Artificial Turf Installation Policy in Iowa

@Regression @YourServices @IA @WC @Landscaping @Issued
Scenario: Artificial Turf Installation- IA
	Given user starts a quote with:
		| Industry                     | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Artificial Turf Installation | 2         | I Lease a Space From Others |              | 50613    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                       |
		| When do you want your policy to start?                                                 |                              |
		| When did you start your business?                                                      | Started 9 years ago          |
		| How is your business structured?                                                       | Corporation                  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 440440                       |
		| Do any employees only do general office work and rarely travel?                        | no                           |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                           |
		| Business                                                                               | Artificial Turf Installation |
		| Address                                                                                | 1310 W 1st St;Cedar Falls    |
		| Fill Contact                                                                           |                              |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 2      |
		| How many owners/officers do you want to cover with this policy? | 1      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name | W2 Payroll | Annual Payroll | Job Duty         |
		| Ken        | Masters   | yes        | 50000          | Physical Laborer |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| Cammy      | White     |
	Then user continues on from the WC OO page
	Then user verifies the appearance of the WC Your Services Page
	Then user fills out the WC Your Services page
		| Question                                                                                    | Answer      |
		| Do you trim trees above ground level or remove trees/stumps?                                | no          |
		| Do you do any new landscaping such as laying down bricks,  sod, or stones or planting work? | no          |
		| Do you do any roofing work?                                                                 | no          |
		| Do you ever transport six or more workers in the same vehicle?                              | no          |
		| Do you do any framing work?                                                                 | yes         |
		| What percentage of work done is framing (rough  carpentry)?                                 | 40          |
		| Do you provide any lot or land clearing services?                                           | yes         |
		| Do you do any construction work such as carpentry, decking, handyman jobs, or painting?     | yes         |
		| Do you do any logging work?                                                                 | no          |
		| In the past 3 years how many Workers' Compensation claims were reported?                    | None        |
		| Do you currently have a Workers' Compensation insurance policy in effect?                   | yes         |
		| Do you have multiple locations in more than one state?                                      | no          |
		| Social Security Number (SSN)                                                                | 231-11-1111 |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard multi-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user verifies the appearance of the WC Additional Information page
	Then user begins the WC AI page having the SSN with value 231-11-1111
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | Radiatoin Safety Services         |
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
	Then user verifies that these LOBs are recommended: GL
