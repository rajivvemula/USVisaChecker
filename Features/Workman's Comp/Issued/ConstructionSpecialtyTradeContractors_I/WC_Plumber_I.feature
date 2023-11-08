Feature: WC_Plumber_I

Issuing an WC policy to a plumber in NV

@Construction @WC @Issued @NV @Regression @YourServices
Scenario: WC Plumber policy in NV
		Given user starts a quote with:
		| Industry              | Employees | Location                    | Own or Lease | ZIP Code | LOB |
		| Plumbers: Contracting | 3         | I Lease a Space From Others |              | 89701    | WC  |
		Then user verifies the appearance of the WC About You Page
		Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                              |
		| When do you want your policy to start?                                                 |                                     |
		| When did you start your business?                                                      | Started 9 years ago                 |
		| How is your business structured?                                                       | Limited Liability Co. (LLC)         |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 57000                               |
		| Are there any employees that never travel to job sites or do any construction work?    | no                                  |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                                  |
		| Business                                                                               | TestPlumber                         |
		| Address                                                                                | 101 North Carson Street;Carson City |
		| Contact First Name                                                                     | TestF                               |
		| Contact Last Name                                                                      | TestL                               |
		| Email                                                                                  | Test@Test123.com                    |
		| Phone                                                                                  | 1231231321                          |
		Then user verifies the appearance of the WC Owners and Officers Page
		Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
		Then user continues on from the WC OO page
		Then user fills out the WC Your Services page
		| Question                                                                              | Answer     |
		| Do you install well pumps or septic tanks?                                            | no         |
		| In the past 3 years how many Workers' Compensation claims were reported?              | None       |
		| What is the max depth in feet you work underground?                                   | 5          |
		| What is the max height in feet you work above ground level?                           | 5          |
		| Do you do any work on boilers for commercial, industrial, or multi-family residences? | no         |
		| Do you currently have a Workers' Compensation insurance policy in effect?             | yes        |
		| Do you do any construction work in New York?                                          | no         |
		| Do you have multiple locations in more than one state?                                | no         |
		| Federal Employer Identification Number (FEIN)                                         | 06-2671064 |
		Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
		When user selects a Standard Single-Bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | Value                   |
		| ELL - Each Accident / Total Policy / Each Employee | 100,000/500,000/100,000 |
		Then wc user handles 1 excluded oo with these values:
		| Set Name    |
		| NameA NameB |
		Then user continues on from the WC Additional Information page
		Then user fills out the WC purchase page with these values:
		| Field               | Value                  |
		| Payment Option      | One Pay Plan           |
		| CC Name             | SD Weldings            |
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