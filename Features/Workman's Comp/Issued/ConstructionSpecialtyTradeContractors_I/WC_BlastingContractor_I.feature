Feature: WC_BlastingContractor_I
ZIP Code: 66103 (KS)
OO Page - Setting the Percent Ownership and Job Duty
Additional Info page - Setting the Excluded OO SSN, Covered but Excluded OO appearance

@Service @WC @Issued @KS @Regression @YourServices @OwnerOfficer
Scenario: WC Blasting Contractor creates issued policy for Kansas
	Given user starts a quote with:
		| Industry            | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Blasting Contractor | 10        | I Lease a Space From Others |              | 66103    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                                             |
		| When do you want your policy to start?                                                 |                                                    |
		| When did you start your business?                                                      | Started 9 years ago                                |
		| How is your business structured?                                                       | Corporation                                        |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 440440                                             |
		| Are there any employees that never travel to job sites or do any construction work?    | no                                                 |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | yes                                                |
		| Do you require all subcontractors/1099 workers to have certificates of insurance?      | Yes they must have Workers' Compensation insurance |
		| How much of total work is done by subcontractors/1099 workers?                         | 1-25%                                              |
		| Business                                                                               | Blast Away;BOOM                                    |
		| Address                                                                                | 4215 Rainbow Blvd;Kansas City                      |
		| Fill Contact                                                                           |                                                    |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                                                                                       | Answer |
		| How many owners/officers does your business have?                                                                                              | 5      |
		| How many owners/officers do you want to cover with this policy? State law requires owners/officers with less than 10% ownership to be covered. | 0      |
	Then user handles the WC Excluded OO with these values:
		| Name | Checkbox |
		|      | Yes      |
		|      | Yes      |
		|      | Yes      |
		|      | Yes      |
		|      | Yes      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                         | Answer     |
		| Do you ever transport six or more workers in the same vehicle?                                                   | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?                                         | None       |
		| Do you perform any work over 30 feet above ground level?                                                         | no         |
		| Do you perform any work underground including in trenches, holes, or tunnels?                                    | no         |
		| Do you do any demolition or wrecking of entire buildings or homes?                                               | no         |
		| Do the business owner(s) of this business have a combined majority ownership in any other construction business? | no         |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                        | yes        |
		| Do you do any construction work in New York?                                                                     | no         |
		| Do you have multiple locations in more than one state?                                                           | no         |
		| Federal Employer Identification Number (FEIN)                                                                    | 23-1111110 |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 23-1111110
	Then wc user handles 5 excluded oo with these values:
		| Have Name | Set SSN     |
		|           | 221-11-3434 |
		|           | 231-44-1212 |
		|           | 221-77-2121 |
		|           | 213-13-1313 |
		|           | 221-81-3333 |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                              |
		| Payment Option      | 10% Down + 10 Monthly Installments |
		| CC Name             | Funky Chicken-cheese               |
		| CC Number           | 4111111111111111                   |
		| CC Expiration Month | 11                                 |
		| CC Expiration Year  | 25                                 |
		| Autopay             | No                                 |
		| First Name          | Funky                              |
		| Last Name           | Kong                               |
		| Email               | FunkyKong@Cheese.com               |
		| Phone               | 7777777777                         |
		| Same Billing Info?  | Yes                                |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance