Feature: WC_CeilingInstallation_I
ZIP Code: 08505 (NJ)
Additional Info page - Setting the FEIN scenario

@OwnerOfficer @WC @Issued @Regression @NJ @Service
Scenario: WC Ceiling Installation creates issued policy for New Jersey
	Given user starts a quote with:
		| Industry             | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Ceiling Installation | 11        | I Lease a Space From Others |              | 08505    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                         |
		| When do you want your policy to start?                                                 |                                |
		| When did you start your business?                                                      | Started 9 years ago            |
		| How is your business structured?                                                       | Limited Liability Co. (LLC)    |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 440440                         |
		| Are there any cost estimators on staff that wouldn't do any direct physical work?      | no                             |
		| Do any employees only do general office work and rarely travel?                        | no                             |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                             |
		| Business                                                                               | Ceilings Are Tall;Install Tall |
		| Address                                                                                | 255 Rt 130;Bordentown          |
		| Fill Contact                                                                           |                                |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                             | Answer |
		| Do you want to buy coverage for the business owners? | yes    |
		| How many owners/officers are there?                  | 4      |
	Then user handles the WC Covered OO with these values:
		| Name | W2 payroll | Annual Payroll | Job Duty               |
		|      | yes        | 44000          | Installation/Repair    |
		|      | yes        | 43000          | Traveling Salespersons |
		|      | yes        | 42000          | General Office Worker  |
		|      | yes        | 41000          | Traveling Salespersons |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                      | Answer |
		| In the past 3 years how many Workers' Compensation claims were reported?      | None   |
		| Do you perform any work over 30 feet above ground level?                      | no     |
		| Do you currently have a Workers' Compensation insurance policy in effect?     | yes    |
		| Do you have multiple locations in more than one state?                        | no     |
		| Does your business have a state-issued experience modification factor (XMOD)? | no     |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                         |
		| ELL - Each Accident / Total Policy / Each Employee | 1,000,000/1,000,000/1,000,000 |
	Then user begins the WC AI page setting the FEIN with value 23-1111110
	Then wc user handles 4 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                |
		| Payment Option      | Monthly              |
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
	Then user verifies that these LOBs are recommended: GL