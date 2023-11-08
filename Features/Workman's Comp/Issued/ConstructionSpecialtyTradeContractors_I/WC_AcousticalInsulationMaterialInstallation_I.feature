Feature: WC_AcousticalInsulationMaterialInstallation_I

Issuing an Acoustical Insulation Material Installation: No Ceilings policy

@Construction @WC @Issued @AZ @Regression @YourServices
Scenario: WC Acoustical Insulation Material Installation: No Ceilings policy issued for Arizona
	Given user starts a quote with:
		| Industry                                                 | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Acoustical Insulation Material Installation: No Ceilings | 3         | I Lease a Space From Others |              | 85383    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 9 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 57000                       |
		| Are there employees that do not do any actual physical work but travel to job sites?   | no                          |
		| Are there any employees that never travel to job sites or do any construction work?    | no                          |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                          |
		| Business                                                                               | Celestial Echos;CE          |
		| Address                                                                                | 8562 W Donald Dr;Peoria     |
		| Fill Contact                                                                           |                             |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user handles the WC Excluded OO with these values:
		| First Name | Last Name |
		| Vera       | Angel     |
	Then user continues on from the WC OO page
	Then user fills out the WC Your Services page
		| Question                                                                                                         | Answer      |
		| Do you install any residential attic fans that involve climbing on roofs?                                        | no          |
		| Do you ever transport six or more workers in the same vehicle?                                                   | no          |
		| In the past 3 years how many Workers' Compensation claims were reported?                                         | None        |
		| Do you perform any work over 30 feet above ground level?                                                         | yes         |
		| What is the max height, in feet, you work above ground level?                                                    | 10          |
		| Do you perform any work underground including in trenches, holes, or tunnels?                                    | no          |
		| Do you do any demolition or wrecking of entire buildings or homes?                                               | no          |
		| Do the business owner(s) of this business have a combined majority ownership in any other construction business? | no          |
		| Do you install any fiberglass or spray foam?                                                                     | no          |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                        | yes         |
		| Do you do any construction work in New York?                                                                     | no          |
		| Do you have multiple locations in more than one state?                                                           | no          |
		| Social Security Number (SSN)                                                                                     | 325-64-9484 |
	Then user verifies the appearance of the WC Summary page
	Then user clicks continue from WC Summary page
	When user selects a Standard Single-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
	Then user begins the WC AI page having the SSN with value 325-64-9484
	Then wc user handles 1 excluded oo with these values:
		| Have Name |
		|           |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value                  |
		| Payment Option      | One Pay Plan           |
		| CC Name             | Celestial Echos        |
		| CC Number           | 4111111111111111       |
		| CC Expiration Month | 11                     |
		| CC Expiration Year  | 25                     |
		| Autopay             | No                     |
		| First Name          | TestF                  |
		| Last Name           | TestL                  |
		| Email               | TestFTestL@Test123.com |
		| Phone               | 7777777777             |
		| Same Billing Info?  | Yes                    |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance
	Then user verifies that these LOBs are recommended: GL