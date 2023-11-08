﻿Feature: WC_IncreasedOnlineThreshould_Underwritings

Verify the increased Online threshold for Underwritings for WC - US110277
WC -> Premium increased from $50000 to $60000

@Regression @WC @NH @Referred
Scenario: WC Quote gets Referred when premium is more than $60000
	Given user starts a quote with:
		| Industry   | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Mudjacking | 6         | I Lease a Space From Others |              | 03053    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                                             |
		| When do you want your policy to start?                                                 |                                                    |
		| When did you start your business?                                                      | Started 9 years ago                                |
		| How is your business structured?                                                       | Corporation                                        |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 1404250                                            |
		| Are there any employees that never travel to job sites or do any construction work?    | no                                                 |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | yes                                                |
		| Do you require all subcontractors/1099 workers to have certificates of insurance?      | Yes they must have Workers' Compensation insurance |
		| How much of total work is done by subcontractors/1099 workers?                         | 1-25%                                              |
		| Business                                                                               | Mud Lifts Me Up;Mud Mountain                       |
		| Address                                                                                | 39 Nashua Rd;Londonderry                           |
		| Fill Contact                                                                           |                                                    |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 3      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                         | Answer     |
		| Do you build any load-bearing concrete walls?                                                                    | no         |
		| Do you do any masonry work such as manual brick or stone laying?                                                 | no         |
		| Do you do residential foundation work?                                                                           | no         |
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
	Then user begins the WC AI page having the FEIN with value 23-1111110
	Then wc user handles 3 excluded oo with these values:
		| Set Name     | Set Job        | Set DOB  |
		| Bret Farve   | President      | 9/9/1991 |
		| Randy Moss   | Vice President | 8/8/1988 |
		| Adam Thielan | Treasurer      | 7/7/1977 |
	Then user continues on from the WC Additional Information page
	When user fills out the WC refer page with these values:
		| Field              | Value                   |
		| Business name      | RideSharing             |
		| Contact first name | TestF                   |
		| Contact last name  | TestL                   |
		| Email              | Test@Test123.com        |
		| Phone              | 1231233212              |
		| Business website   | www.TestPartnerCert.com |
	Then user verifies the refer thank you page appears

@Regression @WC @PA @Issued
Scenario: WC Quote gets Issued when premium is more than $50000 and less than $60000
	Given user starts a quote with:
		| Industry | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Florist  | 50        | I Lease a Space From Others |              | 18704    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                       |
		| When do you want your policy to start?                                                 |                              |
		| When did you start your business?                                                      | Started 6 years ago          |
		| How is your business structured?                                                       | Limited Liability Co. (LLC)  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 6062660                      |
		| Business                                                                               | Test ID Flag 4 Corp;Test DBA |
		| Address                                                                                | 780 S 14th St;Pringle        |
		| Contact First Name                                                                     | TestF                        |
		| Contact Last Name                                                                      | TestL                        |
		| Email                                                                                  | Test@Test123.com             |
		| Phone                                                                                  | 1231231321                   |
		| Business website                                                                       | test.com                     |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 2      |
		| How many owners/officers do you want to cover with this policy? | 2      |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                  | Answer     |
		| What percentage of your overall sales involve delivery?                   | 0          |
		| In the past 3 years how many Workers' Compensation claims were reported?  | None       |
		| Do you currently have a Workers' Compensation insurance policy in effect? | yes        |
		| Do you have multiple locations in more than one state?                    | no         |
		| Federal Employer Identification Number (FEIN)                             | 23-1111110 |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	Then user verifies the WC your quote page appearance
	When user selects a plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 63-1212123
	Then wc user handles 2 covered oo
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                             |
		| Payment Option      | 15% Down + 9 Monthly Installments |
		| CC Name             | TestF TestL                       |
		| CC Number           | 4111111111111111                  |
		| CC Expiration Month | 03                                |
		| CC Expiration Year  | 30                                |
		| Autopay             | No                                |
		| First Name          | TestF                             |
		| Last Name           | TestL                             |
		| Email               | Test@Test123.com                  |
		| Phone               | 7777777777                        |
		| Same Billing Info?  | Yes                               |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance