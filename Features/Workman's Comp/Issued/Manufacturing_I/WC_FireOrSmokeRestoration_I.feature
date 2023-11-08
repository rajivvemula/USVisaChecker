Feature: WC_FireOrSmokeRestoration_I

Do you do any construction related activities including carpentry, painting, or handyman work? - yes
Do you do framing work (i.e. rough carpentry)? - no
Do you perform any roofing work? - no

'Do you do any roofing work?' may be rewritten as  'Do you perform any roofing work?' in the future.
@WC @Manufacturing @Regression @Issued @NV 
Scenario: WC Fire Or Smoke Damage Restoration is issued in Nevada
	Given user starts a quote with:
		| Industry                         | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Fire or Smoke Damage Restoration | 8         | I Own a Property & Lease to Others |              | 89156    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When did you start your business?                                                      | Started 8 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 500000                      |
		| Do any employees only do general office work and rarely travel?                        | No                          |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | No                          |
		| Business                                                                               |                             |
		| Address                                                                                | 105 Test Rd,Las Vegas       |
		| Fill Contact                                                                           |                             |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                                       | Answer |
		| How many owners/officers does your business have?                              | 3      |
		| How many owners/officers do you want to cover with this policy?                | 3      |
		| Do any included owners/officers only do general office work and rarely travel? | No     |
	Then user continues on from the WC OO page
	And user verifies the appearance of the WC Your Services Page
	Then user fills out the WC Your Services page
		| Question                                                                                       | Answer     |
		| Do you do any roofing work?                                                                    | no         |
		| Do you do asbestos abatement?                                                                  | no         |
		| Do you do any construction related activities including carpentry, painting, or handyman work? | yes        |
		| Do you do framing work (i.e. rough carpentry)?                                                 | no         |
		| Do you perform any roofing work?                                                               | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?                       | None       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                      | yes        |
		| Do you have multiple locations in more than one state?                                         | no         |
		| Federal Employer Identification Number (FEIN)                                                  | 23-1626549 |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                         |
		| ELL - Each Accident / Total Policy / Each Employee | 1,000,000/1,000,000/1,000,000 |
	Then user begins the WC AI page having the FEIN with value 23-1626549
	And wc user handles 3 covered oo
	And user continues on from the WC Additional Information page
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
	And user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance