Feature: WC_IronGrillOrRailing_I

User Story 89461: WC | Feature File - Issued | SCENARIO 22 Ornamental Iron Grill or Railing Erection - MA

@Issued @Regression @Staging @MA @Construction
Scenario: WC Iron Grill Or Railing creates issued policy for Massachusetts
	Given user starts a quote with:
		| Industry                                  | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Ornamental Iron Grill or Railing Erection | 3         | I Lease a Space From Others |              | 02301    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                  |
		| When do you want your policy to start?                                                 |                         |
		| When did you start your business?                                                      | Started 8 years ago     |
		| How is your business structured?                                                       | Partnership             |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 50000                   |
		| Are there any employees that never travel to job sites or do any construction work?    | no                      |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                      |
		| Business                                                                               | Test refer              |
		| Address                                                                                | 701 SE 71st St;Brockton |
		| Contact First Name                                                                     | TestF                   |
		| Contact Last Name                                                                      | TestL                   |
		| Email                                                                                  | Test@Test123.com        |
		| Phone                                                                                  | 1231233333              |
		| Business website                                                                       | test.com                |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                          | Answer |
		| How many owners/officers does your business have?                 | 5+     |
		| How many owners/officers do you want to cover with this policy?   | 3      |
		| How many owners/officers do you want to exclude from this policy? | 2      |
	Then user handles the WC Covered OO with these values:
		| First Name | Last Name |
		| Kirst      | Nast      | 
		| Burger     | King      | 
		| HappyIs    | Madden    | 
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name | 
		| OneF       | OneL      | 
		| TwoF       | TwoL      | 
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                         | Answer                   |
		| Do you install any structures such as barns, garages, gas stations, greenhouses, hangars, or sheds?              | no                       |
		| Do you install any overhead doors?                                                                               | no                       |
		| Do you ever transport six or more workers in the same vehicle?                                                   | no                       |
		| In the past 3 years how many Workers' Compensation claims were reported?                                         | None                     |
		| Do you perform any work over 30 feet above ground level?                                                         | no                       |
		| Do you do any demolition or wrecking of entire buildings or homes?                                               | no                       |
		| Do the business owner(s) of this business have a combined majority ownership in any other construction business? | no                       |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                        | no                       |
		| When was your last policy in effect?                                                                             | Never no prior insurance |
		| Do you do any construction work in New York?                                                                     | no                       |
		| Do you have multiple locations in more than one state?                                                           | no                       |
		| Do you do any work on barges/vessels/docks/or bridges over water?                                                | no                       |
	When user selects a plus plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page setting the FEIN with value 83-2803691
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                              |
		| Payment Option      | 10% Down + 10 Monthly Installments |
		| CC Name             | Funky Chicken-cheese               |
		| CC Number           | 4111111111111111                   |
		| CC Expiration Month | 11                                 |
		| CC Expiration Year  | 25                                 |
		| Autopay             | No                                 |
		| First Name          | TestF                              |
		| Last Name           | TestL                              |
		| Email               | Test@Test123.com                   |
		| Phone               | 1231233333                         |
		| Same Billing Info?  | Yes                                |
	Then user verifies the WC how would you rate our service modal 
	Then user verifies the WC thank you page appearance