Feature: WC_CabinetryOrInteriorTrimInstallation_I

CabinetryOrInteriorTrimInstallation Auto XMODs

@Staging @Regression @WC @Construction @Issued @AZ
Scenario: WC Cabinetry Or Interior Trim Installation policy issued for Arizona/ Auto XMODs
	Given user starts a quote with:
		| Industry                                | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Cabinetry or Interior Trim Installation | 5         | I Lease a Space From Others |              | 85249    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                       |
		| When do you want your policy to start?                                                 |                              |
		| When did you start your business?                                                      | Started 10 years or more ago |
		| How is your business structured?                                                       | Corporation                  |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 200000                       |
		| Are there any employees that never travel to job sites or do any construction work?    | no                           |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                           |
		| Business                                                                               | Test Auto XMOD; Test DBA     |
		| Address                                                                                | 2104 E Firestone Dr;Chandler |
		| Contact First Name                                                                     | TestF                        |
		| Contact Last Name                                                                      | TestL                        |
		| Email                                                                                  | Test@Test123.com             |
		| Phone                                                                                  | 1231231321                   |
		| Business website                                                                       | test.com                     |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| TestF      | TestL     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                         | Answer     |
		| Do you ever transport six or more workers in the same vehicle?                                                   | no         |
		| Do you do any framing work?                                                                                      | no         |
		| Do you do roofing work?                                                                                          | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?                                         | None       |
		| Do you perform any work over 30 feet above ground level?                                                         | no         |
		| Do you perform any work underground including in trenches, holes, or tunnels?                                    | no         |
		| Do you do any demolition or wrecking of entire buildings or homes?                                               | no         |
		| Do the business owner(s) of this business have a combined majority ownership in any other construction business? | no         |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                        | yes        |
		| Do you do any water damage, fire damage, or mold restoration?                                                    | no         |
		| Do you do any construction work in New York?                                                                     | no         |
		| Do you have multiple locations in more than one state?                                                           | no         |
		| Federal Employer Identification Number (FEIN)                                                                    | 06-2671064 |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a Standard Single-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the FEIN with value 06-2671064
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|           |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value            |
		| CC Name             | TestF TestL      |
		| CC Number           | 4111111111111111 |
		| CC Expiration Month | 03               |
		| CC Expiration Year  | 30               |
		| Autopay             | Yes              |
		| First Name          | TestF            |
		| Last Name           | TestL            |
		| Email               | Test@Test123.com |
		| Phone               | 7777777777       |
		| Same Billing Info?  | Yes              |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: GL