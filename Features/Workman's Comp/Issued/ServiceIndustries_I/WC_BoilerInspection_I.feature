Feature: WC_BoilerInspection_I

Issuing a Boiler Inspection policy

@Service @WC @Issued @IL @Regression @YourServices
Scenario: WC Boiler Inspection Issuing a policy for Illinois
	Given user starts a quote with:
		| Industry          | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Boiler Inspection | 4         | I Own a Property & Lease to Others |              | 61752    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                       |
		| When do you want your policy to start?                                                 |                              |
		| When did you start your business?                                                      | Started 10 years or more ago |
		| How is your business structured?                                                       | Corporation                  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 50,000                       |
		| Do any employees only do general office work and rarely travel?                        | no                           |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                           |
		| Business                                                                               | Boiler Inspector Guys;BIG    |
		| Address                                                                                | 501 E Elm St;Le Roy          |
		| Fill Contact                                                                           |                              |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                       | Answer |
		| How many owners/officers does your business have?                              | 1      |
		| How many owners/officers do you want to cover with this policy?                | 1      |
		| Do any included owners/officers only do general office work and rarely travel? | No     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                 | Answer     |
		| Do you do any boiler inspections for commercial, industrial, or multi-family residences? | no         |
		| Do you travel to damaged properties to adjust claims?                                    | no         |
		| Do you do any installation, repair, or damage restoration services?                      | no         |
		| Do you do any asbestos inspection?                                                       | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?                 | None       |
		| Do you perform any work over 30 feet above ground level?                                 | no         |
		| Do you inspect any roofs?                                                                | yes        |
		| Do you set up emergency tarping or repair roofs?                                         | no         |
		| Do you currently have a Workers' Compensation insurance policy in effect?                | yes        |
		| Do you have multiple locations in more than one state?                                   | no         |
		| Federal Employer Identification Number (FEIN)                                            | 23-1326965 |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a Plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 23-1326965
	Then wc user handles 1 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | Boiler Inspector Guys             |
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
	Then user verifies that these LOBs are recommended: PL,BOP