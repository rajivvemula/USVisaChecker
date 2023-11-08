Feature: WC_FloorInstallationNoCarpeting_I

Issuing a Floor Installation: No Carpeting in KY

@Service @WC @Issued @KY @Regression @YourServices
Scenario: WC Floor Installation: No Carpeting Issuing a policy for Kentucky
	Given user starts a quote with:
		| Industry                         | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Floor Installation: No Carpeting | 4         | I Own a Property & Lease to Others |              | 42724    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                                | Answer                       |
		| When do you want your policy to start?                                                                  |                              |
		| When did you start your business?                                                                       | Started 5 years ago          |
		| How is your business structured?                                                                        | Corporation                  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)                  | 100,000                      |
		| Are there any retail store employees that do not do any installation, maintenance, or contracting work? | no                           |
		| Do any employees only do general office work and rarely travel?                                         | no                           |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                                   | no                           |
		| Business                                                                                                | KY Floor Installation        |
		| Address                                                                                                 | 10471 Leitchfield Rd;Cecilia |
		| Fill Contact                                                                                            |                              |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                         | Answer     |
		| Do you ever transport six or more workers in the same vehicle?                                                   | no         |
		| What percentage of work done is drywall/sheetrock?                                                               | 10         |
		| Do you do any framing work?                                                                                      | no         |
		| Do you do roofing work?                                                                                          | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?                                         | None       |
		| Do you perform any work over 30 feet above ground level?                                                         | no         |
		| Do you do any water damage, fire damage, or mold restoration?                                                    | no         |
		| Do you do any demolition or wrecking of entire buildings or homes?                                               | no         |
		| Do the business owner(s) of this business have a combined majority ownership in any other construction business? | no         |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                        | yes        |
		| Do you do any construction work in New York?                                                                     | no         |
		| Do you have multiple locations in more than one state?                                                           | no         |
		| Federal Employer Identification Number (FEIN)                                                                    | 23-1326965 |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
	When user selects a Standard Single-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization | 
		| N/A           |
	Then user begins the WC AI page having the FEIN with value 23-1326965
	Then wc user handles 1 excluded oo with these values:
		| Set Name   |
		| John Black |
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