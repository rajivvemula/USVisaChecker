Feature: WC_PropertyPreservation_I

Issuing a Property Preservation policy

@Service @WC @Issued @AR @Regression @YourServices
Scenario: WC Property Preservation issuing a policy for Arizona
	Given user starts a quote with:
		| Industry              | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Property Preservation | 3         | I Lease a Space From Others |              | 72067    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                          |
		| When do you want your policy to start?                                                 |                                 |
		| When did you start your business?                                                      | Started 10 years or more ago    |
		| How is your business structured?                                                       | Corporation                     |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 45,000                          |
		| Are there any clerical office workers or real estate/leasing agents on staff?          | no                              |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                              |
		| Business                                                                               | Prolific Preservers Inc;PPI     |
		| Address                                                                                | 210 Lone Pine Rd S;Greers Ferry |
		| Fill Contact                                                                           |                                 |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                   | Answer     |
		| What percentage of work done is water damage, fire damage, or mold restoration?            | 26         |
		| Do you do any construction related work such as carpentry, drywall, or demolition?         | no         |
		| Do you do any roofing work?                                                                | no         |
		| Do you ever transport six or more workers in the same vehicle?                             | no         |
		| Do you clean any chimneys by crawling inside or climbing on roofs to access them?          | no         |
		| Do you provide any lot or land clearing services?                                          | no         |
		| Do you offer any bulk removal services such as furniture, mattresses, or large appliances? | no         |
		| Do you engage in any new construction, remodeling, or framing work?                        | no         |
		| Do you clean any exterior windows above ground level?                                      | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?                   | None       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                  | yes        |
		| Do you have multiple locations in more than one state?                                     | no         |
		| Federal Employer Identification Number (FEIN)                                              | 23-7177824 |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a Standard Single-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 23-7177824
	Then wc user handles 1 excluded oo with these values:
		| Set Name         |
		| Preservation Guy |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | Preservation Guy                  |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 11                                |
		| CC Expiration Year  | 25                                |
		| Autopay             | N/A                               |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | TestFTestL@Test123.com            |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: PL