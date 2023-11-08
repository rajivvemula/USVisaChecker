Feature: WC_AwningsManufacturing_I

Issuing policy for Manufacturing: Awnings Manufacturing
zip code: 63010

@Manufacturing @WC @Issued @MO @Regression @YourServices 
Scenario: WC Awnings Manufacturing creates issued policy in Missouri
	Given user starts a quote with:
		| Industry                               | Employees | Location                           | Own or Lease | ZIP Code | LOB |
		| Awnings Manufacturing: No Installation | 5         | I Own a Property & Lease to Others |              | 63010    | WC  |
	Then user verifies the appearance of the WC About You Page
	Then user fills out the WC About You page with these values:
		| Question                                                                                        | Answer                              |
		| When did you start your business?                                                               | Started 8 years ago                 |
		| How is your business structured?                                                                | Partnership                         |
		| What is the total annual payroll for W-2 employees? (exclude business owners/officers)          | 500000                              |
		| Are there any travelling sales staff that are not involved at all in the manufacturing process? | no                                  |
		| Do any employees only do general office work and rarely travel?                                 | no                                  |
		| Business                                                                                        |                                     |
		| Address                                                                                         | 130 Arnold Crossroads Center;Arnold |
		| Fill Contact                                                                                    |                                     |
	Then user verifies the appearance of the WC Owners and Officers Page
	Then user handles the WC OO kickoff questions with these values:
		| Question                                                        | Answer |
		| How many owners/officers does your business have?               | 2      |
		| How many owners/officers do you want to cover with this policy? | 0      |
	Then user continues on from the WC OO page
	Then user verifies the appearance of the WC Your Services Page
	Then user fills out the WC Your Services page
		| Question                                                                                      | Answer                                        |
		| Other than hand-held power tools, do you use any equipment or machinery?                      | no                                            |
		| Do you do (or arrange for subcontractors to do) any installation services for your customers? | no                                            |
		| Do your employees deliver any of your finished product?                                       | Never - 3rd party/Postal Service delivers all |
		| In the past 3 years how many Workers' Compensation claims were reported?                      | None                                          |
		| Are any employees required to physically lift/move more than 50 lbs?                          | no                                            |
		| Do you currently have a Workers' Compensation insurance policy in effect?                     | yes                                           |
		| Do you have multiple locations in more than one state?                                        | no                                            |
	Then user verifies the appearance of the WC Summary page
    Then user clicks continue from WC Summary page
    Then user verifies the WC your quote page appearance
	When user selects a standard single-bundle plan quote with the following customizations from the WC your quote page:
		| Customization                                      | 
		| N/A |
	Then user begins the WC AI page setting the FEIN with value 12-3123124
	Then wc user handles 2 excluded oo with these values:
		| Set Name    |
		| NameA NameB |
		| NameC NameD |
	Then user continues on from the WC Additional Information page
	Then user fills out the WC purchase page with these values:
		| Field               | Value            |
		| Payment Option      | One Pay Plan     |
		| CC Name             | TestFN TestLN    |
		| CC Number           | 4111111111111111 |
		| CC Expiration Month | 03               |
		| CC Expiration Year  | 27               |
		| Autopay             | No               |
		| First Name          | TestF            |
		| Last Name           | TestL            |
		| Email               | Test@Test123.com |
		| Phone               | 3211234567       |
		| Same Billing Info?  | Yes              |
	Then user verifies the WC how would you rate our service modal
	Then user verifies the WC thank you page appearance