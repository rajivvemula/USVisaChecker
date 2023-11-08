Feature: WC_NewCommercialBuildings_I
Issuing a WC policy to a Builder: New Commercial Buildings in New Hampshire(NH)

@Construction @WC @Issued @NH @Regression @YourServices
Scenario: WC New Commercial Buildings Issued In New Hampshire
		Given user starts a quote with:
		| Industry                          | Employees | Location                              | Own or Lease | ZIP Code | LOB |
		| Builder: New Commercial Buildings | 3         | i run my business from property i own |              | 03256    | WC  |
		Then user verifies the appearance of the WC About You Page
		Then user fills out the WC About You page with these values:
		| Question                                                                               | Answer                      |
		| When do you want your policy to start?                                                 |                             |
		| When did you start your business?                                                      | Started 7 years ago         |
		| How is your business structured?                                                       | Limited Liability Co. (LLC) |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers) | 57000                       |
		| Are there any employees that never travel to job sites or do any construction work?    | no                          |
		| Do any employees only do electrical work?                                              | yes                         |
		| Do you use any subcontractors or pay any workers using IRS Form 1099?                  | no                          |
		| Business                                                                               | TestPlumber                 |
		| Address                                                                                | 34 BALDWIN ST;New Hampton   |
		| Contact First Name                                                                     | TestF                       |
		| Contact Last Name                                                                      | TestL                       |
		| Email                                                                                  | Test@Test123.com            |
		| Phone                                                                                  | 1231231321                  |
		Then user verifies the appearance of the WC Owners and Officers Page
		Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 1      |
		| How many owners/officers do you want to cover with this policy? | 0      |
		Then user continues on from the WC OO page
		Then user fills out the WC Your Services page
		| Question                                                                                                         | Answer                         |
		| What percentage of work done is framing (rough carpentry)?                                                       | 0                              |
		| Do you ever transport six or more workers in the same vehicle?                                                   | no                             |
		| What is the percentage of residential work done?                                                                 | 0                              |
		| Do you do roofing work?                                                                                          | no                             |
		| In the past 3 years how many Workers' Compensation claims were reported?                                         | None                           |
		| Do you perform any work over 30 feet above ground level?                                                         | no                             |
		| Do you do any water damage, fire damage, or mold restoration?                                                    | no                             |
		| Do you do any demolition or wrecking of entire buildings or homes?                                               | no                             |
		| Do the business owner(s) of this business have a combined majority ownership in any other construction business? | no                             |
		| Do you currently have a Workers' Compensation insurance policy in effect?                                        | no                             |
		| When was your last policy in effect?                                                                             | 30 days to 6 months ago        |
		| Has there been any worker injuries or accidents since the last policy was in effect?                             | No to the best of my knowledge |
		| Do you do any construction work in New York?                                                                     | no                             |
		| Do you have multiple locations in more than one state?                                                           | no                             |
		| Federal Employer Identification Number (FEIN)                                                                    | 06-2671064                     |
		Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
		When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization |
		| N/A           |
		Then user begins the WC AI page having the FEIN with value 06-2671064 
		Then wc user handles 1 excluded oo with these values:
		| Set Name    | Set Job   | Set DOB  |
		| NameA NameB | President | 9/9/1991 |
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